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


==================Overview==================
This was actually a fun challange overall. I realized quickly that deciding to use a console application added a bit more complexity when a user input was invalid, 
so I ended up using a recursive pattern for some of the commands. I broke up the application by models and services and used program.cs for as little as possible. 
I was also thinking about reusability and placed a few common functions into utility classes.

As I was building out the logic, I was thinking of a number of possible failure points and the most common would be invalid input from the user. For each step that
required input, I validated right away and gave the user feedback to correct the input before moving on. Once all the data was collected, I executed the movement commands
in order and presented the user with an error and ability to correct the error in the event that the rover would have moved outside of the plateau. If the movement was
successful, I displayed that message along with the final coordinates of the rover.

Once I started the basic unit test, I discovered a few more edge cases that I had not accounted for in code and made the appropriate updates. If I were to continue working on
this project, I would add more tests to the various services and enhance the user display messages. I would also take another pass at refactoring the code to see what 
could be split out, consolidated or otherwise cleaned up to make this code even more efficient. 


