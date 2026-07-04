using System.Collections.Generic;

namespace Himgiri.Core.Interfaces.Services;

public interface ICsvService
{
    byte[] ExportToCsv<T>(IEnumerable<T> data);
}
