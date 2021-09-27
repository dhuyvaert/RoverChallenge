using System.Linq;

namespace VehicleCommander.Utility
{
    public static class Validation
    {
        public static bool ValidateMovementCommands(string commandList)
        {
            var commands = commandList.ToArray();
            foreach (var command in commands)
            {
                var singleCommand = command.ToString().ToUpper();
                if (singleCommand != "M" && singleCommand != "L" && singleCommand != "R") return false;
            }
            return true;
        }
    }
}
