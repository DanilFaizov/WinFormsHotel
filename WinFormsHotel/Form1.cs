using System.Configuration;
using WinFormRelationManual;

namespace WinFormsHotel
{
    public partial class Form1 : Form
    {
        private DatabaseManager _db;
        public Form1()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager
                .ConnectionStrings["hotelConnectionString"]
                .ToString();
            _db = new DatabaseManager(connectionString);

            buttonAdminisrator.Enabled = false;
            buttonClient.Enabled = false;
            buttonEmployee.Enabled = false;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                _db.LoadTable(Constants.TableRoom.Name);
                _db.LoadTable(Constants.TableClient.Name);
                _db.LoadTable(Constants.TableStaff.Name);
                _db.LoadTable(Constants.TableBooking.Name);
                _db.LoadTable(Constants.TableInvoice.Name);

                buttonLoad.Enabled = false;
                buttonClient.Enabled = true;
                buttonAdminisrator.Enabled = true;
                buttonEmployee.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void ButtonEmployee_Click(object sender, EventArgs e)
        {
            var formEdit = new FormEmployeeTwo(
                _db
                //Constants.TableStaff.Name,
                //Constants.TableStaff.Id
            );

            formEdit.ShowDialog();
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            var formEdit = new FormClient(
                _db,
                Constants.TableClient.Name,
                Constants.TableClient.Id
            );
            formEdit.ShowDialog();
        }

        private void buttonAdminisrator_Click(object sender, EventArgs e)
        {
            var formEdit = new FormAdministrator();
            formEdit.ShowDialog();
        }
    }
}
