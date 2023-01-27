using PasswordRespondents.Model;
using PasswordRespondents.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PasswordRespondents.DataBase
{
    internal class DataBaseWork
    {
        private SqlDataAdapter _sqlDataAdapter;
        public string ConnectionString { get; }
        public DataTable DataTableWork { get; }
        public DataBaseWork(string connectionString, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            ConnectionString = connectionString;
            DataTableWork = dataTable;
            _sqlDataAdapter = sqlDataAdapter;
            _sqlDataAdapter.RowUpdated += SqlDataAdapter_RowUpdated;
        }

        private void SqlDataAdapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if ((e.Status == UpdateStatus.ErrorsOccurred) && (e.Errors?.GetType() == typeof(DBConcurrencyException)))
            {
                if (MessageBox.Show($"Обновляемая запись: ОКПО: {e.Row["okpo_resp"]} отсутствует в БД, возможно была удалена другим пользователем." +
                    $"\nДобавить запись в БД?", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                {
                    e.Status = UpdateStatus.Continue;

                    var res = DataTableWork.Select($"id={e.Row["id"]}");

                    DataTableWork.AcceptChanges();

                    res[0].SetAdded();

                    try
                    {
                       int resultInsert = _sqlDataAdapter.Update(DataTableWork);

                        MessageBox.Show($"Добавлено записей: {resultInsert}");
                    }
                    catch (Exception)
                    {
                       
                    }
                }
            }
        }

        public void GetShemaTable()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                _sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                _sqlDataAdapter.FillSchema(DataTableWork, SchemaType.Source);
            }
        }
        public void FillToDataTable()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                _sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                _sqlDataAdapter.Fill(DataTableWork);
            }
        }

        public void UpdateDataTable()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                _sqlDataAdapter.InsertCommand.Connection = sqlConnection;
                _sqlDataAdapter.UpdateCommand.Connection = sqlConnection;
                _sqlDataAdapter.DeleteCommand.Connection = sqlConnection;
                _sqlDataAdapter.Update(DataTableWork);
            }
        }
        public void LoadInDatatable(DataTable dataTableLoad)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                _sqlDataAdapter.InsertCommand.Connection = sqlConnection;
                _sqlDataAdapter.Update(dataTableLoad);
            }
        }

        public void Search(string nameResp, string okpoResp)
        {
            if (!string.IsNullOrWhiteSpace(nameResp) && !string.IsNullOrWhiteSpace(okpoResp))
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    SqlCommand sqlCommandSearch = new SqlCommand("sp_search_password_okpo_name", sqlConnection);
                    sqlCommandSearch.CommandType = CommandType.StoredProcedure;
                    sqlCommandSearch.Parameters.Add(new SqlParameter("@name_resp", nameResp) { Direction = ParameterDirection.Input });
                    sqlCommandSearch.Parameters.Add(new SqlParameter("@okpo_resp", okpoResp) { Direction = ParameterDirection.Input });

                    DataTableWork.Clear();

                    new SqlDataAdapter(sqlCommandSearch).Fill(DataTableWork);
                }
            }
            else if (!string.IsNullOrWhiteSpace(nameResp))
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    SqlCommand sqlCommandSearch = new SqlCommand("sp_search_password_name", sqlConnection);
                    sqlCommandSearch.CommandType = CommandType.StoredProcedure;
                    sqlCommandSearch.Parameters.Add(new SqlParameter("@name_resp", nameResp) { Direction = ParameterDirection.Input });

                    DataTableWork.Clear();

                    new SqlDataAdapter(sqlCommandSearch).Fill(DataTableWork);
                }
            }
            else if (!string.IsNullOrWhiteSpace(okpoResp))
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    SqlCommand sqlCommandSearch = new SqlCommand("sp_search_password_okpo", sqlConnection);
                    sqlCommandSearch.CommandType = CommandType.StoredProcedure;
                    sqlCommandSearch.Parameters.Add(new SqlParameter("@okpo_resp", okpoResp) { Direction = ParameterDirection.Input });

                    DataTableWork.Clear();

                    new SqlDataAdapter(sqlCommandSearch).Fill(DataTableWork);
                }
            }
        }

        public DataTable GetAllRowsForSave()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommandGetAll = new SqlCommand("sp_get_all_rows_for_save", sqlConnection);
                sqlCommandGetAll.CommandType = CommandType.StoredProcedure;

                new SqlDataAdapter(sqlCommandGetAll).Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable GetDataTableForCurrentSave()
        {
            DataTable dataTable = DataTableWork.Copy();
            dataTable.PrimaryKey = null;
            dataTable.Columns.Remove("id");

            return dataTable;
        }

        public (int countUpdate, int countHasError) LoadFromDataTable(DataTable dataTableFromExcel, string pathProtocolResult)
        {
            int countRowUpdate = default;
            int countRowHasError = default;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                SqlCommand sqlCommandInsert = new SqlCommand("sp_insert_from_excel", sqlConnection);
                sqlCommandInsert.CommandType = CommandType.StoredProcedure;
                sqlCommandInsert.Parameters.Add(new SqlParameter("@name_resp", SqlDbType.NVarChar, 50, "name_resp") { Direction = ParameterDirection.Input });
                sqlCommandInsert.Parameters.Add(new SqlParameter("@okpo_resp", SqlDbType.NVarChar, 15, "okpo_Resp") { Direction = ParameterDirection.Input });
                sqlCommandInsert.Parameters.Add(new SqlParameter("@password_resp", SqlDbType.NVarChar, 15, "password_resp") { Direction = ParameterDirection.Input });
                sqlCommandInsert.Parameters.Add(new SqlParameter("@comment", SqlDbType.NVarChar, 100, "comment") { Direction = ParameterDirection.Input });
                sqlCommandInsert.Parameters.Add(new SqlParameter("@date_create", string.Empty) { Direction = ParameterDirection.Input });
                sqlCommandInsert.Parameters.Add(new SqlParameter("@user_create", string.Empty) { Direction = ParameterDirection.Input });

                SqlDataAdapter sqlDataAdapterLoadFromDataTable = new SqlDataAdapter();
                sqlDataAdapterLoadFromDataTable.InsertCommand = sqlCommandInsert;
                sqlDataAdapterLoadFromDataTable.ContinueUpdateOnError = true;

                countRowUpdate = sqlDataAdapterLoadFromDataTable.Update(dataTableFromExcel);

                if (dataTableFromExcel.HasErrors)
                {
                    ICollection<string> updateErrors = GetErrorsUpdate(dataTableFromExcel);
                    countRowHasError = updateErrors.Count;

                    FileServices.SaveFile(pathProtocolResult, updateErrors);
                }
            }

            var resultUpdate = (countUpdate: countRowUpdate, countHasError: countRowHasError);

            return resultUpdate;
        }

        private ICollection<string> GetErrorsUpdate(DataTable dataTableErrors)
        {
            ICollection<string> updateErrors = new List<string>();

            foreach (DataRow row in dataTableErrors.Rows)
            {
                if (row.HasErrors)
                {
                    updateErrors.Add($"{row["okpo_resp"]}: {row.RowError}");
                }
            }

            return updateErrors;
        }
    }
}
