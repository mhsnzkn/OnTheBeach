using SearchLayer.Constants;
using SearchLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLayer.Helper
{
    public static class FlightHelper
    {
        public static IEnumerable<Flight> GetFlightsBySearchRequest(List<Flight> flights, SearchRequest requestModel)
        {
            // DepartureDate filter
            var flightResult = flights.Where(x => x.DepartureDate == requestModel.DepartureDate);
            // DepartingFrom filter
            if (requestModel.DepartingFrom != Airports.Any)
            {
                if (requestModel.DepartingFrom == Airports.AnyLondon)
                {
                    flightResult = flightResult.Where(x => x.DepartingFrom == Airports.LTN || x.DepartingFrom == Airports.LGW);
                }
                else
                {
                    flightResult = flightResult.Where(x => x.DepartingFrom == requestModel.DepartingFrom);
                }
            }
            // TravelingTo filter
            if (requestModel.TravelingTo != Airports.Any)
            {
                if (requestModel.TravelingTo == Airports.AnyLondon)
                {
                    flightResult = flightResult.Where(x => x.TravelingTo == Airports.LTN || x.TravelingTo == Airports.LGW);
                }
                else
                {
                    flightResult = flightResult.Where(x => x.TravelingTo == requestModel.TravelingTo);
                }
            }

            return flightResult;
        }
    }
}
