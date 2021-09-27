using Xunit;
using VehicleCommander.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleCommander.Models;
using VehicleCommander.Constants;

namespace VehicleCommander.Services.Tests
{
    public class AreaServicesTests
    {
        private readonly AreaServices _areaServices;
        public AreaServicesTests()
        {
            _areaServices = new AreaServices();
        }
        [Fact()]
        public void IsValidArea_Success()
        {
            var validArea =_areaServices.IsValidArea(1, 1);
            Assert.True(validArea);
        }

        [Fact()]
        public void IsValidArea_Failure()
        {
            var validArea = _areaServices.IsValidArea(-1, 1);
            Assert.False(validArea);
        }

        [Fact()]
        public void IsWithinBoundary_Success()
        {
            var area = new Area(2, 2);
            var validBoundary = _areaServices.IsWithinBoundary(1, 1, area);
            Assert.True(validBoundary);
        }

        [Fact()]
        public void IsWithinBoundary_Failure()
        {
            var area = new Area(2, 2);
            var validBoundary = _areaServices.IsWithinBoundary(2, 3, area);
            Assert.False(validBoundary);
        }

        [Fact()]
        public void SetArea_Success()
        {
            var validArea = _areaServices.SetArea(2, 3);
            Assert.True(validArea.Success);
            Assert.Equal(2, validArea.Data.XBoundary);
            Assert.Equal(3, validArea.Data.YBoundary);
            Assert.Equal(string.Empty, validArea.ErrorMessage);
        }
        [Fact()]
        public void SetArea_Failure()
        {
            var validArea = _areaServices.SetArea(-2, 3);
            Assert.False(validArea.Success);
            Assert.Equal(0, validArea.Data.XBoundary);
            Assert.Equal(0, validArea.Data.YBoundary);
            Assert.Equal(ErrorCodes.OUTSIDE_BOUNDARY_SET, validArea.ErrorMessage);
        }
    }
}