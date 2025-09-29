using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WinFormRelationManual;
using WinFormsHotel.Helpers;

namespace WinFormsHotel
{
    public partial class FormEmployeeOld2 : Form
    {
        private List<Control> _editFields;
        private readonly DatabaseManager _db;
        private readonly string _tableName;
        private readonly string _idName;
        private DataGridViewRow _selectedRow;
        public FormEmployeeOld2(DatabaseManager db, string tableName, string idName)
        {
            InitializeComponent();
            _db = db;
            _tableName = tableName;
            _idName = idName;

            // Загрузка данных
            if (_db.GetTable(_tableName) == null)
                _db.LoadTable(_tableName);

            // Создание полей ввода на форме
            var columns = _db.GetTableColumns(_tableName, _idName);
            _editFields = ComponentsHelper.CreateEditFields(this, columns);

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
                MessageBox.Show("Выберите строку в таблице!");

            return false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем контролы по Tag
                var hireDateControl = _editFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.HireDate);
                var dismissalDateControl = _editFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.DismissalDate);

                if (hireDateControl is DateTimePicker hirePicker &&
                    dismissalDateControl is DateTimePicker dismissPicker)
                {
                    DateTime hireDate = hirePicker.Value.Date;
                    DateTime? dismissalDate = null;

                    // Учтите, что dismissal_date может быть NULL
                    if (dismissPicker.Checked) // Если дата установлена
                        dismissalDate = dismissPicker.Value.Date;

                    // Проверка даты увольнения
                    if (!_db.IsValidDismissalDate(hireDate, dismissalDate))
                    {
                        MessageBox.Show("Дата увольнения не может быть раньше даты найма");
                        return;
                    }
                }

                _db.AddNewRow(_tableName, _editFields);
                MessageBox.Show("Данные обновлены");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления: {ex.Message}");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!HasSelectedRow()) return;

            try
            {
                // Получаем контролы по Tag
                var hireDateControl = _editFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.HireDate);
                var dismissalDateControl = _editFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.DismissalDate);

                if (hireDateControl is DateTimePicker hirePicker &&
                    dismissalDateControl is DateTimePicker dismissPicker)
                {
                    DateTime hireDate = hirePicker.Value.Date;
                    DateTime? dismissalDate = null;

                    // Учтите, что dismissal_date может быть NULL
                    if (dismissPicker.Checked) // Если дата установлена
                        dismissalDate = dismissPicker.Value.Date;

                    // Проверка даты увольнения
                    if (!_db.IsValidDismissalDate(hireDate, dismissalDate))
                    {
                        MessageBox.Show("Дата увольнения не может быть раньше даты найма");
                        return;
                    }
                }

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
