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
        public string ConnectionString { get;}
        public DataTable DataTableWork { get;}
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
    }
}
