using System.Globalization;
using CsvHelper;

namespace playlistimport.Utilities;

public class CsvWrite
{
    public static void WriteListToCsv<T>(List<T> list)
    {
        using (var writer = new StreamWriter("./Output.csv"))
        using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csvWriter.WriteRecords(list);
        }
        Console.WriteLine("Done Writing");
    }
}