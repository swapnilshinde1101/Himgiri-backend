using OfficeOpenXml;
using Himgiri.Core.Interfaces.Services;

namespace Himgiri.Infrastructure.Services;

public class ExcelService : IExcelService
{
    static ExcelService()
    {
        // Set EPPlus license to non-commercial
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }

    public byte[] ExportToExcel<T>(IEnumerable<T> data, string worksheetName)
    {
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add(worksheetName);
        
        // Load the data into the worksheet
        worksheet.Cells["A1"].LoadFromCollection(data, true);
        
        // Auto-fit columns
        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
        
        return package.GetAsByteArray();
    }
}
