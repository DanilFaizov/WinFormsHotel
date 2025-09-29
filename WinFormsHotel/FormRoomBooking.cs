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
using WinFormsHotel.Helpers;

namespace WinFormsHotel
{
    public partial class FormRoomBooking : Form
    {
        private List<Control> _bookingFields;
        private readonly DatabaseManager _db;
        private readonly string _tableName = Constants.TableBooking.Name;
        private DataGridViewRow _selectedRow;
        public FormRoomBooking(DatabaseManager db)
        {
            InitializeComponent();
            _db = db;

            _db.LoadTable(Constants.TableRoom.Name);
            _db.LoadTable(Constants.TableClient.Name);
            _db.LoadTable(Constants.TableBooking.Name);

            comboBoxRoom.DataSource = _db.GetTable("room");
            comboBoxRoom.DisplayMember = "room_number";
            comboBoxRoom.ValueMember = "id";
            comboBoxRoom.Tag = "room_id";

            comboBoxClient.DataSource = _db.GetTable("client");
            comboBoxClient.DisplayMember = "first_name";
            comboBoxClient.ValueMember = "id";
            comboBoxClient.Tag = "client_id";

            datePickerStart.Format = DateTimePickerFormat.Short;
            datePickerStart.Tag = "start_date";
            datePickerEnd.Format = DateTimePickerFormat.Short;
            datePickerEnd.Tag = "end_date";

            var columns = _db.GetTableColumns(_tableName, Constants.TableBooking.Id);
            _bookingFields = ComponentsHelper.CreateEditFields(this, columns);

            // Привязка данных к гриду
            dataGridView1.DataSource = _db.ViewTable(_tableName);
            _db.SetGridProperties(dataGridView1);
            _db.PrepareColumnsForBooking(dataGridView1);
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (!HasSelectedRow(false)) return;

            var table = _db.GetTable(_tableName);
            var row = table.Rows[_selectedRow.Index];
            ComponentsHelper.CopyDataToEditFields(row, _bookingFields);
        }

        private bool HasSelectedRow(bool showWarning = true)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _selectedRow = dataGridView1.SelectedRows[0];
                return true;
            }

            if (showWarning)
                MessageBox.Show("Выберите строку в таблице!");

            return false;
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            try
            {
                var startDate = datePickerStart.Value.Date;
                var endDate = datePickerEnd.Value.Date;

                if (endDate <= startDate)
                {
                    MessageBox.Show("Дата выезда должна быть позже даты заезда");
                    return;
                }

                int roomId = (int)comboBoxRoom.SelectedValue;
                if (_db.IsRoomOccupied(roomId, startDate, endDate))
                {
                    MessageBox.Show("Номер уже занят в указанные даты");
                    return;
                }

                // Добавление брони через DatabaseManager
                _db.AddNewRow(_tableName, _bookingFields);

                // Получаем таблицу через метод DatabaseManager
                var bookingTable = _db.GetTable(Constants.TableBooking.Name);
                if (bookingTable == null)
                {
                    MessageBox.Show("Таблица booking не загружена");
                    return;
                }

                // Обновляем статус последней добавленной строки
                var bookingRow = bookingTable.AsEnumerable().LastOrDefault();
                if (bookingRow != null)
                {
                    bookingRow["status"] = "Ожидание";
                }

                // Отправка данных в БД
                _db.SendTableToServer(_tableName, Constants.TableBooking.Id);
                MessageBox.Show("Бронирование создано");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка бронирования: {ex.Message}");
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (!HasSelectedRow()) return;

            var bookingId = Convert.ToInt32(_selectedRow.Cells["id"].Value);
            var formPayment = new FormRoomBookingPayment(_db, bookingId);
            formPayment.ShowDialog();
        }
    }
}
