using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using WinFormsHotel;
using WinFormsHotel.Helpers;

namespace WinFormRelationManual
{
    public class DatabaseManager
    {
        protected Dictionary<Type, SqlDbType> _mapTypes =
            new Dictionary<Type, SqlDbType>
            {
                { typeof(int), SqlDbType.Int },
                { typeof(long), SqlDbType.BigInt },
                { typeof(string), SqlDbType.NVarChar },
                { typeof(decimal), SqlDbType.Decimal },
                { typeof(DateTime), SqlDbType.Date }
            };

        protected string _connectionString;
        protected DataSet _dataSet;
        protected SqlDataAdapter _dataAdapter;
        protected SqlConnection _sqlConnection;

        public DatabaseManager(string connection)
        {
            _connectionString = connection;
            _dataSet = new DataSet();
            _sqlConnection = new SqlConnection(connection);
            _dataAdapter = new SqlDataAdapter();
        }

        // Загрузка таблицы из БД
        public void LoadTable(string tableName)
        {
            try
            {
                // Проверяем, существует ли таблица в DataSet
                if (_dataSet.Tables.Contains(tableName))
                {
                    // Очищаем существующую таблицу
                    _dataSet.Tables[tableName].Rows.Clear();
                    _dataSet.Tables[tableName].Columns.Clear();
                }

                // Открываем соединение
                _sqlConnection.Open();

                // Создаём команду
                _dataAdapter.SelectCommand = new SqlCommand($"SELECT * FROM {tableName}", _sqlConnection);

                // Если таблица не существует, создаём новую
                var table = new DataTable(tableName);
                _dataAdapter.Fill(table);

                // Добавляем таблицу в DataSet
                if (!_dataSet.Tables.Contains(tableName))
                {
                    _dataSet.Tables.Add(table);
                }
                else
                {
                    // Или обновляем существующую (если нужно)
                    var existingTable = _dataSet.Tables[tableName];
                    existingTable.Merge(table); // Объединяем данные
                    existingTable.AcceptChanges();
                }

                _sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки таблицы: " + ex.Message);
            }
        }

        public void AddCalculatedColumn(string tableName,
            List<string> names)
        {
            var table = _dataSet.Tables[tableName];

            //добовляем вычисляемый столбец
            table.Columns.Add(new DataColumn(Constants.Calculated));

            //цикл - заполняем вычисляемый столбец 
            foreach (DataRow row in table.Rows)
            {
                string value = string
                    .Join("", names.Select(x => row[x]));
                row[Constants.Calculated] = value;
            }
        }

        // Получение таблицы для отображения
        public DataView ViewTable(string tableName)
        {
            return _dataSet.Tables[tableName]?.DefaultView;
        }

        // Фильтрация данных
        public DataView ViewFilter(string tableName, string filter)
        {
            var table = _dataSet.Tables[tableName];
            var view = table.DefaultView;
            view.RowFilter = filter;
            return view;
        }

        // Настройка грида
        public void SetGridProperties(DataGridView grid)
        {
            if (grid != null)
            {
                grid.AllowUserToDeleteRows = false;
                grid.AllowUserToAddRows = false;
                grid.ReadOnly = true;
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grid.MultiSelect = false;
            }
        }

        // Настройка грида для номеров
        public void PrepareColumnsForRoom(DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                switch (column.Name)
                {
                    case "id":
                    case "room_type_id":
                    case "status_id":
                    case "responsible_staff_id":
                        column.Visible = false;
                        break;
                    case "room_number":
                        column.HeaderText = "Номер";
                        break;
                    case "floor":
                        column.HeaderText = "Этаж";
                        break;
                    case "phone":
                        column.HeaderText = "Телефон";
                        break;
                }
            }
        }

        // Настройка грида для клиентов
        public void PrepareColumnsForClient(DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                switch (column.Name)
                {
                    case "id":
                        column.Visible = false;
                        break;
                    case "passport":
                        column.DisplayIndex = 4;
                        column.HeaderText = "Паспорт";
                        break;
                    case "first_name":
                        column.HeaderText = "Имя";
                        break;
                    case "last_name":
                        column.HeaderText = "Фамилия";
                        break;
                    case "middle_name":
                        column.HeaderText = "Отчество";
                        break;
                    case "city":
                        column.HeaderText = "Город";
                        break;
                    case "phone":
                        column.HeaderText = "Телефон";
                        break;

                }
            }
        }

        // Настройка грида для персонала
        public void PrepareColumnsForStaff(DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                switch (column.Name)
                {
                    case "id":
                        column.Visible = false;
                        break;
                    case "first_name":
                        column.HeaderText = "Имя";
                        break;
                    case "last_name":
                        column.HeaderText = "Фамилия";
                        break;
                    case "middle_name":
                        column.HeaderText = "Отчество";
                        break;
                    case "hire_date":
                        column.HeaderText = "Дата найма";
                        break;
                    case "dismissal_date":
                        column.HeaderText = "Дата увольнения";
                        break;
                }
            }
        }

        // Добавление новой строки
        public void AddNewRow(string tableName, List<Control> editFields)
        {
            var table = _dataSet.Tables[tableName];
            var row = table.NewRow();
            ComponentsHelper.CopyDataFromEditFields(editFields, row);
            table.Rows.Add(row);
        }

        public void AddNewRow(string tableName, Dictionary<string, object> data)
        {
            var table = _dataSet.Tables[tableName];
            var row = table.NewRow();
            foreach (var pair in data)
            {
                row[pair.Key] = pair.Value;
            }
            table.Rows.Add(row);
        }

        public void UpdateRow(string tableName, int rowIndex, Dictionary<string, object> data)
        {
            var table = _dataSet.Tables[tableName];
            var row = table.Rows[rowIndex];
            foreach (var pair in data)
            {
                row[pair.Key] = pair.Value;
            }
        }
        public bool IsRoomNumberExists(string roomNumber)
        {
            var table = _dataSet.Tables["room"];
            return table.Rows.Cast<DataRow>().Any(r => r["room_number"].ToString() == roomNumber);
        }

        // Обновление существующей строки
        public void UpdateRow(string tableName, int rowIndex, List<Control> editFields)
        {
            var table = _dataSet.Tables[tableName];
            var row = table.Rows[rowIndex];
            ComponentsHelper.CopyDataFromEditFields(editFields, row);
        }

        // Удаление строки
        public void DeleteRow(string tableName, int rowIndex)
        {
            var table = _dataSet.Tables[tableName];
            var row = table.Rows[rowIndex];
            row.Delete();
        }



        // Отправка изменений в БД
        public void SendTableToServer(string tableName, string idName)
        {
            try
            {
                var table = _dataSet.Tables[tableName];
                _sqlConnection.Open();
                _dataAdapter.InsertCommand = GetCommonInsertCommand(tableName, idName);
                _dataAdapter.DeleteCommand = GetCommonDeleteCommand(tableName, idName);
                _dataAdapter.UpdateCommand = GetCommonUpdateCommand(tableName, idName);
                _dataAdapter.Update(table);
                _sqlConnection.Close();

                if (tableName == Constants.TableStay.Name)
                {
                    LoadTable(Constants.TableStay.Name); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }

        // Отмена изменений
        public void CancelChanges(string tableName)
        {
            _dataSet.Tables[tableName]?.RejectChanges();
        }

        // Получение таблицы
        public DataTable GetTable(string tableName)
        {
            return _dataSet.Tables[tableName];
        }

        // Проверка уникальности паспорта клиента
        public bool IsPassportExists(string passport)
        {
            var table = _dataSet.Tables["client"];
            return table.Rows.Cast<DataRow>().Any(r => r["passport"].ToString() == passport);
        }
        //проверка на уникальнсть телефона
        public bool IsPhoneExists(string phone)
        {
            var staffTable = _dataSet.Tables["staff"];
            return staffTable.AsEnumerable().Any(r => r["phone"].ToString() == phone);
        }

        // Проверка занятости номера
        public bool IsRoomOccupied(int roomId, DateTime checkIn, DateTime checkOut)
        {
            var bookings = _dataSet.Tables["booking"];
            return bookings.AsEnumerable().Any(row =>
                (int)row["room_id"] == roomId &&
                (DateTime)row["start_date"] < checkOut &&
                (DateTime)row["end_date"] > checkIn);
        }

        // Получение списка колонок
        public List<DataColumn> GetTableColumns(string tableName, string idName)
        {
            var table = _dataSet.Tables[tableName];
            return table.Columns
                .OfType<DataColumn>()
                .Where(c => c.ColumnName != idName)
                .ToList();
        }

        // Формирование SQL-параметров
        private List<SqlParameter> GetCommonParameters(DataTable table, string idName)
        {
            var parameters = new List<SqlParameter>();
            var columns = GetTableColumns(table.TableName, idName);

            foreach (var c in columns)
            {
                var param = new SqlParameter
                {
                    ParameterName = "@" + c.ColumnName,
                    SourceColumn = c.ColumnName,
                    SqlDbType = GetSqlDbType(c),
                    Direction = ParameterDirection.Input
                };

                // Для строк задаем максимальную длину
                if (c.DataType == typeof(string) && c.ColumnName == "phone")
                    param.Size = 18;

                parameters.Add(param);
            }

            return parameters;
        }

        // Определение типа SQL
        private SqlDbType GetSqlDbType(DataColumn column)
        {
            if (IsDateColumn(column))
                return SqlDbType.Date;

            return _mapTypes.TryGetValue(column.DataType, out var sqlDbType)
                ? sqlDbType
                : throw new ArgumentException($"Тип данных {column.DataType} не поддерживается");
        }

        // Проверка даты
        private bool IsDateColumn(DataColumn column)
        {
            var dateColumns = new HashSet<string> {
                "start_date", "end_date", "payment_date", "hire_date", "actual_check_in", "actual_check_out"
            };
            return column.DataType == typeof(DateTime) && dateColumns.Contains(column.ColumnName);
        }

        // Формирование команды вставки
        private SqlCommand GetCommonInsertCommand(string tableName, string idName)
        {
            var table = _dataSet.Tables[tableName];
            var columnNames = GetCommonColumnNames(table, idName);
            string commandText = $"INSERT INTO {tableName} ({string.Join(", ", columnNames)}) ";
            commandText += $"VALUES ({string.Join(", ", columnNames.Select(c => "@" + c))}) ";
            commandText += "SELECT @id = SCOPE_IDENTITY()";

            var insertCommand = new SqlCommand(commandText, _sqlConnection);
            var parameters = GetCommonParameters(table, idName);
            insertCommand.Parameters.AddRange(parameters.ToArray());
            insertCommand.Parameters.Add(GetCommonIdParameter(idName, ParameterDirection.Output));
            return insertCommand;
        }

        // Формирование команды обновления
        private SqlCommand GetCommonUpdateCommand(string tableName, string idName)
        {
            var table = _dataSet.Tables[tableName];
            var columnNames = GetCommonColumnNames(table, idName);
            string commandText = $"UPDATE {tableName} SET ";
            commandText += string.Join(", ", columnNames.Select(s => $"{s} = @{s}"));
            commandText += $" WHERE {idName} = @id";

            var updateCommand = new SqlCommand(commandText, _sqlConnection);
            var parameters = GetCommonParameters(table, idName);
            updateCommand.Parameters.AddRange(parameters.ToArray());
            updateCommand.Parameters.Add(GetCommonIdParameter(idName, ParameterDirection.Input));
            return updateCommand;
        }

        // Формирование команды удаления
        private SqlCommand GetCommonDeleteCommand(string tableName, string idName)
        {
            var deleteCommand = new SqlCommand($"DELETE FROM {tableName} WHERE {idName} = @id", _sqlConnection);
            deleteCommand.Parameters.Add(GetCommonIdParameter(idName, ParameterDirection.Input));
            return deleteCommand;
        }

        // Получение ID-параметра
        private SqlParameter GetCommonIdParameter(string idName, ParameterDirection direction)
        {
            return new SqlParameter
            {
                ParameterName = "@id",
                SourceColumn = idName,
                SqlDbType = SqlDbType.Int,
                Direction = direction
            };
        }

        // Получение имен колонок
        public List<string> GetCommonColumnNames(DataTable table, string idName)
        {
            return table.Columns
                .OfType<DataColumn>()
                .Where(c => c.ColumnName != idName)
                .Select(c => c.ColumnName)
                .ToList();
        }

        // Проверка даты увольнения
        public bool IsValidDismissalDate(DateTime hireDate, DateTime? dismissalDate)
        {
            return dismissalDate == null || dismissalDate >= hireDate;
        }

        // Проверка формата телефона
        public bool IsValidPhone(string phone)
        {
            return phone.Length <= 18; // Пока без регулярного выражения
        }

        public int? GetLastInsertedId(string tableName)
        {
            var table = _dataSet.Tables[tableName];
            if (table == null || !table.AsEnumerable().Any())
                return null;

            return table.AsEnumerable()
                .Select(r => r.Field<int?>("id"))
                .Max();
        }


        public bool IsStayExists(int bookingId)
        {
            var stayTable = _dataSet.Tables["stay"];
            return stayTable.AsEnumerable()
                .Any(r => (int)r["booking_id"] == bookingId);
        }
        public void PrepareColumnsForBooking(DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                switch (column.Name)
                {
                    case "id":
                        column.Visible = false;
                        break;
                    case "start_date":
                        column.HeaderText = "Дата заезда";
                        break;
                    case "end_date":
                        column.HeaderText = "Дата выезда";
                        break;
                    case "status":
                        column.HeaderText = "Статус";
                        break;
                }
            }
        }
        public DataTable GetRevenueReport(DateTime startDate, DateTime endDate)
        {
            var invoiceTable = _dataSet.Tables["invoice"];
            var filteredInvoices = invoiceTable.AsEnumerable()
                .Where(r => (DateTime)r["payment_date"] >= startDate &&
                            (DateTime)r["payment_date"] <= endDate)
                .ToList();

            var reportTable = new DataTable("RevenueReport");
            reportTable.Columns.Add("total_income", typeof(decimal));
            reportTable.Columns.Add("total_clients", typeof(int));

            var totalIncome = filteredInvoices.Sum(r => (decimal)r["total_amount"]);
            var totalClients = filteredInvoices.Select(r => (int)r["stay_id"])
                .Distinct()
                .Count();

            reportTable.Rows.Add(totalIncome, totalClients);
            return reportTable;
        }
        public DataTable GetClientStatistics(DateTime startDate, DateTime endDate)
        {
            var bookingTable = _dataSet.Tables["booking"];
            var stayTable = _dataSet.Tables["stay"];
            var invoiceTable = _dataSet.Tables["invoice"];
            var clientTable = _dataSet.Tables["client"];

            // Фильтрация броней по дате
            var filteredBookings = bookingTable.AsEnumerable()
                .Where(r => (DateTime)r["start_date"] >= startDate &&
                            (DateTime)r["end_date"] <= endDate);

            // Объединение booking → stay → invoice
            var query = from booking in filteredBookings
                        join stay in stayTable.AsEnumerable()
                          on (int)booking["id"] equals (int)stay["booking_id"]
                        join invoice in invoiceTable.AsEnumerable()
                          on (int)stay["id"] equals (int)invoice["stay_id"]
                        select new
                        {
                            ClientId = (int)booking["client_id"],
                            FullName = $"{clientTable.AsEnumerable()
                                .FirstOrDefault(c => (int)c["id"] == (int)booking["client_id"])?["first_name"] ?? ""} " +
                                $"{clientTable.AsEnumerable()
                                .FirstOrDefault(c => (int)c["id"] == (int)booking["client_id"])?["last_name"] ?? ""}",
                            TotalSpent = (decimal)invoice["total_amount"]
                        };

            // Группировка по клиенту
            var grouped = query
                .GroupBy(x => new { x.ClientId, x.FullName })
                .Select(g => new
                {
                    g.Key.ClientId,
                    g.Key.FullName,
                    BookingsCount = g.Count(),
                    TotalSpent = g.Sum(x => x.TotalSpent)
                });

            // Создание результирующей таблицы
            var clientStats = new DataTable("ClientStatistics");
            clientStats.Columns.Add("client_id", typeof(int));
            clientStats.Columns.Add("full_name", typeof(string));
            clientStats.Columns.Add("bookings_count", typeof(int));
            clientStats.Columns.Add("total_spent", typeof(decimal));

            foreach (var group in grouped)
            {
                clientStats.Rows.Add(
                    group.ClientId,
                    group.FullName,
                    group.BookingsCount,
                    group.TotalSpent
                );
            }

            return clientStats;
        }
    }
}