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
        public static async void SaveFaile(string fullNameFile, byte[] bytesFile)
        {
            await File.WriteAllBytesAsync(fullNameFile, bytesFile);
        }

        public DataTable ConvertExcelToDataTable(ExcelWorksheet sheet)
        {
            DataTable dataTableRespondents = new DataTable();

            dataTableRespondents.Columns.AddRange(new DataColumn[4]
            { new DataColumn("name", typeof(string)),
            new DataColumn("okpo", typeof(string)),
            new DataColumn ("password", typeof(string)),
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

                    if (!string.IsNullOrWhiteSpace(newRow["name"].ToString()) && !string.IsNullOrWhiteSpace(newRow["okpo"].ToString()) && !string.IsNullOrWhiteSpace(newRow["password"].ToString())
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
