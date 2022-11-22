using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.Password_Respondents.ViewModel;

namespace Websbor.Password_Respondents.DataBaseServices
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
                sqlDataAdapter.Fill(dataTable);
            }
        }

        public void ExecDataAdapterUpdateToDataTable(DataTable dataTable, SqlDataAdapter sqlDataAdapter) 
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString)) 
            {
                sqlDataAdapter.Update(dataTable);
            }          
        }       
    }
}
