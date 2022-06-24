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
            List<SearchResult> result=null;
            if (!requestModel.IsValid())
                return result;

            var flights = FlightHelper.GetFlightsBySearchRequest(_flights, requestModel);
            var hotels = HotelHelper.GetHotelsBySearchRequest(_hotels, requestModel);

            result = DataHelper.JoinFlightHotelResults(flights, hotels);

            return result;
        }

        
    }
}