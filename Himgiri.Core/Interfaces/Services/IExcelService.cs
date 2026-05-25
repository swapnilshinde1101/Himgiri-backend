namespace Himgiri.Core.Interfaces.Services;

public interface IExcelService
{
    byte[] ExportToExcel<T>(IEnumerable<T> data, string worksheetName);
}
