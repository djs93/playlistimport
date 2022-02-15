namespace playlistimport;

public class CustomTypeFromInput
{
    public static string GetQueries(string message, bool retry, string retryMessage = "")
    {
        var queryQuestion = $"{message}\n Available queries are:\n {CustomQueries.GetAvailableQueries()}";
        Console.WriteLine(message);
        var readVal = Console.ReadLine();
        while (retry && string.IsNullOrEmpty(readVal))
        {
            Console.WriteLine(retryMessage);
            readVal = Console.ReadLine();
        }
        return !string.IsNullOrEmpty(readVal) ? readVal : "none";
    }
}