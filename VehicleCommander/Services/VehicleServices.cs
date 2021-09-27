using System;
using System.Linq;
using VehicleCommander.Constants;
using VehicleCommander.Enums;
using VehicleCommander.Interfaces;
using VehicleCommander.Models;
using VehicleCommander.Utility;

namespace VehicleCommander.Services
{
    public class VehicleServices : IVehicleActions<Rover>
    {
        public Result<Rover> CreateVehicle(string vehicleCommand, string vehicleName)
        {
            if (string.IsNullOrWhiteSpace(vehicleCommand)) return new Result<Rover>() { Success = false, Data = null, ErrorMessage = ErrorCodes.INVALID_VEHICLE_LOCATION };
            var locationCommands = vehicleCommand.Split(' ');
            if (locationCommands.Count() == 3)
            {
                var xLocationValid = int.TryParse(locationCommands[0], out int xLocation);
                var yLocationValid = int.TryParse(locationCommands[1], out int yLocation);
                var directionCommand = locationCommands[2].ToUpper();
                var directionValid = Enum.TryParse(directionCommand, out CardinalDirection direction);

                directionValid = (directionCommand == "N" || directionCommand == "S" || directionCommand == "E" || directionCommand == "W");
                return !xLocationValid || !yLocationValid || !directionValid
                    ? new Result<Rover>() { Success = false, Data = null, ErrorMessage = ErrorCodes.INVALID_VEHICLE_LOCATION }
                    : new Result<Rover>() { Success = true, Data = new Rover() { VehicleLocation = new Location(xLocation, yLocation, direction), VehicleName = vehicleName }, ErrorMessage = string.Empty };
            }
            else
            {
                return new Result<Rover>() { Success = false, Data = new Rover() { VehicleName = vehicleName }, ErrorMessage = ErrorCodes.INVALID_VEHICLE_LOCATION };
            }
        }
        public Result<Rover> SetMovementCommands(Rover rover, string commands)
        {
            if(string.IsNullOrWhiteSpace(commands) || !Validation.ValidateMovementCommands(commands)) return new Result<Rover>() { Success = false, Data = rover, ErrorMessage = ErrorCodes.INVALID_MOVEMENT_COMMAND_SET };
            
            rover.MovementCommands = commands.ToUpper().ToArray();
            return new Result<Rover>() { Success = true, Data = rover, ErrorMessage = string.Empty };
        }
    }
}
