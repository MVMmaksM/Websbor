using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordRespondents.Services
{
    internal class FileServices
    {
        public static async void SaveFile(string fullNameFile, byte[] bytesFile)
        {
            await File.WriteAllBytesAsync(fullNameFile, bytesFile);
        }

        public static async void SaveFile(string fullNameFile, ICollection<string> collection)
        {
            using (StreamWriter strWriter = new StreamWriter(fullNameFile, false))
            {
                foreach (var str in collection)
                {
                    await strWriter.WriteLineAsync(str);
                }
            }
        }

        public static DataTable ConvertExcelToDataTable(ExcelWorksheet sheet)
        {
            DataTable dataTableRespondents = new DataTable();

            dataTableRespondents.Columns.AddRange(new DataColumn[4]
            { new DataColumn("name_resp", typeof(string)),
            new DataColumn("okpo_resp", typeof(string)),
            new DataColumn ("password_resp", typeof(string)),
            new DataColumn("comment", typeof(string))
            });

            try
            {
                if (sheet.Dimension == null)
                {
                    return dataTableRespondents;
                }

                for (int i = 2; i <= sheet.Dimension.End.Row; i++)
                {
                    var row = sheet.Cells[i, 1, i, sheet.Dimension.End.Column];
                    DataRow newRow = dataTableRespondents.NewRow();

                    foreach (var cell in row)
                    {
                        newRow[cell.Start.Column - 1] = cell.Text.Trim();
                    }

                    if (!string.IsNullOrWhiteSpace(newRow["name_resp"].ToString()) && !string.IsNullOrWhiteSpace(newRow["okpo_resp"].ToString()) && !string.IsNullOrWhiteSpace(newRow["password_resp"].ToString()))
                    {
                        dataTableRespondents.Rows.Add(newRow);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }

            return dataTableRespondents;
        }
    }
}
