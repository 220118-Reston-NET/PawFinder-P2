using Xunit;
using PawFinderModel;
using System;
using System.Collections.Generic;
using Moq;
using PawFinderBL;
using PawFinderDL;
using System.Threading.Tasks;

namespace PawFinderTest;

public class MatchTest
{

    [Fact]
    public void TestDataInt()
    {

        //Arrange
        PawFinderModel.Match newMatch = new PawFinderModel.Match();
        int matcherOneID = 1111;
        int matcherTwoID = 2222;


        //Act
        newMatch.MatcherOneID = matcherOneID;
        newMatch.MatcherTwoID = matcherTwoID;

        //Assert
        Assert.NotNull(newMatch.MatcherOneID);
        Assert.Equal(matcherOneID, newMatch.MatcherOneID);

        Assert.NotNull(newMatch.MatcherTwoID);
        Assert.Equal(matcherTwoID, newMatch.MatcherTwoID);

    }

    [Fact]
    public void GetPotentialMatch()
    {
        //Arrange
        int userID = 1111;
        string userName = "Elk";
        string userPassword = "E132456";
        DateTime userDOB = DateTime.Today;
        string userBio = "Bio testing string";
        string userBreed = "Spitz";
        string userSize = "Big";


        User newUser = new User()
        {
            UserID = userID,
            UserName = userName,
            UserPassword = userPassword,
            UserDOB = userDOB,
            UserBio = userBio,
            UserBreed = userBreed,
            UserSize = userSize,


        };

        int userIDTwo = 2222;
        string userNameTwo = "Nancy";
        string userPasswordTwo = "N132456";
        DateTime userDOBTwo = DateTime.Today;
        string userBioTwo = "Bio testing string";
        string userBreedTwo = "Spitz";
        string userSizeTwo = "Big";


        User newUserTwo = new User()
        {
            UserID = userIDTwo,
            UserName = userNameTwo,
            UserPassword = userPasswordTwo,
            UserDOB = userDOBTwo,
            UserBio = userBioTwo,
            UserBreed = userBreedTwo,
            UserSize = userSizeTwo,


        };

        List<User> expectedList = new List<User>();
        expectedList.Add(newUser);

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        
        mockRepo.Setup(repo => repo.GetAllUsers()).Returns(expectedList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        List<User> actualList = userBL.GetPotentialMatch(newUser);

        //Assert
        Assert.Equal(expectedList, actualList);
    }

}