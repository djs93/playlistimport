namespace playlistimport;

public class CustomPrintables
{
    public static void PrintSongList(List<Song> list)
    {
        foreach (Song song in list)
        {
            Console.WriteLine("{0},{1}, {2}",song.Name,song.Artist, song.Genre);
        }
        var songCountCount = list.Count.ToString();
        Console.WriteLine($"Number of songs: {songCountCount}");
    }
}