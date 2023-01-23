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
        public byte[] CreateExcelRespondent(DataTable dataTable) 
        {
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Список респондентов");
            int rowsCount = dataTable.Rows.Count + 1;

            sheet.Cells["A1"].Value = "Наименование";
            sheet.Cells["B1"].Value = "ОКПО";
            sheet.Cells["C1"].Value = "Пароль";
            sheet.Cells["D1"].Value = "Дата создания";
            sheet.Cells["E1"].Value = "Примечание";

            sheet.Cells[2, 1].LoadFromDataTable(dataTable);

            sheet.View.FreezePanes(2, 1);
            sheet.Cells[1, 1, 1, 5].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            sheet.Cells[1, 1, 1, 5].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(217, 217, 217));
            sheet.Columns[1].Width = 100;
            sheet.Columns[2].Width = 30;
            sheet.Columns[3].Width = 30;
            sheet.Columns[4].Width = 30;
            sheet.Columns[5].Width = 30;
            sheet.Columns[1, 5].Style.Font.Name = "Times New Roman";
            sheet.Columns[1, 5].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Columns[1, 5].Style.Font.Size = 12;
            sheet.Cells[1, 1, 1, 5].Style.Font.Bold = true;
            sheet.Cells[1, 1, 1, 5].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Rows[1].Height = 30;
            sheet.Cells[1, 1, rowsCount, 5].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, rowsCount, 5].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, rowsCount, 5].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, rowsCount, 5].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

            return package.GetAsByteArray();
        }
    }
}
