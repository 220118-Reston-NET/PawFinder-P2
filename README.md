# PawFinder-P2

## Team Members:
Abdulkerim Metenea, Andrew DeMarco, Dat Vo, Nicolas Colorado, and Roberto Sandoval

## Project Name: 
PawFinder

## Overview
A place for dogs to meet and chat via instant messaging. Dogs will have their own profile that they can create when they sign up. Once they signup, they can update their bio and size any time in their profile screen. They are also able to like other dogs and if both like each other, they “match.” Matched dogs can then message each other. 

## Features
-Login/signup to create your own profile.

-Change your bio and size in the profile screen whenever you want to.

-Look at other user profiles in the like page and like/dislike them using the buttons at the bottom of their profile (Liking them will allow you two to match it they also like you back. Pressing either button will make them disappear from your like screen since you already did one of the two actions. You must wait to see if they end up liking you and you will match if that is the case).

-If you match with someone, they will showup in your matches page and you can then hit the button to chat with them. 

## Tech Stack

Backend
* C#
* LINQ
* JSON
* ADO.NET
* Xunit
* Serilog
* Azure DevOps
* ASP.NET WebAPI
* ASP.NET SignalR
* Swagger/ThunderClient
* Moq

Frontend
* HTML
* CSS
* JavaScript
* TypeScript
* Bootstrap
* JSON
* Angular

Others
* VS Code
* DBeaver
* Git
* GitHub
* SonarCloud


## Usage

# Backend:
Clone the repo.

cd into the projects API folder and run the cli command: dotnet run

Test the project in a local host: http://localhost:{yourport}/swagger/index.html

can run tests using dotnet test in the project's test folder.

Link to backend api: http://pawfinderwebapp.azurewebsites.net
Link to backend api with getallusers method: http://pawfinderwebapp.azurewebsites.net/api/PawFinder/GetAllUsers

# Frontend:
Clone the repo.

CD into project foldr and Run npm install in terminal.

Test project in local host by using command: ng serve and click on the local host link your terminal gives you for project.

Link to deployed app: https://pawfinderwebappfe.azurewebsites.net/
From there, you can signup or login to test other functionalities.

## Future Implementations

-Change the messaging to instant messaging using SignalR (in progress).

-Add a way to upload user images to their profile (in progress).

-Update the way users can find matches (make them able to select the way they find users. ex: by age, similar interests, breed, size, etc).

-Update styling to make pages more appealing.
