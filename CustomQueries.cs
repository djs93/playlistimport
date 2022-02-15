namespace playlistimport;

public class CustomQueries
{
    public enum AvailableQueries
    {
        YearQuery,
        ArtistQuery,
        GenreQuery,
        TopQuery
    }
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
    
    public static List<Song> SongByGenre(List<Song> songs, string genre)
    {
        IEnumerable<Song> songQuery =
            from song in songs
            orderby song.Plays
            where song.Genre == genre
            select song;

        var songQueryResults = songQuery.ToList();

        return songQueryResults;
    }
    
    
    public static List<Song> TopSongs(List<Song> songs, int numberOfSongs)
    {
        IEnumerable<Song> songQuery =
            from song in songs
            orderby song.Plays
            select song;

        var songQueryResults = songQuery.Take(numberOfSongs).ToList();

        return songQueryResults;
    }
}