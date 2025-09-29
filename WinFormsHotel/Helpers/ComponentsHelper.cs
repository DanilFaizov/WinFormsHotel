using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormRelationManual;

namespace WinFormsHotel.Helpers
{
    public class ComponentsHelper
    {
        /// <summary>
        /// Копирует данные из выбранной строки грида в поля редактирования
        /// </summary>
        /// <param name="selectedRow"></param>
        /// <param name="controls"></param>
        public static void CopyDataToEditFields(DataGridViewRow selectedRow, List<Control> controls)
        {
            foreach (var control in controls)
            {
                string columnName = control.Tag.ToString(); // Имя столбца из Tag
                object value = selectedRow.Cells[columnName].Value; // Значение из грида
                ControlSetValue(control, value); // Установка значения в контрол
            }
        }

        public static void CopyDataToEditFields(DataRow row, List<Control> controls)
        {
            // ❗ Проверка: строка удалена?
            if (row.RowState == DataRowState.Deleted)
                return; // Не копируем данные из удалённой строки

            foreach (var control in controls)
            {
                string columnName = control.Tag?.ToString();
                if (string.IsNullOrEmpty(columnName))
                    continue;

                // ❗ Проверка: колонка существует?
                if (!row.Table.Columns.Contains(columnName))
                    continue;

                object value = row[columnName];

                if (control is TextBox textBox)
                {
                    textBox.Text = value?.ToString();
                }
                else if (control is NumericUpDown numeric)
                {
                    if (value is int intValue)
                        numeric.Value = intValue;
                }
                else if (control is ComboBox comboBox)
                {
                    if (value is int idValue)
                        comboBox.SelectedValue = idValue;
                }
                else if (control is DateTimePicker datePicker)
                {
                    if (value is DBNull || value == null)
                    {
                        datePicker.Checked = false;
                        datePicker.CustomFormat = " ";
                    }
                    else if (value is DateTime dateValue)
                    {
                        datePicker.Value = dateValue.Date;
                        datePicker.Checked = true;
                        datePicker.Format = DateTimePickerFormat.Short;
                    }
                }
            }
        }


        public static List<Control> CreateRoomEditFields(Form form, DatabaseManager db)
        {
            var list = new List<Control>();
            Size size = new Size(150, 30);
            Point point = new Point(10, 250);

            var roomTable = db.GetTable("room");
            var roomTypeTable = db.GetTable("room_type");
            var roomStatusTable = db.GetTable("room_status");
            var staffTable = db.GetTable("staff");

            foreach (DataColumn column in roomTable.Columns.OfType<DataColumn>().Where(c => c.ColumnName != "id"))
            {
                Control control;
                if (column.ColumnName == "room_type_id")
                {
                    control = CreateComboBox("room_type", roomTypeTable);
                }
                else if (column.ColumnName == "status_id")
                {
                    control = CreateComboBox("room_status", roomStatusTable);
                }
                else if (column.ColumnName == "responsible_staff_id")
                {
                    control = CreateComboBox("staff", staffTable);
                }
                else if (column.DataType == typeof(int))
                {
                    control = new NumericUpDown();
                }
                else if (column.DataType == typeof(string))
                {
                    control = new TextBox();
                }
                else if (column.DataType == typeof(DateTime))
                {
                    control = new DateTimePicker();
                }
                else
                {
                    throw new ArgumentException($"Тип данных {column.DataType} не поддерживается");
                }

                list.Add(control);
                control.Tag = column.ColumnName;
                control.Size = size;
                control.Location = new Point(point.X, point.Y);
                form.Controls.Add(control);

                var label = new Label
                {
                    Text = column.ColumnName + ":",
                    Location = new Point(point.X - 60, point.Y),
                    Width = 60,
                    AutoSize = true
                };
                form.Controls.Add(label);

                point.Y = control.Bottom + 10;
            }

            return list;
        }
        private static Control CreateComboBox(string columnName, DataTable sourceTable)
        {
            var comboBox = new ComboBox
            {
                DisplayMember = "name",
                ValueMember = "id",
                DataSource = sourceTable,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Tag = columnName
            };
            return comboBox;
        }

        /// <summary>
        /// Устанавливает значение в контрол в зависимости от его типа
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        /// <exception cref="Exception"></exception>
        private static void ControlSetValue(Control control, object value)
        {
            if (control is TextBox textBox)
            {
                textBox.Text = value?.ToString() ?? string.Empty;
            }
            else if (control is NumericUpDown numericUpDown)
            {
                if (value != null && int.TryParse(value.ToString(), out int numericValue))
                    numericUpDown.Value = numericValue;
            }
            else if (control is DateTimePicker datePicker)
            {
                if (value != null && DateTime.TryParse(value.ToString(), out DateTime dateValue))
                    datePicker.Value = dateValue.Date; // Установка только даты
            }
            else
            {
                throw new Exception("Неподдерживаемый тип контрола. Поддерживаемые типы: TextBox, NumericUpDown, DateTimePicker");
            }
        }

        /// <summary>
        /// Создаёт поля редактирования на основе колонок таблицы
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<Control> CreateEditFields(Control parent, List<DataColumn> columns)
        {
            var list = new List<Control>();
            Size size = new Size(150, 30);
            Point point = new Point(10, 20);

            foreach (DataColumn column in columns)
            {
                Control control;

                if (column.DataType == typeof(int))
                {
                    control = CreateNumeric();
                }
                else if (column.DataType == typeof(string))
                {
                    control = CreateTextBox();
                }
                else if (column.DataType == typeof(DateTime))
                {
                    control = CreateDatePicker(); // Поддержка дат
                }
                else
                {
                    throw new ArgumentException($"Тип данных {column.DataType} не поддерживается");
                }

                list.Add(control);
                control.Tag = column.ColumnName; // Связываем контрол с именем колонки
                control.Size = size;

                var label = new Label
                {
                    Text = column.ColumnName + ":",
                    Location = new Point(point.X, point.Y)
                };

                control.Location = new Point(point.X, point.Y + label.Height + 2);

                parent.Controls.Add(label);
                parent.Controls.Add(control);

                point.Y = control.Bottom + 20;
            }

            return list;
        }

        public static List<Control> CreateEditFields(Form form, List<DataColumn> columns)
        {
            var list = new List<Control>();

            // Найдите уже существующие контролы по Tag
            foreach (Control control in form.Controls)
            {
                if (control.Tag is string columnName && columns.Any(c => c.ColumnName == columnName))
                {
                    list.Add(control);
                }
            }

            return list;
        }

        /// <summary>
        /// Создаёт TextBox для строковых значений
        /// </summary>
        /// <returns></returns>
        private static Control CreateTextBox()
        {
            return new TextBox();
        }

        /// <summary>
        /// Создаёт NumericUpDown для числовых значений
        /// </summary>
        /// <returns></returns>
        private static Control CreateNumeric()
        {
            var control = new NumericUpDown
            {
                Minimum = 0,
                Maximum = int.MaxValue
            };
            return control;
        }

        /// <summary>
        /// Создаёт DateTimePicker для дат
        /// </summary>
        /// <returns></returns>
        private static Control CreateDatePicker()
        {
            var control = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short, // Формат даты: "dd.MM.yyyy"
                CustomFormat = "yyyy-MM-dd"
            };
            return control;
        }


        /// <summary>
        /// Копирует данные из полей редактирования в строку таблицы
        /// </summary>
        /// <param name="editFields"></param>
        /// <param name="row"></param>
        public static void CopyDataFromEditFields(List<Control> editFields, DataRow row)
        {
            foreach (var control in editFields)
            {
                if (control == null || control.Tag == null)
                    continue;

                string columnName = control.Tag.ToString();
                if (control is ComboBox comboBox)
                {
                    row[columnName] = comboBox.SelectedValue ?? DBNull.Value;
                }
                else if (control is TextBox textBox)
                {
                    row[columnName] = textBox.Text;
                }
                else if (control is NumericUpDown numeric)
                {
                    row[columnName] = numeric.Value;
                }
                else if (control is DateTimePicker datePicker)
                {
                    row[columnName] = datePicker.Value.Date;
                }
            }
        }
    }
}
