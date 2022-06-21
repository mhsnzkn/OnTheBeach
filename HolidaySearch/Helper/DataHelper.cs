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
        public static async Task<List<Flight>> GetFlightData(string fileFullPath)
        {
            using FileStream openStream = File.OpenRead(fileFullPath);
            return await JsonSerializer.DeserializeAsync<List<Flight>>(openStream);
        }
        public static async Task<List<Hotel>> GetHotelData(string fileFullPath)
        {
            using FileStream openStream = File.OpenRead(fileFullPath);
            return await JsonSerializer.DeserializeAsync<List<Hotel>>(openStream);
        }
    }
}
