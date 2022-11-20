using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Password_Respondents.DataBaseServices
{
    internal class DataBaseWork
    {        
        private string _connectionString;
        private SqlDataAdapter _sqlDataAdapter;
        private SqlCommand _sqlCommandSelect;
        private SqlCommand _sqlCommandUpdate;
        private SqlCommand _sqlCommandInsert;
        private SqlCommand _sqlCommandDelete;
        private SqlCommand _sqlCommandSearch;
        public DataBaseWork(string connectionString)
        {
            _connectionString = connectionString;

            _sqlCommandSelect = new SqlCommand("sp_select_password");
            _sqlCommandSelect.CommandType = CommandType.StoredProcedure;
            _sqlCommandUpdate = new SqlCommand("sp_update_password");
            _sqlCommandUpdate.CommandType = CommandType.StoredProcedure;
            _sqlCommandUpdate.Parameters.Add(new SqlParameter("@id",  SqlDbType.Int, 0, "id").Direction = ParameterDirection.Input);
            _sqlCommandUpdate.Parameters.Add(new SqlParameter("@name_resp",  SqlDbType.NVarChar, 15, "nameResp").Direction = ParameterDirection.Input);
            _sqlCommandUpdate.Parameters.Add(new SqlParameter("@okpo_resp",  SqlDbType.NVarChar, 15, "okpoResp").Direction = ParameterDirection.Input);
            _sqlCommandUpdate.Parameters.Add(new SqlParameter("@password_resp",  SqlDbType.NVarChar, 10, "passwordResp").Direction = ParameterDirection.Input);
            _sqlCommandUpdate.Parameters.Add(new SqlParameter("@date_update",  SqlDbType.DateTime, 0, "dateUpdate").Direction = ParameterDirection.Output);
            _sqlCommandUpdate.Parameters.Add(new SqlParameter("@user_update",  SqlDbType.NVarChar, 10, "userUpdate").Direction= ParameterDirection.Output);

            _sqlCommandInsert = new SqlCommand("sp_insert_password");
            _sqlCommandInsert.CommandType = CommandType.StoredProcedure;
            _sqlCommandInsert.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "id").Direction= ParameterDirection.Output);
            _sqlCommandInsert.Parameters.Add(new SqlParameter("@name_resp", SqlDbType.NVarChar, 50, "nameResp").Direction= ParameterDirection.Input);

            
            _sqlDataAdapter = new SqlDataAdapter();
            _sqlDataAdapter.SelectCommand = _sqlCommandSelect;
        }

        public void GetDataDB(DataTable dataTablePasswordRespondents) 
        {
            using (SqlConnection sqlConnectionGetDB = new SqlConnection(_connectionString)) 
            {
               
            }
        }
    }
}
