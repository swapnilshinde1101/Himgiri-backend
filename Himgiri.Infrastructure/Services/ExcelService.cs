using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Himgiri.Core.Interfaces.Services;

namespace Himgiri.Infrastructure.Services;

public class ExcelService : IExcelService
{
    static ExcelService()
    {
        try
        {
            // Set EPPlus license to non-commercial
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Failed to set EPPlus LicenseContext: {ex.Message}");
            Console.WriteLine(ex.ToString());
        }
    }

    public byte[] ExportToExcel<T>(IEnumerable<T> data, string worksheetName)
    {
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add(worksheetName);

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // 1. Write styled header cells (Brand color styling: Slate 900)
        for (int col = 0; col < properties.Length; col++)
        {
            var prop = properties[col];
            var attr = prop.GetCustomAttribute<DisplayNameAttribute>();
            var headerName = attr != null ? attr.DisplayName : prop.Name;

            var cell = worksheet.Cells[1, col + 1];
            cell.Value = headerName;
            cell.Style.Font.Bold = true;
            cell.Style.Font.Color.SetColor(Color.White);
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#0F172A")); // Slate 900
            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        }

        // 2. Write rows and apply column cell formatting
        var list = data.ToList();
        for (int row = 0; row < list.Count; row++)
        {
            var item = list[row];
            for (int col = 0; col < properties.Length; col++)
            {
                var prop = properties[col];
                var value = prop.GetValue(item);
                var cell = worksheet.Cells[row + 2, col + 1];

                cell.Value = value;

                // Format numeric cells (dec & int)
                if (prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(decimal?))
                {
                    cell.Style.Numberformat.Format = "₹#,##0.00";
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
                {
                    cell.Style.Numberformat.Format = "#,##0";
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
            }
        }

        // Enable default grid lines
        worksheet.View.ShowGridLines = true;

        // Auto-fit columns
        if (worksheet.Dimension != null)
        {
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
        }

        return package.GetAsByteArray();
    }
}
