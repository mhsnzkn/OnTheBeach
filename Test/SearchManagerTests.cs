using SearchLayer;
using SearchLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            new object[] { "", "LPA", new DateTime(2022,11,10), 14 , null, null },
            new object[] { "MAN", "LPA", DateTime.MinValue, 14 , null, null },
        };

        [Theory, MemberData(nameof(FilterScenerios))]
        public void Filter_WhenSearchRequested_ResultsBestHoliday(string departingFrom, string travellingTo, DateTime departureDate, int duration, int? resultFlightId, int? resultHotelId)
        {
            // Arrange
            var requestModel = new SearchRequest
            {
                DepartingFrom = departingFrom,
                DepartureDate = departureDate,
                TravelingTo = travellingTo,
                Duration = duration,
            };
            var dataFilePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName;
            var methodClass = new SearchManager(dataFilePath);
            // Act
            var result = methodClass.Filter(requestModel);
            // Assert
            Assert.Equal(result.FirstOrDefault()?.Flight?.Id, resultFlightId);
            Assert.Equal(result.FirstOrDefault()?.Hotel?.Id, resultHotelId);
        }
    }
}