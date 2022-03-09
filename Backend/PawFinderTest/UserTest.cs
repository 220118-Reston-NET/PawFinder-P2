using Xunit;
using PawFinderModel;
using System;
using Moq;
using PawFinderBL;
using System.Collections.Generic;
using PawFinderDL;

namespace PawFinderTest;

public class UserTest
{

    [Fact]
    public void TestDataString()
    {

        //Arrange
        User newUser = new User();
        string userName = "Geroge";
        string userPassword = "G12345";
        string userBio = "Husky. 21 years old. Enjoy long walks.";
        string userBreed = "Husky";
        string userSize = "Big";


        //Act
        newUser.UserName = userName;
        newUser.UserPassword = userPassword;
        newUser.UserBio = userBio;
        newUser.UserBreed = userBreed;
        newUser.UserSize = userSize;

        //Assert
        Assert.NotNull(newUser.UserName );
        Assert.Equal(userName, newUser.UserName);

        Assert.NotNull(newUser.UserPassword );
        Assert.Equal(userPassword, newUser.UserPassword);

        Assert.NotNull(newUser.UserBio );
        Assert.Equal(userBio, newUser.UserBio);

        Assert.NotNull(newUser.UserBreed );
        Assert.Equal(userBreed, newUser.UserBreed);

        Assert.NotNull(newUser.UserSize );
        Assert.Equal(userSize, newUser.UserSize);

    }

    [Fact]
    public void TestDataInt()
    {

        //Arrange
        User newUser = new User();
        int userID = 1111;


        //Act
        newUser.UserID = userID;

        //Assert
        Assert.NotNull(newUser.UserID );
        Assert.Equal(userID, newUser.UserID );

    }

    [Fact]
    public void TestDataOther()
    {

        //Arrange
        User newUser = new User();
        DateTime userDOB = DateTime.Today;


        //Act
        newUser.UserDOB = userDOB;

        //Assert
        Assert.NotNull(newUser.UserDOB);
        Assert.Equal(userDOB, newUser.UserDOB);

    }

    [Fact]
    public void GetAllUsers()
    {
        //Arrange
        int userID = 1111;
        string userName = "Elk";
        string userPassword = "E132456";
        DateTime userDOB = DateTime.Today;
        string userBio = "Bio testing string";
        string userBreed = "Spitz";
        string userSize = "Big";


        User newOrder = new User()
        {
            UserID = userID,
            UserName = userName,
            UserPassword = userPassword,
            UserDOB = userDOB,
            UserBio = userBio,
            UserBreed = userBreed,
            UserSize = userSize,


        };

        List<User> expectedList = new List<User>();
        expectedList.Add(newOrder);

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.GetAllUsers()).Returns(expectedList);

        IUserBL costumerBL = new UserBL(mockRepo.Object);

        //Act
        List<User> actualList = costumerBL.GetAllUsers();

        //Assert
        Assert.Equal(expectedList, actualList);
    }
    
}