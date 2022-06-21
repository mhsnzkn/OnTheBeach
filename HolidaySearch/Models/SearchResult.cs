using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLayer.Models
{
    public class SearchResult
    {
        public decimal TotalPrice { get; set; }
        public Hotel Hotel { get; set; }
        public Flight Flight { get; set; }
    }
}
