namespace playlistimport;

public class CustomQueries
{
    public static List<Song> SongByYear(List<Song> songs, int year)
    {
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
        IEnumerable<Song> songQuery =
            from song in songs
            orderby song.Plays
            where song.Year.Year == year
            select song;

        var songQueryResults = songQuery.ToList();

        return songQueryResults;
    }
    
    public static List<Song> SongByArtist(List<Song> songs, string artist)
    {
        IEnumerable<Song> songQuery =
            from song in songs
            orderby song.Plays
            where song.Artist == artist
            select song;

        var songQueryResults = songQuery.ToList();

        return songQueryResults;
    }

}