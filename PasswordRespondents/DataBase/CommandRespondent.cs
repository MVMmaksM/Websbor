﻿using PasswordRespondents.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordRespondents.DataBase
{
    internal class CommandRespondent
    {
        public static SqlCommand CreateSqlCommandSelect() => new SqlCommand("sp_select_password") { CommandType = CommandType.StoredProcedure };
        public static SqlCommand CreateSqlCommandUpdate()
        {
            SqlCommand sqlCommandUpdate = new SqlCommand("sp_update_password");
            sqlCommandUpdate.CommandType = CommandType.StoredProcedure;
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "id") { Direction = ParameterDirection.Input });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@name_resp", SqlDbType.NVarChar, 15, "name_resp") { Direction = ParameterDirection.Input });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@okpo_resp", SqlDbType.NVarChar, 15, "okpo_resp") { Direction = ParameterDirection.Input });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@password_resp", SqlDbType.NVarChar, 15, "password_resp") { Direction = ParameterDirection.Input });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@date_update", SqlDbType.DateTime, 0, "date_update") { Direction = ParameterDirection.Output });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@user_update", SqlDbType.NVarChar, 20, "user_update") { Direction = ParameterDirection.Output });
            sqlCommandUpdate.Parameters.Add(new SqlParameter("@comment", SqlDbType.NVarChar, 20, "comment") { Direction = ParameterDirection.Input });

            return sqlCommandUpdate;
        }
        public static SqlCommand CreateSqlCommandInsert()
        {
            SqlCommand sqlCommandInsert = new SqlCommand("sp_insert_password");
            sqlCommandInsert.CommandType = CommandType.StoredProcedure;
            sqlCommandInsert.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "id") { Direction = ParameterDirection.Output });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@name_resp", SqlDbType.NVarChar, 50, "name_resp") { Direction = ParameterDirection.Input });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@okpo_resp", SqlDbType.NVarChar, 15, "okpo_Resp") { Direction = ParameterDirection.Input });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@password_resp", SqlDbType.NVarChar, 15, "password_resp") { Direction = ParameterDirection.Input });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@date_create", SqlDbType.DateTime, 0, "date_create") { Direction = ParameterDirection.Output });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@user_create", SqlDbType.NVarChar, 20, "user_create") { Direction = ParameterDirection.Output });
            sqlCommandInsert.Parameters.Add(new SqlParameter("@comment", SqlDbType.NVarChar, 20, "comment") { Direction = ParameterDirection.Input });

            return sqlCommandInsert;
        }
        public static SqlCommand CreateSqlCommandDelete()
        {
            SqlCommand sqlCommandDelete = new SqlCommand("sp_delete_password");
            sqlCommandDelete.CommandType = CommandType.StoredProcedure;
            sqlCommandDelete.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "id") { Direction = ParameterDirection.Input });

            return sqlCommandDelete;
        }
    }
}
