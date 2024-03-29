﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.PasswordRespondents.DataBaseServices
{
    internal class SqlDataAdapterPasswordRespondents
    {
        public readonly SqlDataAdapter sqlDataAdapter;
        public SqlDataAdapterPasswordRespondents()
        {
            sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = GetSqlCommandSelect();
            sqlDataAdapter.InsertCommand = GetSqlCommandInsert();
            sqlDataAdapter.UpdateCommand = GetSqlCommandUpdate();
            sqlDataAdapter.DeleteCommand = GetSqlCommandDelete();
        }

        private SqlCommand GetSqlCommandSelect() => new SqlCommand("sp_select_password") { CommandType = CommandType.StoredProcedure };
        private SqlCommand GetSqlCommandUpdate()
        {
            SqlCommand sqlCommandUpdate = new SqlCommand("sp_update_password");
            sqlCommandUpdate.CommandType = CommandType.StoredProcedure;
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "id") { Direction = ParameterDirection.Input });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@name_resp", SqlDbType.NVarChar, 15, "name_resp") { Direction = ParameterDirection.Input });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@okpo_resp", SqlDbType.NVarChar, 15, "okpo_resp") { Direction = ParameterDirection.Input });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@password_resp", SqlDbType.NVarChar, 10, "password_resp") { Direction = ParameterDirection.Input });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@date_update", SqlDbType.DateTime, 0, "date_update") { Direction = ParameterDirection.Output });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@user_update", SqlDbType.NVarChar, 10, "user_update") { Direction = ParameterDirection.Output });

            return sqlCommandUpdate;
        }
        private SqlCommand GetSqlCommandInsert()
        {
            SqlCommand sqlCommandInsert = new SqlCommand("sp_insert_password");
            sqlCommandInsert.CommandType = CommandType.StoredProcedure;
            sqlCommandInsert.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "id") { Direction = ParameterDirection.Output });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@name_resp", SqlDbType.NVarChar, 50, "name_resp") { Direction = ParameterDirection.Input });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@okpo_resp", SqlDbType.NVarChar, 15, "okpo_Resp") { Direction = ParameterDirection.Input });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@password_resp", SqlDbType.NVarChar, 10, "password_resp") { Direction = ParameterDirection.Input });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@date_create", SqlDbType.DateTime, 0, "date_create") { Direction = ParameterDirection.Output });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@user_create", SqlDbType.NVarChar, 10, "user_create") { Direction = ParameterDirection.Output });

            return sqlCommandInsert;
        }
        private SqlCommand GetSqlCommandDelete()
        {
            SqlCommand sqlCommandDelete = new SqlCommand("sp_delete_password");
            sqlCommandDelete.CommandType = CommandType.StoredProcedure;
            sqlCommandDelete.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "id") { Direction = ParameterDirection.Input });
            return sqlCommandDelete;
        }
        private SqlCommand GetSqlCommandSearch(string searchNameTextBoxInput, string searchOkpoTextBoxInput)
        {
            SqlCommand sqlCommandSearch = new SqlCommand("sp_search_password");
            sqlCommandSearch.CommandType = CommandType.StoredProcedure;
            sqlCommandSearch.Parameters.Add(new SqlParameter("@name_resp", SqlDbType.NVarChar, 50, searchNameTextBoxInput) { Direction = ParameterDirection.Input });
            sqlCommandSearch.Parameters.Add(new SqlParameter("@okpo_resp", SqlDbType.NVarChar, 50, searchOkpoTextBoxInput) { Direction = ParameterDirection.Input });
            return sqlCommandSearch;
        }
    }
}
