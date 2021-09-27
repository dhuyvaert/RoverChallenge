using VehicleCommander.Enums;
using VehicleCommander.Models;

namespace VehicleCommander.Interfaces
{
    public interface ILocation
    {
        Result<Location> ParseLocationCommand(string locationCommand);
    }
}
