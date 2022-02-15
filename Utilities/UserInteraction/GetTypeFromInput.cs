namespace Utilities.UserInteraction;

public class GetTypeFromInput
{
    public static int GetInt(string message, int defaultValue)
    {
        Console.WriteLine(message);
        var readYear = Console.ReadLine();
        return !string.IsNullOrEmpty(readYear) ? int.Parse(readYear) : defaultValue;
    }
    
    public static string GetString(string message, string defaultValue)
    {
        Console.WriteLine(message);
        var readVal = Console.ReadLine();
        return !string.IsNullOrEmpty(readVal) ? readVal : defaultValue;
    }
}