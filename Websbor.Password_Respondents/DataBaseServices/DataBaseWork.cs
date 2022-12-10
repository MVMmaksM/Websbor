using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.PasswordRespondents.ViewModel;

namespace Websbor.PasswordRespondents.DataBaseServices
{
    internal class DataBaseWork
    {
        private string _connectionString;
     
        
        public DataBaseWork(IConnectionString connectionString)
        {
            _connectionString = connectionString.ConnectionString;                  
        }

        public void ExecDataAdapterFillToDataTable(DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlDataAdapter.SelectCommand.Connection= sqlConnection;
                sqlDataAdapter.Fill(dataTable);
            }
        }

        public void ExecDataAdapterUpdateToDataTable(DataTable dataTable, SqlDataAdapter sqlDataAdapter) 
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString)) 
            {
                sqlDataAdapter.UpdateCommand.Connection = sqlConnection;
                sqlDataAdapter.InsertCommand.Connection= sqlConnection;
                sqlDataAdapter.DeleteCommand.Connection = sqlConnection;                
                sqlDataAdapter.Update(dataTable);
            }          
        }       
    }
}
