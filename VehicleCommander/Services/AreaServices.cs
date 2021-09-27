using VehicleCommander.Constants;
using VehicleCommander.Interfaces;
using VehicleCommander.Models;

namespace VehicleCommander.Services
{
    public class AreaServices : IArea
    {
        public bool IsValidArea(int xLocation, int yLocation) =>
             (xLocation >= 0 && yLocation >= 0) ? true : false;
        public bool IsWithinBoundary(int xLocation, int yLocation, Area area) =>
            (xLocation > area.XBoundary || xLocation < 0) || (yLocation > area.YBoundary || yLocation < 0) ? false : true;
        public Result<Area> SetArea(int xLocation, int yLocation)
        {
            var valid = IsValidArea(xLocation, yLocation);
            return new Result<Area>()
            {
                Success = valid,
                Data = valid ? new Area(xLocation, yLocation) : new Area(0, 0),
                ErrorMessage = valid ? string.Empty : ErrorCodes.OUTSIDE_BOUNDARY_SET
            };
        }
            
    }
}
