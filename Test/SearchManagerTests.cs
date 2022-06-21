using SearchLayer;
using SearchLayer.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class SearchManagerTests
    {
        public static IEnumerable<object[]> FilterScenerios =>
        new List<object[]>
        {
            new object[] { "MAN", "AGP", new DateTime(2023,7,1), 7 , 2, 9 },
            new object[] { "ANYLONDON", "PMI", new DateTime(2023,6,15), 10 , 6, 5 },
            new object[] { "ANY", "LPA", new DateTime(2022,11,10), 14 , 7, 6 },
        };

        [Theory, MemberData(nameof(FilterScenerios))]
        public void Filter_WhenSearchRequested_ResultsBestHoliday(string departingFrom, string travellingTo, DateTime departureDate, int duration, int resultFlightId, int resultHotelId)
        {
            // Arrange
            var requestModel = new SearchRequest
            {
                DepartingFrom = departingFrom,
                DepartureDate = departureDate,
                TravelingTo = travellingTo,
                Duration = duration,
            };
            var methodClass = new SearchManager();
            // Act
            var result = methodClass.Filter(requestModel);
            // Assert
            Assert.Equal(result[0].Flight.Id, resultFlightId);
            Assert.Equal(result[0].Hotel.Id, resultHotelId);
        }
    }
}