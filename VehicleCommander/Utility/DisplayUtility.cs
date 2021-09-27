using System;

namespace VehicleCommander.Utility
{
    public static class DisplayUtility
    {
        public static void DisplayUserMessage(string errorMessage, string vehicleName = "")
        {
            if (!string.IsNullOrEmpty(vehicleName))
            {
                Console.WriteLine($"Rover {vehicleName} {errorMessage}");
            }
            else
            {
                Console.WriteLine(errorMessage);
            }
        }
    }
}
