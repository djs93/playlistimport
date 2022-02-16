namespace playlistimport;

public class CustomTypeFromInput
{
    public static List<CustomQueries.AvailableQueries> GetQueries(string message, bool retry, string retryMessage = "")
    {
        var queryQuestion = $"{message}\nAvailable queries are:\n {CustomQueries.GetAvailableQueries()}";
        Console.WriteLine(queryQuestion);
        var readVal = CustomDataCleaners.CleanQueryInput(Console.ReadLine());
        while (retry && readVal is {Count: 0})
        {
            Console.WriteLine(retryMessage);
            readVal = CustomDataCleaners.CleanQueryInput(Console.ReadLine());
        }
        return readVal;
    }
}