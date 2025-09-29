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
    public partial class FormEmployeeOld : Form
    {
        private List<Control> _editFields;
        private readonly DatabaseManager _db;
        private readonly string _tableName;
        private readonly string _idName;
        private DataGridViewRow _selectedRow;

        public FormEmployeeOld(DatabaseManager db, string tableName, string idName)
        {
            InitializeComponent();
            _db = db;
            _tableName = tableName;
            _idName = idName;

            // Создаем поля редактирования на основе колонок таблицы
            _editFields = ComponentsHelper.CreateEditFields(groupBox1, _db.GetTableColumns(_tableName, _idName));

            // Привязываем данные к гриду
            dataGridView1.DataSource = _db.ViewTable(_tableName);
            _db.SetGridProperties(dataGridView1);
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        /// <summary>
        /// Обработчик события выбора строки в гриде
        /// </summary>
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (!HasSelectedRow(showWarning: false)) return;

            // Копируем данные из грида в поля редактирования
            ComponentsHelper.CopyDataToEditFields(_selectedRow, _editFields);
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _db.CancelChanges(_tableName);
            MessageBox.Show("Изменения отменены");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _db.AddNewRow(_tableName, _editFields);
                MessageBox.Show("Запись добавлена");
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
                var hireDate = _editFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.HireDate);
                var dismissalDate = _editFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.DismissalDate);

                if (hireDate is DateTimePicker hirePicker && dismissalDate is DateTimePicker dismissPicker)
                {
                    if (dismissPicker.Value.Date < hirePicker.Value.Date && dismissPicker.Value != DateTime.MinValue)
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
    }
}
