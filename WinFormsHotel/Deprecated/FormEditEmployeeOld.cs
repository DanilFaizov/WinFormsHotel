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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using WinFormsHotel.Helpers;

namespace WinFormsHotel
{
    public partial class FormEditEmployeeOld : Form
    {
        private List<Control> _editFields;
        private readonly DatabaseManager _db;
        private readonly string _tableName;
        private readonly string _idName;
        private DataGridViewRow _selectedRow;

        public FormEditEmployeeOld(DatabaseManager db, string tableName, string idName)
        {
            InitializeComponent();
            _db = db;
            _tableName = tableName;
            _idName = idName;
            if (_db.GetTable(_tableName) == null)
                _db.LoadTable(_tableName);

            _editFields = ComponentsHelper.CreateEditFields(groupBox1, _db.GetTableColumns(_tableName, _idName));
            dataGridView1.DataSource = _db.ViewTable(_tableName);
            _db.SetGridProperties(dataGridView1);
            _db.PrepareColumnsForStaff(dataGridView1);
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            var selectedRow = dataGridView1.SelectedRows[0];
            var staffId = selectedRow.Cells["id"].Value.ToString();

            if (!string.IsNullOrEmpty(staffId))
            {
                var table = _db.GetTable(_tableName);
                var row = table.Rows.Cast<DataRow>().FirstOrDefault(r => r["id"].ToString() == staffId);

                if (row != null)
                    ComponentsHelper.CopyDataToEditFields(row, _editFields);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите служащего для редактирования");
                return;
            }

            var dismissalField = _editFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.DismissalDate);
            var hireField = _editFields.FirstOrDefault(c => c.Tag?.ToString() == Constants.TableStaff.HireDate);

            if (hireField is DateTimePicker hirePicker && dismissalField is DateTimePicker dismissPicker)
            {
                if (dismissPicker.Value.Date < hirePicker.Value.Date)
                {
                    MessageBox.Show("Дата увольнения не может быть раньше даты найма");
                    return;
                }
            }

            _db.UpdateRow(_tableName, dataGridView1.SelectedRows[0].Index, _editFields);
            MessageBox.Show("Данные обновлены");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите служащего для удаления");
                return;
            }

            _db.DeleteRow(_tableName, dataGridView1.SelectedRows[0].Index);
            MessageBox.Show("Служащий уволен");
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
