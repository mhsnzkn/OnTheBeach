using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SearchLayer.Models
{
    public class Flight
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("from")]
        public string DepartingFrom { get; set; }
        [JsonPropertyName("to")]
        public string TravelingTo { get; set; }
        [JsonPropertyName("airline")]
        public string Airline { get; set; }
        [JsonPropertyName("departure_date")]
        public DateTime DepartureDate { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
