## InfoTrack-WebScrapper

# Api Setup
To make the app work, please execute these commands: cd .\WebScrapper.Data and then dotent ef database update on visual studio console

# Spa Setup
To run the app, please, execute npm install to install all the project dependencies and then execute npm start

# Design
The app is running on .NET 5

The solution  is a N tier Web API that been splitted in 3 layers (Application, Domain, Data)
The architecture includes Depenency injection (DotNet.Core), Unit Of Work and repository pattern (I'm aware that can be a little too much for this small app, but i been told to show as much as i can)
Swagger is included so the API can be tested on localhost:5000/swagger

The Spa is in latest angular version (which i'm not familiarize with) but i wanted to do something extra, i don't have experience in angular (just angularjs)


Hope you like it and please, let me know if you have any question.

Regards
