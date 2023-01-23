using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordRespondents.Model
{
    internal class Respondent
    {
        private DataColumn _id;
        private DataColumn _nameResp;
        private DataColumn _okpoResp;
        private DataColumn _passwordResp;
        private DataColumn _dateCreate;
        private DataColumn _userCreate;
        private DataColumn _dateUpdate;
        private DataColumn _userUpdate;
        private DataColumn _comment;
        private DataColumn[] _columns;
        public Respondent()
        {
            _id = new DataColumn("id", typeof(int));
            _nameResp = new DataColumn("name_resp", typeof(string));
            _okpoResp = new DataColumn("okpo_resp", typeof(string));
            _passwordResp = new DataColumn("password_resp", typeof(string));
            _dateCreate = new DataColumn("date_create", typeof(DateTime));
            _userCreate = new DataColumn("user_create", typeof(string));
            _dateUpdate = new DataColumn("date_update", typeof(DateTime));
            _userUpdate = new DataColumn("user_update", typeof(string));
            _comment = new DataColumn("comment", typeof(string));
            _columns = new DataColumn[9] { _id, _nameResp,_okpoResp, _passwordResp, _dateCreate, _userCreate,
            _dateUpdate, _userUpdate, _comment};
        }

        public DataTable GetDataTableRespondent()
        {
            DataTable dataTableRespondents = new();
            dataTableRespondents.Columns.AddRange(_columns);

            return dataTableRespondents;
        }
    }
}
