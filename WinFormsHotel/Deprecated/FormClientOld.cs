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
    public partial class FormClientOld : Form
    {
        private List<Control> _editFields;
        private readonly DatabaseManager _db;
        private readonly string _tableName;
        private readonly string _idName;
        private DataGridViewRow _selectedRow;

        public FormClientOld(DatabaseManager db, string tableName, string idName)
        {
            InitializeComponent();
            this._db = db;
            this._tableName = tableName;
            this._idName = idName;

            // Создаем поля редактирования на основе колонок таблицы
            _editFields = ComponentsHelper.CreateEditFields(groupBox1, _db.GetTableColumns(_tableName, _idName));

            // Привязываем данные к гриду
            dataGridView1.DataSource = _db.ViewTable(_tableName);
            _db.SetGridProperties(dataGridView1);

            // Подписываемся на событие выбора строки
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }


        /// <summary>
        /// Проверяет, выбрана ли строка в гриде
        /// </summary>
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

        /// <summary>
        /// Обработчик события выбора строки в гриде
        /// </summary>
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (!HasSelectedRow(showWarning: false)) return;

            // Копируем данные из грида в поля редактирования
            ComponentsHelper.CopyDataToEditFields(_selectedRow, _editFields);
        }

        private bool IsValidPhone(string phone)
        {
            // Проверка формата и длины
            return System.Text.RegularExpressions.Regex.IsMatch(
                phone,
                @"^\+7 $[0-9]{3}$ [0-9]{3}-[0-9]{2}-[0-9]{2}$"
            ) && phone.Length <= 18;
        }
        /// <summary>
        /// Обработчик кнопки "Добавить"
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка уникальности паспорта
                if (_tableName == "client")
                {
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
                }

                // Проверка формата телефона


                _db.AddNewRow(_tableName, _editFields);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}");
            }
        }

        /// <summary>
        /// Обработчик кнопки "Обновить"
        /// </summary>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!HasSelectedRow()) return;

            try
            {
                // Проверка формата телефона
                var phoneField = _editFields.FirstOrDefault(c => c.Tag?.ToString() == "phone");
                if (phoneField is TextBox phoneTextBox)
                {
                    string phone = phoneTextBox.Text.Trim();
                    if (!IsValidPhone(phone))
                    {
                        MessageBox.Show("Неверный формат телефона. Используйте +7 (XXX) XXX-XX-XX");
                        return;
                    }
                }

                _db.UpdateRow(_tableName, _selectedRow.Index, _editFields);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления: {ex.Message}");
            }
        }

        /// <summary>
        /// Обработчик кнопки "Удалить"
        /// </summary>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!HasSelectedRow()) return;

            try
            {
                // Удаляем выбранную строку
                _db.DeleteRow(_tableName, _selectedRow.Index);
                MessageBox.Show("Запись успешно удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        /// <summary>
        /// Обработчик кнопки "Сохранить"
        /// </summary>
        private void buttonSendToServer_Click(object sender, EventArgs e)
        {
            try
            {
                // Отправляем изменения в БД
                _db.SendTableToServer(_tableName, _idName);
                MessageBox.Show("Данные успешно сохранены в базе данных");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }

        /// <summary>
        /// Обработчик кнопки "Отменить"
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // Отменяем локальные изменения
                _db.CancelChanges(_tableName);
                MessageBox.Show("Изменения отменены");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отмены: {ex.Message}");
            }
        }

        /// <summary>
        /// Проверка, существует ли клиент с таким паспортом
        /// </summary>
        private bool IsPassportExists(string passport)
        {
            var table = _db.GetTable("client");
            return table.Rows.Cast<DataRow>().Any(r => r["passport"].ToString() == passport);
        }
    }
}
