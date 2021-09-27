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
    public class MovementServiceTests
    {
        private readonly MovementService _movementService;
        public MovementServiceTests()
        {
            _movementService = new MovementService();
        }

        [Fact()]
        public void MoveVehicle_MoveSuccess()
        {
            var rover = new Rover() { VehicleLocation = new Location(2, 3, CardinalDirection.N), MovementCommands = "M".ToArray() };
            var area = new Area(4, 4);
            var movedVehicle = _movementService.MoveVehicle(rover, area);
            Assert.True(movedVehicle.Success);
            Assert.Equal(2, movedVehicle.Data.XLocation);
            Assert.Equal(4, movedVehicle.Data.YLocation);
            Assert.Equal(CardinalDirection.N, movedVehicle.Data.Direction);
            Assert.Equal(string.Empty, movedVehicle.ErrorMessage);
        }

        [Fact()]
        public void MoveVehicle_TurnSuccess()
        {
            var rover = new Rover() { VehicleLocation = new Location(2 ,3 , CardinalDirection.N) , MovementCommands = "R".ToArray()};
            var area = new Area(4, 4);
            var movedVehicle = _movementService.MoveVehicle(rover, area);
            Assert.True(movedVehicle.Success);
            Assert.Equal(2, movedVehicle.Data.XLocation);
            Assert.Equal(3, movedVehicle.Data.YLocation);
            Assert.Equal(CardinalDirection.E, movedVehicle.Data.Direction);
            Assert.Equal(string.Empty, movedVehicle.ErrorMessage);
        }

        [Fact()]
        public void MoveVehicle_Failure_BadCommand()
        {
            var rover = new Rover() { VehicleLocation = new Location(2, 3, CardinalDirection.N), MovementCommands = "K".ToArray() };
            var area = new Area(4, 4);
            var movedVehicle = _movementService.MoveVehicle(rover, area);
            Assert.False(movedVehicle.Success);
            Assert.Equal(2, movedVehicle.Data.XLocation);
            Assert.Equal(3, movedVehicle.Data.YLocation);
            Assert.Equal(ErrorCodes.OUTSIDE_BOUNDARY_MOVEMENT, movedVehicle.ErrorMessage);
        }

        [Fact()]
        public void MoveVehicle_Failure_EmptyCommand()
        {
            var rover = new Rover() { VehicleLocation = new Location(2, 3, CardinalDirection.N), MovementCommands = "".ToArray() };
            var area = new Area(4, 4);
            var movedVehicle = _movementService.MoveVehicle(rover, area);
            Assert.False(movedVehicle.Success);
            Assert.Equal(2, movedVehicle.Data.XLocation);
            Assert.Equal(3, movedVehicle.Data.YLocation);
            Assert.Equal(ErrorCodes.INVALID_MOVEMENT_COMMAND, movedVehicle.ErrorMessage);
        }

        [Fact()]
        public void Move_Success()
        {
            var rover = new Rover() { VehicleLocation = new Location(2, 3, CardinalDirection.N), MovementCommands = "M".ToArray() };
            var movedVehicle = _movementService.Move(rover);
            Assert.True(movedVehicle.Success);
            Assert.Equal(2, movedVehicle.Data.VehicleLocation.XLocation);
            Assert.Equal(4, movedVehicle.Data.VehicleLocation.YLocation);
            Assert.Equal(string.Empty, movedVehicle.ErrorMessage);
        }

        [Fact()]
        public void Move_Success_BadTurnCommand()
        {
            var rover = new Rover() { VehicleLocation = new Location(2, 3, CardinalDirection.N), MovementCommands = "H".ToArray() };
            var movedVehicle = _movementService.Move(rover);
            Assert.True(movedVehicle.Success);
            Assert.Equal(2, movedVehicle.Data.VehicleLocation.XLocation);
            Assert.Equal(4, movedVehicle.Data.VehicleLocation.YLocation);
            Assert.Equal(string.Empty, movedVehicle.ErrorMessage);
        }

        [Fact()]
        public void Turn_Success()
        {
            var rover = new Rover() { VehicleLocation = new Location(2, 3, CardinalDirection.N), MovementCommands = "L".ToArray() };
            var turnedVehicle = _movementService.Turn(rover, "R");
            Assert.True(turnedVehicle.Success);
            Assert.Equal(2, turnedVehicle.Data.VehicleLocation.XLocation);
            Assert.Equal(3, turnedVehicle.Data.VehicleLocation.YLocation);
            Assert.Equal(CardinalDirection.E, turnedVehicle.Data.VehicleLocation.Direction);
            Assert.Equal(string.Empty, turnedVehicle.ErrorMessage);
        }

        [Fact()]
        public void Turn_Failure_BadCommand()
        {
            var rover = new Rover() { VehicleLocation = new Location(2, 3, CardinalDirection.N), MovementCommands = "H".ToArray() };
            var turnedVehicle = _movementService.Turn(rover, "H");
            Assert.False(turnedVehicle.Success);
            Assert.Equal(2, turnedVehicle.Data.VehicleLocation.XLocation);
            Assert.Equal(3, turnedVehicle.Data.VehicleLocation.YLocation);
            Assert.Equal(CardinalDirection.N, turnedVehicle.Data.VehicleLocation.Direction);
            Assert.Equal(ErrorCodes.INVALID_TURN_COMMAND, turnedVehicle.ErrorMessage);
        }
    }
}