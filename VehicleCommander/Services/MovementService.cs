using System.Linq;
using VehicleCommander.Constants;
using VehicleCommander.Enums;
using VehicleCommander.Interfaces;
using VehicleCommander.Models;
using VehicleCommander.Utility;

namespace VehicleCommander.Services
{
    public class MovementService : AreaServices, IMovement
    {
        public Result<Location> MoveVehicle(Rover rover, Area area)
        {
            var initialRoverLocation = new Location(rover.VehicleLocation.XLocation, rover.VehicleLocation.YLocation, rover.VehicleLocation.Direction);
            if (rover.MovementCommands.Count() == 0) return new Result<Location>() { Success = false, Data = initialRoverLocation, ErrorMessage = ErrorCodes.INVALID_MOVEMENT_COMMAND };

            foreach (var command in rover.MovementCommands)
            {
                var movementInstruction = command.ToString().ToUpper();
                if (!Validation.ValidateMovementCommands(movementInstruction))
                {
                    return new Result<Location>() { Success = false, Data = initialRoverLocation, ErrorMessage = ErrorCodes.OUTSIDE_BOUNDARY_MOVEMENT };
                }
                var result = movementInstruction == "M" ? Move(rover) : Turn(rover, movementInstruction);
                
                if (!result.Success)
                {
                    return new Result<Location>() { Success = false, Data = initialRoverLocation, ErrorMessage = result.ErrorMessage };
                }
            }
            if (!IsWithinBoundary(rover.VehicleLocation.XLocation, rover.VehicleLocation.YLocation, area))
            {
                return new Result<Location>() { Success = false, Data = initialRoverLocation, ErrorMessage = ErrorCodes.OUTSIDE_BOUNDARY_MOVEMENT };
            }
            return new Result<Location>() { Success = true, Data = rover.VehicleLocation, ErrorMessage = string.Empty };
        }
        public Result<Rover> Move(Rover rover)
        {
            switch (rover.VehicleLocation.Direction)
            {
                case CardinalDirection.N:
                    rover.VehicleLocation.YLocation += 1;
                    break;
                case CardinalDirection.E:
                    rover.VehicleLocation.XLocation += 1;
                    break;
                case CardinalDirection.S:
                    rover.VehicleLocation.YLocation -= 1;
                    break;
                case CardinalDirection.W:
                    rover.VehicleLocation.XLocation -= 1;
                    break;
                default:
                    return new Result<Rover>() { Success = false, Data = rover, ErrorMessage = ErrorCodes.INVALID_MOVEMENT_COMMAND };
            }
            return new Result<Rover>() { Success = true, Data = rover, ErrorMessage = string.Empty };
        }
        public Result<Rover> Turn(Rover rover, string command)
        {
            command = command.ToUpper();
            if(!Validation.ValidateMovementCommands(command)) return new Result<Rover>() { Success = false, Data = rover, ErrorMessage = ErrorCodes.INVALID_TURN_COMMAND };
            var newOrientation = rover.VehicleLocation.Direction;

            switch (rover.VehicleLocation.Direction)
            {
                case CardinalDirection.N:
                    newOrientation = command == "L" ? CardinalDirection.W : CardinalDirection.E;
                    break;
                case CardinalDirection.E:
                    newOrientation = command == "L" ? CardinalDirection.N : CardinalDirection.S;
                    break;
                case CardinalDirection.S:
                    newOrientation = command == "L" ? CardinalDirection.E : CardinalDirection.W;
                    break;
                case CardinalDirection.W:
                    newOrientation = command == "L" ? CardinalDirection.S : CardinalDirection.N;
                    break;
                default:
                    return new Result<Rover>() { Success = false, Data = rover, ErrorMessage = ErrorCodes.INVALID_TURN_COMMAND};
            }
            rover.VehicleLocation.Direction = newOrientation;

            return new Result<Rover>() { Success = true, Data = rover, ErrorMessage = string.Empty };
        }
    }
}
