using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SearchLayer.Models
{
    public class Hotel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("price_per_night")]
        public decimal PricePerNight { get; set; }
        [JsonPropertyName("arrival_date")]
        public DateTime ArrivalDate { get; set; }
        [JsonPropertyName("local_airports")]
        public string[] LocalAirports { get; set; }
        [JsonPropertyName("nights")]
        public int Night { get; set; }
    }
}
