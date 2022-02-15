using BetterConsoles.Tables;
using BetterConsoles.Tables.Configuration;

namespace playlistimport;

public class CustomPrintables
{
    public static void PrintSongList(List<Song> list)
    {
        Table table = new Table(TableConfig.Unicode());
        table.From(list.ToArray());
        Console.Write(table.ToString());
    }
}