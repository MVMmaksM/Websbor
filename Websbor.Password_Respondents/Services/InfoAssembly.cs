using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Websbor.PasswordRespondents;

namespace Websbor.Password_Respondents.Services
{
    internal class InfoAssembly
    {
        public static string GetInfoAssmbly() 
        {
            var assemblyInfo = Assembly.GetExecutingAssembly();
            string name = assemblyInfo.GetName().Name.ToString();
            Version version = assemblyInfo.GetName().Version;

            return $"{name} ver.{version.Major}.{version.Minor} build[{version.Build}]";
        }
    }
}
