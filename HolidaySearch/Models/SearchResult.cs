using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLayer.Models
{
    public class SearchResult
    {
        public decimal TotalPrice => Hotel.PricePerNight * Hotel.Night + Flight.Price;
        public Hotel Hotel { get; set; }
        public Flight Flight { get; set; }
    }
}
