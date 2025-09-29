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
    public partial class FormEmployeeTwo : Form
    {
        private List<Control> _employeeFields;
        private readonly DatabaseManager _db;
        private readonly string _tableName = Constants.TableStaff.Name;
        public FormEmployeeTwo(DatabaseManager db)
        {
            InitializeComponent();
            _db = db;

            _db.LoadTable(Constants.TableStaff.Name);
            _db.LoadTable(Constants.TableStaffStatus.Name);

            var columns = _db.GetTableColumns(_tableName, Constants.TableStaff.Id)
                .Where(c => new[] { Constants.TableStaff.FirstName, Constants.TableStaff.LastName, Constants.TableStaff.MiddleName, Constants.TableStaff.Passport, Constants.TableStaff.Phone }
                    .Contains(c.ColumnName))
                .ToList();

            _employeeFields = ComponentsHelper.CreateEditFields(this, columns);

            // Паспорт нельзя редактировать после создания
            var passportField = _employeeFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.Passport);
            if (passportField is TextBox textBoxPassport)
            {
                textBoxPassport.ReadOnly = false; // Теперь можно редактировать
            }

            // Статус "Ожидает" (id = 2)
            var statusField = _employeeFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.StatusId);
            if (statusField is ComboBox comboBoxStatus)
            {
                comboBoxStatus.DataSource = _db.GetTable(Constants.TableStaffStatus.Name);
                comboBoxStatus.DisplayMember = Constants.TableStaffStatus.NameColumn;
                comboBoxStatus.ValueMember = Constants.TableStaffStatus.Id;
                comboBoxStatus.SelectedValue = 1; // ID статуса "Ожидает"
                comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxStatus.Enabled = false;
            }

            // Отображение даты найма
            labelHireDate.Text = $"{DateTime.Now.Date.ToShortDateString()}";
        }

        private string GetFieldValue(string columnName)
        {
            return _employeeFields
                .FirstOrDefault(c => c.Tag?.ToString() == columnName)?
                .Text?.Trim();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение значений из контролов
                var firstName = GetFieldValue(Constants.TableStaff.FirstName);
                var lastName = GetFieldValue(Constants.TableStaff.LastName);
                var passport = GetFieldValue(Constants.TableStaff.Passport);
                var phone = GetFieldValue(Constants.TableStaff.Phone);

                // Проверка обязательных полей
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Имя и телефон не могут быть пустыми");
                    return;
                }

                // Проверка уникальности
                if (_db.IsPassportExists(passport))
                {
                    MessageBox.Show("Паспорт уже зарегистрирован");
                    return;
                }

                if (_db.IsPhoneExists(phone))
                {
                    MessageBox.Show("Телефон уже используется");
                    return;
                }

                // Добавление заявки в staff
                var staffData = new Dictionary<string, object>
                {
                    [Constants.TableStaff.FirstName] = firstName,
                    [Constants.TableStaff.LastName] = lastName,
                    [Constants.TableStaff.MiddleName] = GetFieldValue(Constants.TableStaff.MiddleName),
                    [Constants.TableStaff.Passport] = passport,
                    [Constants.TableStaff.Phone] = phone,
                    [Constants.TableStaff.HireDate] = DateTime.Now.Date,
                    [Constants.TableStaff.StatusId] = 2 // "Ожидает ответа"
                };

                _db.AddNewRow(Constants.TableStaff.Name, staffData);
                _db.SendTableToServer(Constants.TableStaff.Name, Constants.TableStaff.Id);
                MessageBox.Show("Заявка отправлена");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
