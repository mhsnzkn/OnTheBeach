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
    }
}
