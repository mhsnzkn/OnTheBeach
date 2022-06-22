// See https://aka.ms/new-console-template for more information
using SearchLayer;
using SearchLayer.Models;
using System.Text.Json;

Console.WriteLine("Started");


var currentPath = AppDomain.CurrentDomain.BaseDirectory;
var filePath = Directory.GetParent(currentPath)?.Parent?.Parent?.Parent?.Parent?.FullName;
//Departing from: Any London Airport
// * Traveling to: Mallorca Airport(PMI)
// *Departure Date: 2023 / 06 / 15
//* Duration: 10 nights
var requestModel = new SearchRequest
{
    DepartingFrom = "",
    TravelingTo = "PMI",
    DepartureDate = new DateTime(2023,6,15),
    Duration = 10,
};
var methodClass = new SearchManager(filePath);

var result = methodClass.Filter(requestModel);

Console.WriteLine(JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true }));

Console.ReadKey();
