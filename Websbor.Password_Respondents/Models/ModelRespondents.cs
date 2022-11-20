using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.PasswordRespondents.Models
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
        private DataColumn[] _modelDataColumn;
        public DataColumn [] ModelDataColumn { get => _modelDataColumn;}        
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
            
            _modelDataColumn = new DataColumn[8] { _id, _nameResp,_okpoResp, _passwordResp, _dateCreate, _userCreate,
            _dateUpdate, _userUpdate};            
        }
    }
}
