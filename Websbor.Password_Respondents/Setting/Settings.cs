using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.PasswordRespondents.ViewModel;

namespace Websbor.PasswordRespondents.Setting
{
    internal class Settings : IConnectionString
    {
        public string ConnectionString { get; set; }
    }
}
