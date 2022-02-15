namespace playlistimport;

public static class CustomDataCleaners
{
    public static List<int> CleanQueryInput(string? queryInput)
    {
        List<int> resultList = new List<int>();
        if (queryInput == null)
        {
            return resultList;
        }
        
        string cleanedQueryStr = queryInput.Replace(" ", "").Replace(",", "");
        int maxQueryVal = (int)Enum.GetValues(typeof(CustomQueries.AvailableQueries)).Cast<CustomQueries.AvailableQueries>().Max();
        resultList.AddRange(
            from letter in cleanedQueryStr 
            where char.IsDigit(letter) && int.Parse(letter.ToString()) <= maxQueryVal
            select int.Parse(letter.ToString())
        );

        return resultList;
    }
}