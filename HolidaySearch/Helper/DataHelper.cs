using SearchLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SearchLayer.Helper
{
    public static class DataHelper
    {
        public static List<Flight> GetFlightData(string fileFullPath)
        {
            fileFullPath += "\\FlightData.json";
            using FileStream openStream = File.OpenRead(fileFullPath);
            return JsonSerializer.Deserialize<List<Flight>>(openStream);
        }
        public static List<Hotel> GetHotelData(string fileFullPath)
        {
            fileFullPath += "\\HotelData.json";
            using FileStream openStream = File.OpenRead(fileFullPath);
            return JsonSerializer.Deserialize<List<Hotel>>(openStream);
        }

        public static List<SearchResult> JoinFlightHotelResults(IEnumerable<Flight> flights, IEnumerable<Hotel> hotels)
        {
            var result = new List<SearchResult>();
            foreach (var flight in flights)
            {
                foreach (var hotel in hotels)
                {
                    result.Add(new SearchResult { Flight = flight, Hotel = hotel });
                }
            }

            return result.OrderBy(x => x.TotalPrice).ToList();
        }
    }
}
