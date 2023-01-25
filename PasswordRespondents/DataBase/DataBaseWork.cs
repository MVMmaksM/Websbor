using PasswordRespondents.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
