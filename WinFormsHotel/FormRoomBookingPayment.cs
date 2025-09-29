using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormRelationManual;

namespace WinFormsHotel
{
    public partial class FormRoomBookingPayment : Form
    {
        private readonly DatabaseManager _db;
        private readonly int _bookingId;
        public FormRoomBookingPayment(DatabaseManager db, int bookingId)
        {
            InitializeComponent();
            _db = db;
            _bookingId = bookingId;

            // Загрузка данных
            _db.LoadTable(Constants.TableBooking.Name);
            _db.LoadTable(Constants.TableRoom.Name);
            _db.LoadTable(Constants.TableClient.Name);
            _db.LoadTable(Constants.TableStay.Name);
            _db.LoadTable(Constants.TableInvoice.Name);
            _db.LoadTable(Constants.TableRoomType.Name);

            LoadBookingDetails();
            LoadPaymentForm();
        }
        private void LoadBookingDetails()
        {
            // Получение таблицы booking
            var bookingTable = _db.GetTable(Constants.TableBooking.Name);
            if (bookingTable == null)
            {
                MessageBox.Show("Таблица бронирования не загружена");
                return;
            }

            // Поиск брони по ID
            var bookingRowForDetails = bookingTable.AsEnumerable()
                .FirstOrDefault(r => (int)r[Constants.TableBooking.Id] == _bookingId);

            if (bookingRowForDetails == null)
            {
                MessageBox.Show("Бронь не найдена");
                return;
            }

            // Получение данных о номере
            if (!bookingRowForDetails.Table.Columns.Contains(Constants.TableBooking.RoomId))
                return;

            int roomId = (int)bookingRowForDetails[Constants.TableBooking.RoomId];
            var roomTable = _db.GetTable(Constants.TableRoom.Name);
            var roomRow = roomTable?.AsEnumerable()
                .FirstOrDefault(r => (int)r[Constants.TableRoom.Id] == roomId);

            if (roomRow == null)
            {
                MessageBox.Show("Номер не найден");
                return;
            }

            // Получение данных о клиенте
            var clientTable = _db.GetTable(Constants.TableClient.Name);
            var clientRow = clientTable?.AsEnumerable()
                .FirstOrDefault(r => (int)r[Constants.TableClient.Id] == (int)bookingRowForDetails[Constants.TableBooking.ClientId]);

            if (clientRow == null)
            {
                MessageBox.Show("Клиент не найден");
                return;
            }

            // Заполнение полей
            textBoxBookingId.Text = _bookingId.ToString();
            textBoxClientName.Text = $"{clientRow[Constants.TableClient.FirstName]} {clientRow[Constants.TableClient.LastName]}";
            textBoxRoomNumber.Text = roomRow[Constants.TableRoom.RoomNumber]?.ToString();
            textBoxDates.Text = $"{bookingRowForDetails[Constants.TableBooking.StartDate]} - {bookingRowForDetails[Constants.TableBooking.EndDate]}";

            // Расчёт суммы
            int days = ((DateTime)bookingRowForDetails[Constants.TableBooking.EndDate] -
                        (DateTime)bookingRowForDetails[Constants.TableBooking.StartDate]).Days;

            var roomTypeTable = _db.GetTable(Constants.TableRoomType.Name);
            var roomTypeRow = roomTypeTable?.AsEnumerable()
                .FirstOrDefault(r => (int)r[Constants.TableRoomType.Id] == (int)roomRow[Constants.TableRoom.RoomTypeId]);

            if (roomTypeRow == null)
            {
                MessageBox.Show("Тип номера не найден");
                return;
            }

            decimal price = (decimal)roomTypeRow["price"];
            textBoxTotalAmount.Text = (price * days).ToString();
        }
        private void LoadPaymentForm()
        {
            comboBoxPaymentMethod.Items.AddRange(new object[] { "Наличные", "Карта", "Перевод" });
            comboBoxPaymentMethod.SelectedIndex = 0;
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка, существует ли stay для этой брони
                var stayTable = _db.GetTable(Constants.TableStay.Name);
                var existingStay = stayTable.AsEnumerable()
                    .FirstOrDefault(r => (int)r[Constants.TableStay.BookingId] == _bookingId);

                if (existingStay == null)
                {
                    // Создание stay
                    var bookingTableForStay = _db.GetTable(Constants.TableBooking.Name);
                    var bookingRowForStay = bookingTableForStay.AsEnumerable()
                        .FirstOrDefault(r => (int)r["id"] == _bookingId);

                    var roomTable = _db.GetTable(Constants.TableRoom.Name);
                    var roomRow = roomTable.AsEnumerable()
                        .FirstOrDefault(r => (int)r["id"] == (int)bookingRowForStay["room_id"]);

                    var roomTypeTable = _db.GetTable(Constants.TableRoomType.Name);
                    var roomTypeRow = roomTypeTable.AsEnumerable()
                        .FirstOrDefault(r => (int)r["id"] == (int)roomRow[Constants.TableRoom.RoomTypeId]);

                    int days = ((DateTime)bookingRowForStay["end_date"] - (DateTime)bookingRowForStay["start_date"]).Days;
                    decimal price = (decimal)roomTypeRow["price"];
                    decimal totalCost = price * days;

                    var stayData = new Dictionary<string, object>
                    {
                        [Constants.TableStay.BookingId] = _bookingId,
                        [Constants.TableStay.ActualCheckIn] = DateTime.Now,
                        [Constants.TableStay.TotalCost] = totalCost
                    };
                    _db.AddNewRow(Constants.TableStay.Name, stayData);
                }

                _db.SendTableToServer(Constants.TableStay.Name, Constants.TableStay.Id);
                _db.LoadTable(Constants.TableStay.Name); // Обновите локальные данные

                var updatedStayTable = _db.GetTable(Constants.TableStay.Name);
                var stayRow = updatedStayTable.AsEnumerable()
                    .FirstOrDefault(r => (int)r["booking_id"] == _bookingId);

                if (stayRow == null)
                {
                    MessageBox.Show("Не удалось найти stay");
                    return;
                }
                int stayId = (int)stayRow["id"];

                // Добавление invoice
                var paymentData = new Dictionary<string, object>
                {
                    [Constants.TableInvoice.StayId] = stayId,
                    [Constants.TableInvoice.TotalAmount] = decimal.Parse(textBoxTotalAmount.Text),
                    [Constants.TableInvoice.PaymentDate] = datePickerPayment.Value.Date,
                    [Constants.TableInvoice.PaymentMethod] = comboBoxPaymentMethod.SelectedItem.ToString()
                };
                _db.AddNewRow(Constants.TableInvoice.Name, paymentData);

                // Обновление статуса брони
                var bookingTableForStatus = _db.GetTable(Constants.TableBooking.Name);
                var bookingRowForStatus = bookingTableForStatus.AsEnumerable()
                    .FirstOrDefault(r => (int)r["id"] == _bookingId);

                if (bookingRowForStatus != null)
                {
                    bookingRowForStatus["status"] = "Подтверждено";
                }

                // Отправка изменений в БД
                _db.SendTableToServer(Constants.TableBooking.Name, Constants.TableBooking.Id);
                _db.SendTableToServer(Constants.TableInvoice.Name, Constants.TableInvoice.Id);
                MessageBox.Show("Оплата успешно сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка оплаты: {ex.Message}");
            }
        }
    }
}
