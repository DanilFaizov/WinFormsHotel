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
    public partial class FormClient : Form
    {
        private List<Control> _editFields;
        private readonly DatabaseManager _db;
        private readonly string _tableName;
        private readonly string _idName;
        private DataGridViewRow _selectedRow;

        public FormClient(DatabaseManager db, string tableName, string idName)
        {
            InitializeComponent();
            _db = db;
            _tableName = tableName;
            _idName = idName;

            // Загрузка данных


            // Создание полей ввода на форме
            var columns = _db.GetTableColumns(_tableName, _idName);
            _editFields = ComponentsHelper.CreateEditFields(this, columns);

            // Привязка данных к гриду
            dataGridView1.DataSource = _db.ViewTable(_tableName);
            _db.SetGridProperties(dataGridView1);
            _db.PrepareColumnsForClient(dataGridView1);
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (!HasSelectedRow(false)) return;

            var table = _db.GetTable(_tableName);
            var row = table.Rows[_selectedRow.Index];
            ComponentsHelper.CopyDataToEditFields(row, _editFields);
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
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка уникальности паспорта
                var passportField = _editFields.FirstOrDefault(c => c.Tag?.ToString() == "passport");
                if (passportField is TextBox passportTextBox)
                {
                    string passport = passportTextBox.Text.Trim();
                    if (_db.IsPassportExists(passport))
                    {
                        MessageBox.Show("Клиент с таким паспортом уже существует");
                        return;
                    }
                }

                _db.AddNewRow(_tableName, _editFields);
                MessageBox.Show("Клиент добавлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!HasSelectedRow()) return;

            try
            {
                _db.UpdateRow(_tableName, _selectedRow.Index, _editFields);
                MessageBox.Show("Данные обновлены");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления: {ex.Message}");
            }
        }

        //private void buttonDelete_Click(object sender, EventArgs e)
        //{
        //    if (!HasSelectedRow()) return;

        //    try
        //    {
        //        var staffTable = _db.GetTable(_tableName);
        //        var row = staffTable.Rows[_selectedRow.Index];
        //        int clientId = (int)row["id"];

        //        // ❗ Сначала удаляем связанные записи в booking
        //        var bookingTable = _db.GetTable("booking");
        //        var relatedBookings = bookingTable.AsEnumerable()
        //            .Where(r => (int)r["client_id"] == clientId);

        //        foreach (var bookingRow in relatedBookings.ToList())
        //        {
        //            bookingRow.Delete(); // Удаляем каждую связанную бронь
        //        }

        //        // Теперь удаляем клиента
        //        row.Delete();
        //        MessageBox.Show("Клиент и связанные бронирования удалены");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка удаления: {ex.Message}");
        //    }
        //}

        private void buttonSendToServer_Click(object sender, EventArgs e)
        {
            try
            {
                _db.SendTableToServer(_tableName, _idName);
                MessageBox.Show("Изменения отправлены в БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _db.CancelChanges(_tableName);
            MessageBox.Show("Изменения отменены");
        }

        private void buttonBooking_Click(object sender, EventArgs e)
        {
            var formEdit = new FormRoomBooking(
                _db
            );
            formEdit.ShowDialog();
        }
    }
}
