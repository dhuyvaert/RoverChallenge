***Vehicle Commander Application***
***Execuate application***
This .NET5 Application can be run directly in Visual Studio or using PowerShell to build the project and execute the application.
To use the Powershell command, navigate to the directory of this source code and run dotnet build. This will create a bin file within the directory and an
EXE file called VehicleCommander.exe. Double click this application to run.

Open the application and you will be promped to start the process by entering an area that represents a plateau.
The plateau must be a positive number and entered in the format of X Y, for example 4 4.

Once you have an area established, you must create two rover vehicles that include their initial location.
You will be prompted to enter the initial location in the format of X location, Y location and the direction the rover is facing, for example 2 3 N.

After successfully creating the rover vehicle, you will be prompted to enter the movement commands in the order you wish to move the rover, for example RMLMMR.
The valid movements are to turn or move forward one space. 
To move forward, use the letter M.
To turn right, use the letter R.
To turn left use the letter L.

These steps will be repeated for the second rover vehicle.

Once you have 2 valid rovers and movement instructions, the application will perform the movements you have entered and will display the final location of the rovers.

***Testing***
Unit tests can be executed directly through Visual Studio or by opening PowerShell on a Windows computer.
To run the test command, open PowerShell and change the directory to the working directoy of this project.
Enter the command 'dotnet test' to run tests and view results.