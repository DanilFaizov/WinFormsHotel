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

namespace WinFormsHotel.Helpers
{
    public partial class FormAdministratorReport : Form
    {
        private readonly DatabaseManager _db;
        public FormAdministratorReport(DatabaseManager db)
        {
            InitializeComponent();
            _db = db;

            _db.LoadTable(Constants.TableBooking.Name);
            _db.LoadTable(Constants.TableInvoice.Name);
            _db.LoadTable(Constants.TableStay.Name);
            _db.LoadTable(Constants.TableClient.Name);

            // Настройка гридов
            dataGridViewRevenue.DataSource = _db.ViewTable(Constants.TableInvoice.Name);
            dataGridViewClients.DataSource = _db.ViewTable(Constants.TableBooking.Name);
            _db.PrepareColumnsForBooking(dataGridViewClients);
        }

        private void buttonSortByDate_Click(object sender, EventArgs e)
        {
            var startDate = datePickerStart.Value.Date;
            var endDate = datePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("Дата окончания не может быть раньше даты начала");
                return;
            }

            // Получение прибыли за период
            var revenueData = _db.GetRevenueReport(startDate, endDate);
            dataGridViewRevenue.DataSource = revenueData.DefaultView;

            // Получение статистики клиентов
            var clientStats = _db.GetClientStatistics(startDate, endDate);
            dataGridViewClients.DataSource = clientStats.DefaultView;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            var bookingTable = _db.GetTable(Constants.TableBooking.Name);
            var sortedClients = bookingTable.AsEnumerable()
                .Where(r => (DateTime)r["start_date"] >= datePickerStart.Value.Date &&
                            (DateTime)r["end_date"] <= datePickerEnd.Value.Date)
                .OrderBy(r => r["start_date"])
                .CopyToDataTable();
            dataGridViewClients.DataSource = sortedClients.DefaultView;
        }
    }
}
