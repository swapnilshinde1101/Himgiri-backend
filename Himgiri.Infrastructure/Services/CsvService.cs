using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Himgiri.Core.Interfaces.Services;

namespace Himgiri.Infrastructure.Services;

public class CsvService : ICsvService
{
    public byte[] ExportToCsv<T>(IEnumerable<T> data)
    {
        if (data == null || !data.Any())
        {
            return Array.Empty<byte>();
        }

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var csv = new StringBuilder();

        // 1. Resolve Header Labels (Use DisplayName if configured, otherwise Property Name)
        var headers = properties.Select(prop =>
        {
            var attr = prop.GetCustomAttribute<DisplayNameAttribute>();
            var headerName = attr != null ? attr.DisplayName : prop.Name;
            return $"\"{headerName.Replace("\"", "\"\"")}\"";
        });
        csv.AppendLine(string.Join(",", headers));

        // 2. Write Data Rows
        foreach (var item in data)
        {
            var rowValues = properties.Select(prop =>
            {
                var value = prop.GetValue(item);
                if (value == null)
                {
                    return string.Empty;
                }

                var str = value.ToString() ?? string.Empty;
                return $"\"{str.Replace("\"", "\"\"")}\"";
            });
            csv.AppendLine(string.Join(",", rowValues));
        }

        return Encoding.UTF8.GetBytes(csv.ToString());
    }
}
