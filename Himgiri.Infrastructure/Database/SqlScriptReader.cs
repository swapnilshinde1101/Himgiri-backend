using System.IO;
using System.Reflection;

namespace Himgiri.Infrastructure.Database;

public static class SqlScriptReader
{
    public static string GetScript(string filename)
    {
        var assembly = Assembly.GetExecutingAssembly();
        // The resource path format: <AssemblyName>.<Folder>.<Subfolder>.<Filename>
        var resourceName = $"Himgiri.Infrastructure.Database.Scripts.{filename}";

        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null)
        {
            throw new FileNotFoundException($"SQL Embedded script file '{filename}' was not found. Looked for: {resourceName}");
        }

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
