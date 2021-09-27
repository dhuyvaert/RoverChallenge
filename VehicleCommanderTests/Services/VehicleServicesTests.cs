using Xunit;
using VehicleCommander.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleCommander.Models;
using VehicleCommander.Enums;
using VehicleCommander.Constants;

namespace VehicleCommander.Services.Tests
{
    public class VehicleServicesTests
    {
        private readonly VehicleServices _vehicleService;
        public VehicleServicesTests()
        {
            _vehicleService = new VehicleServices();
        }

        [Fact()]
        public void CreateVehicle_Success()
        {
            var createVehicle = _vehicleService.CreateVehicle("2 2 N", "V1");
            Assert.True(createVehicle.Success);
        }

        [Fact()]
        public void CreateVehicle_Failure_NoCommand()
        {
            var createVehicle = _vehicleService.CreateVehicle("", "V1");
            Assert.False(createVehicle.Success);
        }

        [Fact()]
        public void CreateVehicle_Failure_BadCommand()
        {
            var createVehicle = _vehicleService.CreateVehicle("abc", "V1");
            Assert.False(createVehicle.Success);
        }

        [Fact()]
        public void SetMovementCommands_Success ()
        {
            var rover = new Rover() { VehicleLocation = new Location(2, 3, CardinalDirection.N) };
            var setVehicleMovement = _vehicleService.SetMovementCommands(rover, "MLR");
            Assert.True(setVehicleMovement.Success);
            Assert.Equal(string.Empty, setVehicleMovement.ErrorMessage);
        }

        [Fact()]
        public void SetMovementCommands_Failure()
        {
            var rover = new Rover() { VehicleLocation = new Location(2, 3, CardinalDirection.N) };
            var setVehicleMovement = _vehicleService.SetMovementCommands(rover, "abc");
            Assert.False(setVehicleMovement.Success);
            Assert.Equal(ErrorCodes.INVALID_MOVEMENT_COMMAND_SET, setVehicleMovement.ErrorMessage);
        }
    }
}