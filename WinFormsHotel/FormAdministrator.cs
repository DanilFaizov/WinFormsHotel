using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class FormAdministrator : Form
    {

        private List<Control> _editFields;
        private readonly DatabaseManager _db;
        private readonly string _tableName;
        private readonly string _idName;
        private DataGridViewRow _selectedRow;

        public FormAdministrator()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager
                .ConnectionStrings["hotelConnectionString"]
                .ToString();

            _db = new DatabaseManager(connectionString);

            _db.LoadTable(Constants.TableClient.Name);
            _db.LoadTable(Constants.TableStaff.Name);
        }

        private void buttonEditEmployee_Click(object sender, EventArgs e)
        {
            var formEdit = new FormEditEmployee(
                    _db
                    //Constants.TableStaff.Name,
                    //Constants.TableStaff.Id
                );
            formEdit.ShowDialog();
        }

        private void buttonEditRoom_Click(object sender, EventArgs e)
        {
            // Загрузка таблицы room, если еще не загружена
            if (_db.GetTable(Constants.TableRoom.Name) == null)
                _db.LoadTable(Constants.TableRoom.Name);
            _db.LoadTable("room_type");
            _db.LoadTable("room_status");
            _db.LoadTable("staff");
            _db.LoadTable("room");

            // Открытие формы редактирования номера
            var form = new FormEditRoom(
                    _db,
                    Constants.TableRoom.Name,
                    Constants.TableRoom.Id);

            form.ShowDialog();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            var reportForm = new FormAdministratorReport(_db);
            reportForm.Show(); // Открытие формы
        }
    }
}
