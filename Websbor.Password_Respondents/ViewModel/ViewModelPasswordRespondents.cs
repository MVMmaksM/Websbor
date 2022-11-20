using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.PasswordRespondents.Models;

namespace Websbor.PasswordRespondents.ViewModel
{
    internal class ViewModelPasswordRespondents
    {
        private DataTable _dtPasswordRespondents;
        private ModelRespondents _modelRespondents;
        public DataTable DTPasswordRespondents { get => _dtPasswordRespondents; set => _dtPasswordRespondents = value; }
        public ViewModelPasswordRespondents()
        {
            _modelRespondents = new ModelRespondents();
            _dtPasswordRespondents = new DataTable();
            _dtPasswordRespondents.Columns.AddRange(_modelRespondents.ModelDataColumn);            
        }
    }
}
