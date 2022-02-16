namespace playlistimport;

public static class CustomDataCleaners
{
    public static List<CustomQueries.AvailableQueries> CleanQueryInput(string? queryInput)
    {
        List<CustomQueries.AvailableQueries> resultList = new List<CustomQueries.AvailableQueries>();
        if (queryInput == null)
        {
            return resultList;
        }
        
        string cleanedQueryStr = queryInput.Replace(" ", "").Replace(",", "");
        int maxQueryVal = (int)Enum.GetValues(typeof(CustomQueries.AvailableQueries)).Cast<CustomQueries.AvailableQueries>().Max();
        resultList.AddRange(
            from letter in cleanedQueryStr 
            where char.IsDigit(letter) && int.Parse(letter.ToString()) <= maxQueryVal
            select (CustomQueries.AvailableQueries)int.Parse(letter.ToString())
        );

        return resultList;
    }
}