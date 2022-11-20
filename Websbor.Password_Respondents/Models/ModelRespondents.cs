using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Password_Respondents.Models
{
    internal class ModelRespondents
    {
        private DataColumn _id;
        private DataColumn _nameResp;
        private DataColumn _okpoResp;
        private DataColumn _passwordResp;
        private DataColumn _dateCreate;
        private DataColumn _userCreate;
        private DataColumn _dateUpdate;
        private DataColumn _userUpdate;

        public DataColumn ID { get => _id; }
        public DataColumn NameResp { get => _nameResp; }
        public DataColumn OkpoResp { get => _okpoResp; }
        public DataColumn PasswordResp { get => _passwordResp; }
        public DataColumn DateCreate { get => _dateCreate; }
        public DataColumn UserCreate { get => _userCreate; }
        public DataColumn DateUpdate { get => _dateUpdate; }
        public DataColumn UserUpdate { get => _userUpdate; }
        public ModelRespondents()
        {
            _id = new DataColumn("id", typeof(int));            
            //_id.AllowDBNull = false;       при добавлении записи возможна ошибка, т.к. id возвращается из базы
            _nameResp = new DataColumn("nameResp", typeof(string));
            _okpoResp = new DataColumn("okpoResp", typeof(string));
            _passwordResp = new DataColumn("passwordResp", typeof(string));
            _dateCreate = new DataColumn("dateCreate", typeof(DateTime));
            _userCreate = new DataColumn("userCreate", typeof(string));
            _dateUpdate = new DataColumn("dateUpdate", typeof(DateTime));
            _userUpdate = new DataColumn("userUpdate", typeof(string));
        }
    }
}
