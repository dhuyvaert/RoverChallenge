using System;
using System.Linq;
using VehicleCommander.Constants;
using VehicleCommander.Enums;
using VehicleCommander.Interfaces;
using VehicleCommander.Models;

namespace VehicleCommander.Services
{
    public class LocationService : ILocation
    {
        public Result<Location> ParseLocationCommand(string locationCommand)
        {
            if (string.IsNullOrWhiteSpace(locationCommand)) return new Result<Location>() { Success = false, Data = new Location(0, 0, CardinalDirection.N), ErrorMessage = ErrorCodes.INVALID_LOCATION };
            var locationCommands = locationCommand.Split(' ');
            if(locationCommands.Count() == 2)
            {
                var xLocationValid = int.TryParse(locationCommands[0], out int xLocation);
                var yLocationValid = int.TryParse(locationCommands[1], out int yLocation);
                return new Result<Location>()
                {
                    Success = (xLocationValid && yLocationValid),
                    Data = new Location(xLocation, yLocation, CardinalDirection.N),
                    ErrorMessage = (xLocationValid && yLocationValid) ? string.Empty : ErrorCodes.INVALID_LOCATION
                };
            }
            else
            {
                return new Result<Location>()
                {
                    Success = false,
                    Data = new Location(0, 0, CardinalDirection.N),
                    ErrorMessage = ErrorCodes.INVALID_LOCATION
                };
            }
        }
    }
}
