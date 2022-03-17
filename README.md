# PawFinder-P2

Team Members:
Abdulkerim Metenea, Andrew DeMarco, Dat Vo, Nicolas Colorado, and Roberto Sandoval

Team Name: 
DAARN

Project Name: 
PawFinder

Overview
	A place for dogs to meet and chat via instant messaging. Dogs will have their own profile with image(s) and a bio that they upload from their profile screen. They will be able to like other dogs and if both like each other, they “match.” Matched dogs can then message each other. 

Tables

User

-userID

-username

-uassword

-Name

-DOB

-Bio

-Breed

-Size (small, med, large)

UserPicture

-UserID (foreign key UserID)

-PictureID
	
Like

-LikerUserID (foreign key UserID)

-LikedUserID (foreign key UserID)

Pass

-PassedByUserID (foreign key UserID)

-PasseeUserID (foreign key UserID)

Match

-MatchedUserID (foreign key UserID)

-MatcheeUserID (foreign key UserID)


User Stories

-As a user, I would like to be able to have a way to login with my credentials to see my own profile information.

-As a user, if I do not have an account already, I would like a way to register for one.

-As a user, I would like to have a way of viewing other dogs' profiles.

-As a user, I would like a way to “like” or “dislike” them.

-As a user, I would like to be able to change my profile whenever I want to. 

-As a user, I would like to be able to view all the user’s I have matched with on a chat screen.

-As a user, I would like to be able to chat with whoever I match with.

-As a user, I would like a nice UI to be able to view all the functionalities of the app.

-As a user, I would like to filter the profiles I can view based on my preferences (breed, age range, and size).

-As a user, I would not like to see profiles I have already matched with, liked, or passed. 


Scope Goals

Adding better security/security to the user login

Add a friend list.

Add a more advanced filtering algorithm to view and match dogs based on similar interests and prefferences (age, breed, key words in bio, etc)


Tech Stack

Backend

-C#

-LINQ

-JSON

-ADO.NET

-Xunit

-Serilog

-Azure DevOps

-ASP.NET WebAPI

-ASP.NET SignalR

-Swagger/ThunderClient

-Moq


Frontend

-TML

-cSS

-javaScript

-typescript

-bootstrap

-JSON

-Angular

Others

-VS Code

-DBeaver

-Git

-GitHub

-SonarCloud


Methods for Backend

-(all methods will be asynchronous)

-(Business layers: UserBL, ChatMessageBL, 

-DL Methods

-GetAllUsers (Done)

-GetUser (Done)

-RegisterUsers (Done)

-UpdateUsers (Done)

-ViewMatchedUsers (Done)

-CreateUserID (Done)

-CreatePictureID (not needed)

-CreateConversationID (not needed)

-GetChatHistory (Done)

-AddMessage (Done)

BL Methods

-FindUserByUsername(Done)

-RegisterUser (Done)

Repository Methods

Things to do in each section
Database
Way to save pictures
Way to save chats
