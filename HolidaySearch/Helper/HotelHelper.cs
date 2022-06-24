using SearchLayer.Constants;
using SearchLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLayer.Helper
{
    public static class HotelHelper
    {

        public static IEnumerable<Hotel> GetHotelsBySearchRequest(List<Hotel> hotels, SearchRequest requestModel)
        {
            var hotelResult = hotels
                .Where(x => x.ArrivalDate == requestModel.DepartureDate && x.Night == requestModel.Duration && x.LocalAirports.Contains(requestModel.TravelingTo));

            return hotelResult;
        }
    }
}
