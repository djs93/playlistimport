using BetterConsoles.Tables;
using BetterConsoles.Tables.Configuration;

namespace playlistimport;

public class CustomPrintables
{
    public static void PrintSongList(List<Song>? list)
    {
        if (list == null)
        {
            Console.Write("List was null");
            return;
        }

        if (list.Count == 0)
        {
            Console.Write("No songs matched your query!");
            return;
        }
        Table table = new Table(TableConfig.Unicode());
        table.From(list.ToArray());
        Console.Write(table.ToString());
    }
}