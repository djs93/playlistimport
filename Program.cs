// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using playlistimport;
using playlistimport.Utilities;
using Utilities.UserInteraction;

//you will need to run "dotnet add package CsvHelper" inside the consoleApp2 Project folder or create the project
//if you are doing this from scratch or you can create the project with the solution by checking that
//box when you create it and just add it in the project solution directory
//put the path to the file you want to import

var filePath = FilePathOperations.GetFilePath("Enter The Absolute File Path for the playlist\r", 
    "/Users/kwilliams/RiderProjects/playlistimport/data/music.csv");

var records = CsvRead.ReadDistinctRecords(filePath, new SongMap());

//Ask what queries they'd like to select (strip everything except numbers)
var wouldLikeToExit = "n";
while (!wouldLikeToExit.ToLower().Equals("y"))
{
    //Get Queries
    //Run Queries sequentially
    //Print Queries
    //Ask for file write
    //If true, ask for file name
    //Ask for Exit
}
var selectedQueries = CustomTypeFromInput.GetQueries("Which Queries would you like to select?", true, retryMessage:"Please enter valid queries from the numbers above!");
Console.WriteLine($"Selected Queries: {string.Join(", ", selectedQueries)}\n");

var songQuery = CustomQueries.RunSongQueries(selectedQueries, records);
//var songQuery = CustomQueries.SongByYear(records, GetTypeFromInput.GetInt("Enter The year\r", 2015));

CustomPrintables.PrintSongList(songQuery);

CsvWrite.WriteListToCsv(songQuery);