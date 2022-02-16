using System.Text;
using Utilities.UserInteraction;

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
    
    private static Dictionary<AvailableQueries, Delegate> _queryFunctions = new Dictionary<AvailableQueries, Delegate>()
    {
        {AvailableQueries.YearQuery, AskSongByYear},
        {AvailableQueries.ArtistQuery, AskSongByArtist},
        {AvailableQueries.GenreQuery, AskSongByGenre},
        {AvailableQueries.TopQuery, AskTopSongs}
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
            orderby song.Plays descending 
            where song.Year.Year == year
            select song;

        var songQueryResults = songQuery.ToList();

        return songQueryResults;
    }

    private static List<Song> AskSongByYear(List<Song> songs)
    {
        return SongByYear(songs, GetTypeFromInput.GetInt("\nEnter The year (Enter for 2015)\r", 2015));
    }
    
    public static List<Song> SongByArtist(List<Song> songs, string artist)
    {
        IEnumerable<Song> songQuery =
            from song in songs
            orderby song.Plays descending
            where song.Artist == artist
            select song;

        var songQueryResults = songQuery.ToList();

        return songQueryResults;
    }
    
    private static List<Song> AskSongByArtist(List<Song> songs)
    {
        return SongByArtist(songs, GetTypeFromInput.GetString("\nEnter The artist\r", ""));
    }
    
    public static List<Song> SongByGenre(List<Song> songs, string genre)
    {
        IEnumerable<Song> songQuery =
            from song in songs
            orderby song.Plays descending
            where song.Genre == genre
            select song;

        var songQueryResults = songQuery.ToList();

        return songQueryResults;
    }
    
    private static List<Song> AskSongByGenre(List<Song> songs)
    {
        return SongByGenre(songs, GetTypeFromInput.GetString("\nEnter The genre (Enter for Pop)\r", "Pop"));
    }
    
    public static List<Song> TopSongs(List<Song> songs, int numberOfSongs)
    {
        IEnumerable<Song> songQuery =
            from song in songs
            orderby song.Plays descending
            select song;

        var songQueryResults = songQuery.Take(numberOfSongs).ToList();

        return songQueryResults;
    }
    
    
    private static List<Song> AskTopSongs(List<Song> songs)
    {
        return TopSongs(songs, GetTypeFromInput.GetInt("\nEnter the number of songs for Top Songs (Enter for 10)\r", 10));
    }

    public static List<Song>? RunSongQueries(List<AvailableQueries> queryTypes, List<Song>? songsToQuery)
    {
        return queryTypes.Aggregate(songsToQuery, (current, queryType) => RunQuery(queryType, current));
    }

    private static List<Song> RunQuery(AvailableQueries queryType, List<Song>? songsToQuery)
    {
        return (List<Song>)_queryFunctions[queryType].DynamicInvoke(songsToQuery)!;
    }
}