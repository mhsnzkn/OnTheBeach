// See https://aka.ms/new-console-template for more information
using SearchLayer.Helper;
using System.Text.Json;

Console.WriteLine("Hello, World!");


var currentPath = AppDomain.CurrentDomain.BaseDirectory;
var filePath = Directory.GetParent(currentPath)?.Parent?.Parent?.Parent?.Parent?.FullName;
string flightFile = Path.Combine(filePath + "\\FlightData.json");
var flightList = await DataHelper.GetFlightData(flightFile);
string hotelFile = Path.Combine(filePath + "\\HotelData.json");
var hotelList = await DataHelper.GetHotelData(hotelFile);

foreach (var item in flightList)
{
    Console.WriteLine(JsonSerializer.Serialize(item));
}
Console.WriteLine("----------------------------");
foreach (var item in hotelList)
{
    Console.WriteLine(JsonSerializer.Serialize(item));
}

Console.ReadKey();