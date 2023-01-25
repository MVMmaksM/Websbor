using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordRespondents.Services
{
    internal class FileServices
    {
        public static async void SaveFaile(string fullNameFile, byte[] bytesFile)
        {
           await File.WriteAllBytesAsync(fullNameFile, bytesFile);
        }

    }
}
