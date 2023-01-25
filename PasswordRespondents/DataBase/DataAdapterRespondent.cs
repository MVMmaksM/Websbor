using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordRespondents.DataBase
{
    internal class DataAdapterRespondent
    {
        public SqlDataAdapter GetSqlDataAdapterRespondent()
        {
            var sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = CreateSqlCommandSelect();
            sqlDataAdapter.InsertCommand = CreateSqlCommandInsert();
            sqlDataAdapter.UpdateCommand = CreateSqlCommandUpdate();
            sqlDataAdapter.DeleteCommand = CreateSqlCommandDelete();

            return sqlDataAdapter;
        }

        private SqlCommand CreateSqlCommandSelect() => new SqlCommand("sp_select_password") { CommandType = CommandType.StoredProcedure };
        private SqlCommand CreateSqlCommandUpdate()
        {
            SqlCommand sqlCommandUpdate = new SqlCommand("sp_update_password");
            sqlCommandUpdate.CommandType = CommandType.StoredProcedure;
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "id") { Direction = ParameterDirection.Input });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@name_resp", SqlDbType.NVarChar, 15, "name_resp") { Direction = ParameterDirection.Input });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@okpo_resp", SqlDbType.NVarChar, 15, "okpo_resp") { Direction = ParameterDirection.Input });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@password_resp", SqlDbType.NVarChar, 15, "password_resp") { Direction = ParameterDirection.Input });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@date_update", SqlDbType.DateTime, 0, "date_update") { Direction = ParameterDirection.Output });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@user_update", SqlDbType.NVarChar, 20, "user_update") { Direction = ParameterDirection.Output });

            return sqlCommandUpdate;
        }
        private SqlCommand CreateSqlCommandInsert()
        {
            SqlCommand sqlCommandInsert = new SqlCommand("sp_insert_password");
            sqlCommandInsert.CommandType = CommandType.StoredProcedure;
            sqlCommandInsert.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "id") { Direction = ParameterDirection.Output });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@name_resp", SqlDbType.NVarChar, 50, "name_resp") { Direction = ParameterDirection.Input });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@okpo_resp", SqlDbType.NVarChar, 15, "okpo_Resp") { Direction = ParameterDirection.Input });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@password_resp", SqlDbType.NVarChar, 15, "password_resp") { Direction = ParameterDirection.Input });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@date_create", SqlDbType.DateTime, 0, "date_create") { Direction = ParameterDirection.Output });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@user_create", SqlDbType.NVarChar, 20, "user_create") { Direction = ParameterDirection.Output });

            return sqlCommandInsert;
        }
        private SqlCommand CreateSqlCommandDelete()
        {
            SqlCommand sqlCommandDelete = new SqlCommand("sp_delete_password");
            sqlCommandDelete.CommandType = CommandType.StoredProcedure;
            sqlCommandDelete.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "id") { Direction = ParameterDirection.Input });
           
            return sqlCommandDelete;
        }       
    }
}
