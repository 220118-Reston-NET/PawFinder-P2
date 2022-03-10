using Xunit;
using PawFinderModel;
using System;
using Moq;
using PawFinderBL;
using System.Collections.Generic;
using PawFinderDL;
using System.Threading.Tasks;

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
        string photoURL = "test.com";


        //Act
        newUser.UserDOB = userDOB;
        newUser.photoURL = photoURL;

        //Assert
        Assert.NotNull(newUser.UserDOB);
        Assert.Equal(userDOB, newUser.UserDOB);

        Assert.NotNull(newUser.photoURL);
        Assert.Equal(photoURL, newUser.photoURL);

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

        List<User> expectedList = new List<User>();
        expectedList.Add(newUser);

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.GetAllUsers()).Returns(expectedList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        List<User> actualList = userBL.GetAllUsers();

        //Assert
        Assert.Equal(expectedList, actualList);
    }

    [Fact]
    public void GetUserByID()
    {
        //Arrange
        int userID = 1111;
        string userName = "Elk";
        string userPassword = "E132456";
        DateTime userDOB = DateTime.Today;
        string userBio = "Bio testing string";
        string userBreed = "Spitz";
        string userSize = "Big";


        User expectedUser = new User()
        {
            UserID = userID,
            UserName = userName,
            UserPassword = userPassword,
            UserDOB = userDOB,
            UserBio = userBio,
            UserBreed = userBreed,
            UserSize = userSize,


        };

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.GetUser(1111)).Returns(expectedUser);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualUser = userBL.GetUser(1111);

        //Assert
        Assert.Equal(expectedUser, actualUser);
    }

    [Fact]
    public void RegisterUser()
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

        mockRepo.Setup(repo => repo.RegisterUser(expectedUser)).Returns(expectedUser);
        mockRepo.Setup(repo => repo.GetAllUsers()).Returns(new List<User>());

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualUser = userBL.RegisterUser(expectedUser);

        //Assert
        Assert.Equal(expectedUser, actualUser);
    }

    [Fact]
    public void ViewMatchedUser()
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


        User newUser = new User()
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

        List<User> expectedList = new List<User>();
        expectedList.Add(newUser);

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.ViewMatchedUser(1111)).Returns(expectedList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        List<User> actualList = userBL.ViewMatchedUser(1111);

        //Assert
        Assert.Equal(expectedList, actualList);
    }

    public void UpdateUser()
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

        mockRepo.Setup(repo => repo.UpdateUser(expectedUser)).Returns(expectedUser);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualUser = userBL.UpdateUser(expectedUser);

        //Assert
        Assert.Equal(expectedUser, actualUser);
    }

    [Fact]
    public void GetConversation()
    {
        //Arrange
        int messageID = 123456;
        int senderID = 1111;
        int receiverID = 2222;
        string messageText = "Message test string";
        DateTime timeStamp = DateTime.Today;

        Message newMessage = new Message()
        {
            messageID = messageID,
            SenderID = senderID,
            ReceiverID = receiverID,
            messageText = messageText,
            messageTimeStamp = timeStamp
        };


        List<Message> expectedList = new List<Message>();
        expectedList.Add(newMessage);

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.GetConversation(1111,2222)).Returns(expectedList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        List<Message> actualList = userBL.GetConversation(1111,2222);

        //Assert
        Assert.Equal(expectedList, actualList);
    }

    [Fact]
    public async Task GetAllUsersAsync()
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


        User newUser = new User()
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

        List<User> expectedList = new List<User>();
        expectedList.Add(newUser);

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(expectedList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        List<User> actualList = await userBL.GetAllUsersAsync();

        //Assert
        Assert.Equal(expectedList, actualList);
    }

    [Fact]
    public async Task GetUserByIDAsync()
    {
        //Arrange
        int userID = 1111;
        string userName = "Elk";
        string userPassword = "E132456";
        DateTime userDOB = DateTime.Today;
        string userBio = "Bio testing string";
        string userBreed = "Spitz";
        string userSize = "Big";


        User expectedUser = new User()
        {
            UserID = userID,
            UserName = userName,
            UserPassword = userPassword,
            UserDOB = userDOB,
            UserBio = userBio,
            UserBreed = userBreed,
            UserSize = userSize,


        };

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.GetUserAsync(1111)).ReturnsAsync(expectedUser);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualUser = await userBL.GetUserAsync(1111);

        //Assert
        Assert.Equal(expectedUser, actualUser);
    }

        [Fact]
    public async void RegisterUserAsync()
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

        mockRepo.Setup(repo => repo.RegisterUserAsync(expectedUser)).ReturnsAsync(expectedUser);
        mockRepo.Setup(repo => repo.GetAllUsers()).Returns(new List<User>());

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualUser = await userBL.RegisterUserAsync(expectedUser);

        //Assert
        Assert.Equal(expectedUser, actualUser);
    }
    
}