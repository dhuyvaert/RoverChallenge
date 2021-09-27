using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCommander.Models
{
    public class Area
    {
        public int XBoundary { get; set; }
        public int YBoundary { get; set; }
        public Area(int xLocation, int yLocation)
        {
            XBoundary = xLocation;
            YBoundary = yLocation;
        }
    }
}
