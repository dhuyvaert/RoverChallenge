using Xunit;
using VehicleCommander.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleCommander.Constants;

namespace VehicleCommander.Services.Tests
{
    public class LocationServiceTests
    {
        private readonly LocationService _locationService;
        public LocationServiceTests()
        {
            _locationService = new LocationService();
        }
        [Fact()]
        public void ParseLocationCommand_Success()
        {
            var parsedLocation = _locationService.ParseLocationCommand("1 2");
            Assert.True(parsedLocation.Success);
            Assert.Equal(1, parsedLocation.Data.XLocation);
            Assert.Equal(2, parsedLocation.Data.YLocation);
            Assert.Equal(string.Empty, parsedLocation.ErrorMessage);
        }

        [Fact()]
        public void ParseLocationCommand_Failure_SingleString()
        {
            var parsedLocation = _locationService.ParseLocationCommand("12");
            Assert.False(parsedLocation.Success);
            Assert.Equal(0, parsedLocation.Data.XLocation);
            Assert.Equal(0, parsedLocation.Data.YLocation);
            Assert.Equal(ErrorCodes.INVALID_LOCATION, parsedLocation.ErrorMessage);
        }

        [Fact()]
        public void ParseLocationCommand_Failure_MultipleValues()
        {
            var parsedLocation = _locationService.ParseLocationCommand("12 A");
            Assert.False(parsedLocation.Success);
            Assert.Equal(12, parsedLocation.Data.XLocation);
            Assert.Equal(0, parsedLocation.Data.YLocation);
            Assert.Equal(ErrorCodes.INVALID_LOCATION, parsedLocation.ErrorMessage);
        }

        [Fact()]
        public void ParseLocationCommand_Failure_EmptyValues()
        {
            var parsedLocation = _locationService.ParseLocationCommand("");
            Assert.False(parsedLocation.Success);
            Assert.Equal(0, parsedLocation.Data.XLocation);
            Assert.Equal(0, parsedLocation.Data.YLocation);
            Assert.Equal(ErrorCodes.INVALID_LOCATION, parsedLocation.ErrorMessage);
        }
    }
}