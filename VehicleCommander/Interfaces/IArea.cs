using VehicleCommander.Models;

namespace VehicleCommander.Interfaces
{
    public interface IArea
    {
        bool IsWithinBoundary(int xLocation, int yLocation, Area area);
        bool IsValidArea(int xLocation, int yLocation);
        Result<Area> SetArea(int xLocation, int yLocation);
    }
}
