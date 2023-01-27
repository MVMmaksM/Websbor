using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordRespondents.DataBase
{
    internal class SqlDataAdapterRespondents
    {
        public static SqlDataAdapter GetSqlDataAdapter()
        {
            var sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = CommandRespondent.CreateSqlCommandSelect();
            sqlDataAdapter.InsertCommand = CommandRespondent.CreateSqlCommandInsert();
            sqlDataAdapter.UpdateCommand = CommandRespondent.CreateSqlCommandUpdate();
            sqlDataAdapter.DeleteCommand = CommandRespondent.CreateSqlCommandDelete();

            return sqlDataAdapter;
        }
    }
}
