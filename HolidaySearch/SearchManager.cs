using SearchLayer.Constants;
using SearchLayer.Helper;
using SearchLayer.Models;

namespace SearchLayer
{
    public class SearchManager
    {
        private readonly List<Flight> _flights;
        private readonly List<Hotel> _hotels;
        public SearchManager(string dataPath)
        {
            _flights = DataHelper.GetFlightData(dataPath);
            _hotels = DataHelper.GetHotelData(dataPath);
        }
        public List<SearchResult> Filter(SearchRequest requestModel)
        {
            var result = new List<SearchResult>();
            if (!IsModelValid(requestModel))
                return result;

            var flights = GetFlightsBySearchRequest(requestModel);
            var hotels = GetHotelsBySearchRequest(requestModel);

            foreach (var flight in flights)
            {
                foreach (var hotel in hotels)
                {
                    result.Add(new SearchResult { Flight = flight, Hotel = hotel });
                }
            }

            return result.OrderBy(x=>x.TotalPrice).ToList();
        }

        private IEnumerable<Hotel> GetHotelsBySearchRequest(SearchRequest requestModel)
        {
            var hotelResult = _hotels
                .Where(x => x.ArrivalDate == requestModel.DepartureDate && x.Night == requestModel.Duration && x.LocalAirports.Contains(requestModel.TravelingTo));

            return hotelResult;
        }
        public IEnumerable<Flight> GetFlightsBySearchRequest(SearchRequest requestModel)
        {
            // DepartureDate filter
            var flightResult = _flights.Where(x=>x.DepartureDate == requestModel.DepartureDate);
            // DepartingFrom filter
            if(requestModel.DepartingFrom != Airports.Any)
            {
                if(requestModel.DepartingFrom == Airports.AnyLondon)
                {
                    flightResult = flightResult.Where(x=>x.DepartingFrom == Airports.LTN || x.DepartingFrom == Airports.LGW);
                }
                else
                {
                    flightResult = flightResult.Where(x=>x.DepartingFrom == requestModel.DepartingFrom);
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

        private bool IsModelValid(SearchRequest requestModel)
        {
            if(requestModel == null || string.IsNullOrEmpty(requestModel.TravelingTo) || string.IsNullOrEmpty(requestModel.DepartingFrom) 
                || requestModel.Duration == 0 || requestModel.DepartureDate == DateTime.MinValue)
                return false;

            return true;
        }
    }
}