using System.Text;

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

    private static Dictionary<AvailableQueries, string> _queryNames = new Dictionary<AvailableQueries, string>()
    {
        {AvailableQueries.YearQuery, "Year"},
        {AvailableQueries.ArtistQuery, "Artist"},
        {AvailableQueries.GenreQuery, "Genre"},
        {AvailableQueries.TopQuery, "Top Songs from query"}
    };

    public static string GetAvailableQueries()
    {
        StringBuilder result = new StringBuilder();
        
        foreach ((AvailableQueries key, string? value) in _queryNames)
        {
            result.Append($"\t{(int)key}:{value}\n");
        }

        return result.ToString();
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