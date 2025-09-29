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
    public partial class FormEditEmployee : Form
    {
        private List<Control> _editFields;
        private readonly DatabaseManager _db;
        private readonly string _tableName = Constants.TableStaff.Name;
        private readonly string _idName = Constants.TableStaff.Id;
        private DataGridViewRow _selectedRow;
        public FormEditEmployee(DatabaseManager db)
        {
            InitializeComponent();
            _db = db;

            // Загрузка таблиц
            _db.LoadTable(Constants.TableStaff.Name);
            _db.LoadTable(Constants.TableStaffStatus.Name);

            // Создание полей редактирования (только status_id и dismissal_date)
            var columns = _db.GetTableColumns(_tableName, _idName)
                .Where(c => new[] { Constants.TableStaff.DismissalDate, Constants.TableStaff.StatusId }
                    .Contains(c.ColumnName))
                .ToList();

            _editFields = ComponentsHelper.CreateEditFields(this, columns);

            // Настройка ComboBox для статуса
            var statusField = _editFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.StatusId);
            if (statusField is ComboBox comboBoxStatus)
            {
                var statusTable = _db.GetTable(Constants.TableStaffStatus.Name);
                if (statusTable == null || statusTable.Rows.Count == 0)
                {
                    MessageBox.Show("Таблица staff_status пуста");
                    return;
                }

                comboBoxStatus.DataSource = statusTable;
                comboBoxStatus.DisplayMember = Constants.TableStaffStatus.NameColumn; // "name"
                comboBoxStatus.ValueMember = Constants.TableStaffStatus.Id; // "id"
                comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxStatus.Enabled = true;
            }

            // Настройка DateTimePicker для даты увольнения
            var dismissalField = _editFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.DismissalDate);
            if (dismissalField is DateTimePicker datePickerDismissal)
            {
                datePickerDismissal.Format = DateTimePickerFormat.Short;
                datePickerDismissal.ShowCheckBox = true;
                datePickerDismissal.CustomFormat = " ";
            }

            // Привязка данных к гриду
            dataGridView1.DataSource = _db.ViewTable(_tableName);
            _db.SetGridProperties(dataGridView1);
            _db.PrepareColumnsForStaff(dataGridView1);
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
                MessageBox.Show("Выберите служащего для редактирования");

            return false;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!HasSelectedRow()) return;

            try
            {
                var table = _db.GetTable(_tableName);
                var row = table.Rows[_selectedRow.Index];

                // Получение новых значений из контролов
                var dismissalPicker = _editFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.DismissalDate) as DateTimePicker;
                var statusPicker = _editFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.StatusId) as ComboBox;

                // Обновление статуса
                if (statusPicker?.SelectedValue is int statusId)
                    row[Constants.TableStaff.StatusId] = statusId;

                // Обновление даты увольнения
                if (dismissalPicker != null)
                    row[Constants.TableStaff.DismissalDate] = dismissalPicker.Checked
                        ? dismissalPicker.Value.Date
                        : DBNull.Value;

                MessageBox.Show("Данные обновлены");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления: {ex.Message}");
            }
        }

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
    }
}
