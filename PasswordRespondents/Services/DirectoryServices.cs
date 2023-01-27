using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordRespondents.Services
{
    internal class DirectoryServices
    {
        public static void CreateDirectory(string pathDirectory) 
        {
            if (!Directory.Exists(pathDirectory))
            {
                Directory.CreateDirectory(pathDirectory);   
            }
        }
    }
}
