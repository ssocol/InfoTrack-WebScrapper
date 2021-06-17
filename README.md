# InfoTrack-WebScrapper

# Setup
To make the app work, please execute these commands: cd .\WebScrapper.Data and then dotent ef database update on visual studio console

# Design
The app is running on .NET 5

The solution  is a N tier Web API that been splitted in 3 layers (Application, Domain, Data)
The architecture includes Depenency injection (DotNet.Core), Unit Of Work and repository pattern (I'm aware that can be a little too much for this small app, but i been told to show as much as i can)
Swagger is included so the API can be tested on localhost:5000/swagger
