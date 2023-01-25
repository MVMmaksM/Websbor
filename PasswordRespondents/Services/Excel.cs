using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordRespondents.Services
{
    internal class Excel
    {
        public static byte[] CreateExcelRespondent(DataTable dataTable) 
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Список респондентов");
            int rowsCount = dataTable.Rows.Count + 1;

            sheet.Cells["A1"].Value = "Наименование";
            sheet.Cells["B1"].Value = "ОКПО";
            sheet.Cells["C1"].Value = "Пароль";
            sheet.Cells["D1"].Value = "Дата создания";
            sheet.Cells["E1"].Value = "Пользователь, создавший запись";
            sheet.Cells["F1"].Value = "Дата изменения";
            sheet.Cells["G1"].Value = "Пользователь, изменивший запись";
            sheet.Cells["H1"].Value = "Примечание";

            sheet.Cells[2, 1].LoadFromDataTable(dataTable);

            sheet.View.FreezePanes(2, 1);
            sheet.Cells[1, 1, 1, 8].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            sheet.Cells[1, 1, 1, 8].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(217, 217, 217));

            sheet.Columns[1].Width = 50;
            sheet.Columns[2].Width = 30;
            sheet.Columns[3].Width = 30;
            sheet.Columns[4].Width = 30;
            sheet.Columns[5].Width = 36;
            sheet.Columns[6].Width = 30;
            sheet.Columns[7].Width = 36;
            sheet.Columns[8].Width = 30;

            sheet.Columns[1, 8].Style.Font.Name = "Times New Roman";
            sheet.Columns[4].Style.Numberformat.Format = "dd.mm.yyyy";
            sheet.Columns[6].Style.Numberformat.Format = "dd.mm.yyyy";            

            sheet.Columns[1, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Columns[1, 8].Style.Font.Size = 12;
            sheet.Cells[1, 1, 1, 8].Style.Font.Bold = true;
            sheet.Cells[1, 1, 1, 8].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Rows[1].Height = 30;
            sheet.Cells[1, 1, rowsCount, 8].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, rowsCount, 8].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, rowsCount, 8].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, rowsCount, 8].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

            return package.GetAsByteArray();
        }

        public static ExcelWorksheet ReadExcel(string pathExcelFile) 
        {
            ExcelPackage package = new ExcelPackage(pathExcelFile);
            ExcelWorksheet sheet = package.Workbook.Worksheets[0];

            return sheet;
        }
    }
}
