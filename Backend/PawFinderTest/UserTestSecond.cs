using Xunit;
using PawFinderModel;
using System;
using Moq;
using PawFinderBL;
using System.Collections.Generic;
using PawFinderDL;
using System.Threading.Tasks;

namespace PawFinderTest;

public class UserTestSecond
{
    [Fact]
    public void RegisterUserExists()
    {
        //Arrange
        int userID = 1111;
        string userName = "Elk";
        string userPassword = "E132456";
        DateTime userDOB = DateTime.Today;
        string userBio = "Bio testing string";
        string userBreed = "Spitz";
        string userSize = "Big";
        string photoURL = "test.com";


        User expectedUser = new User()
        {
            UserID = userID,
            UserName = userName,
            UserPassword = userPassword,
            UserDOB = userDOB,
            UserBio = userBio,
            UserBreed = userBreed,
            UserSize = userSize,
            photoURL = photoURL
        };

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        List<User> newList = new List<User>();
        newList.Add(expectedUser);

        mockRepo.Setup(repo => repo.RegisterUser(expectedUser)).Returns(expectedUser);
        mockRepo.Setup(repo => repo.GetAllUsers()).Returns(newList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act and Assert
        Assert.Throws<Exception>(() => userBL.RegisterUser(expectedUser));

    }

    [Fact]
    public void RegisterUserNameNull()
    {
        //Arrange
        int userID = 1111;
        string userName = null;
        string userPassword = "E132456";
        DateTime userDOB = DateTime.Today;
        string userBio = "Bio testing string";
        string userBreed = "Spitz";
        string userSize = "Big";
        string photoURL = "test.com";


        User expectedUser = new User()
        {
            UserID = userID,
            UserName = userName,
            UserPassword = userPassword,
            UserDOB = userDOB,
            UserBio = userBio,
            UserBreed = userBreed,
            UserSize = userSize,
            photoURL = photoURL
        };

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        List<User> newList = new List<User>();

        mockRepo.Setup(repo => repo.RegisterUser(expectedUser)).Returns(expectedUser);
        mockRepo.Setup(repo => repo.GetAllUsers()).Returns(newList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act and Assert
        Assert.Throws<Exception>(() => userBL.RegisterUser(expectedUser));

    }

    public void RegisterUserBreedNull()
    {
        //Arrange
        int userID = 1111;
        string userName = "Elk";
        string userPassword = "E132456";
        DateTime userDOB = DateTime.Today;
        string userBio = "Bio testing string";
        string userBreed = null;
        string userSize = "Big";
        string photoURL = "test.com";


        User expectedUser = new User()
        {
            UserID = userID,
            UserName = userName,
            UserPassword = userPassword,
            UserDOB = userDOB,
            UserBio = userBio,
            UserBreed = userBreed,
            UserSize = userSize,
            photoURL = photoURL
        };

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        List<User> newList = new List<User>();

        mockRepo.Setup(repo => repo.RegisterUser(expectedUser)).Returns(expectedUser);
        mockRepo.Setup(repo => repo.GetAllUsers()).Returns(newList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act and Assert
        Assert.Throws<Exception>(() => userBL.RegisterUser(expectedUser));

    }

    public void RegisterUserPasswordNull()
    {
        //Arrange
        int userID = 1111;
        string userName = "Elk";
        string userPassword = null;
        DateTime userDOB = DateTime.Today;
        string userBio = "Bio testing string";
        string userBreed = "Spitz";
        string userSize = "Big";
        string photoURL = "test.com";


        User expectedUser = new User()
        {
            UserID = userID,
            UserName = userName,
            UserPassword = userPassword,
            UserDOB = userDOB,
            UserBio = userBio,
            UserBreed = userBreed,
            UserSize = userSize,
            photoURL = photoURL
        };

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        List<User> newList = new List<User>();

        mockRepo.Setup(repo => repo.RegisterUser(expectedUser)).Returns(expectedUser);
        mockRepo.Setup(repo => repo.GetAllUsers()).Returns(newList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act and Assert
        Assert.Throws<Exception>(() => userBL.RegisterUser(expectedUser));

    }

    public void RegisterUserSizeNull()
    {
        //Arrange
        int userID = 1111;
        string userName = "Elk";
        string userPassword = "E132456";
        DateTime userDOB = DateTime.Today;
        string userBio = "Bio testing string";
        string userBreed = "Spitz";
        string userSize = null;
        string photoURL = "test.com";


        User expectedUser = new User()
        {
            UserID = userID,
            UserName = userName,
            UserPassword = userPassword,
            UserDOB = userDOB,
            UserBio = userBio,
            UserBreed = userBreed,
            UserSize = userSize,
            photoURL = photoURL
        };

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        List<User> newList = new List<User>();

        mockRepo.Setup(repo => repo.RegisterUser(expectedUser)).Returns(expectedUser);
        mockRepo.Setup(repo => repo.GetAllUsers()).Returns(newList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act and Assert
        Assert.Throws<Exception>(() => userBL.RegisterUser(expectedUser));

    }
}