using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLayer.Models
{
    public class SearchRequest
    {
        public string DepartingFrom { get; set; }
        public string TravelingTo { get; set; }
        public DateTime DepartureDate { get; set; }
        public int Duration { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(this.TravelingTo) || string.IsNullOrEmpty(this.DepartingFrom)
                || this.Duration == 0 || this.DepartureDate == DateTime.MinValue)
                return false;

            return true;
        }
    }
}
