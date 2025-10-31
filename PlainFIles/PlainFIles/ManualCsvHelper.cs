using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlainFIles.Core;

public class ManualCsvHelper
{
    public void WriteCsv(string path, List<string[]> records)
    {
        var dir = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        // StreamWriter crea el archivo si no existe.
        using var sw = new StreamWriter(path, append: false, encoding: Encoding.UTF8);
        foreach (var record in records)
        {
            var line = string.Join(",", record);
            sw.WriteLine(line);
        }
    }

    public List<string[]> ReadCsv(string path)
    {
        var dir = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        // Si el archivo no existe, lo creamos y devolvemos lista vacía.
        if (!File.Exists(path))
        {
            using (File.Create(path)) { }
            return new List<string[]>();
        }

        var result = new List<string[]>();
        using var sr = new StreamReader(path, Encoding.UTF8);
        string? line;
        while ((line = sr.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var fields = line.Split(',');
            result.Add(fields);
        }
        return result;
    }
}
