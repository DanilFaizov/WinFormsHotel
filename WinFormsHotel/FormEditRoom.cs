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
    public partial class FormEditRoom : Form
    {
        private List<Control> _editFields;
        private readonly DatabaseManager _db;
        private readonly string _tableName;
        private readonly string _idName;
        private DataGridViewRow _selectedRow;
        public FormEditRoom(DatabaseManager db, string tableName, string idName)
        {
            InitializeComponent();
            _db = db;
            _tableName = tableName;
            _idName = idName;

            // Загрузка справочников
            _db.LoadTable("room_type");
            _db.LoadTable("room_status");
            _db.LoadTable("staff");

            // Настраиваем ComboBox
            comboBoxRoomType.DataSource = _db.GetTable("room_type");
            comboBoxRoomType.DisplayMember = "name";
            comboBoxRoomType.ValueMember = "id";

            comboBoxStatus.DataSource = _db.GetTable("room_status");
            comboBoxStatus.DisplayMember = "name";
            comboBoxStatus.ValueMember = "id";

            comboBoxResponsibleStaff.DataSource = _db.GetTable("staff");
            comboBoxResponsibleStaff.DisplayMember = "last_name";
            comboBoxResponsibleStaff.ValueMember = "id";

            var columns = _db.GetTableColumns(_tableName, _idName);
            // Создание полей ввода
            _editFields = ComponentsHelper.CreateEditFields(this, columns);
            dataGridView1.DataSource = db.ViewTable(tableName);
            db.SetGridProperties(dataGridView1);
            db.PrepareColumnsForRoom(dataGridView1);
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
                // Проверка уникальности номера
                var roomNumberControl = _editFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableRoom.RoomNumber);
                if (roomNumberControl is TextBox roomTextBox)
                {
                    string roomNumber = roomTextBox.Text.Trim();
                    if (_db.IsRoomNumberExists(roomNumber))
                    {
                        MessageBox.Show("Номер с таким номером уже существует");
                        return;
                    }
                }

                _db.AddNewRow(_tableName, _editFields);
                MessageBox.Show("Номер добавлен");
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!HasSelectedRow()) return;

            try
            {
                _db.DeleteRow(_tableName, _selectedRow.Index);
                MessageBox.Show("Запись удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        private void buttonSendToServer_Click(object sender, EventArgs e)
        {
            _db.SendTableToServer(_tableName, _idName);
            MessageBox.Show("Изменения отправлены в БД");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _db.CancelChanges(_tableName);
            MessageBox.Show("Изменения отменены");
        }
    }
}