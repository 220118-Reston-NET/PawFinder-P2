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
    public void GetUserByName()
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
        List<User> actualList = userBL.SearchUser("Elk");

        //Assert
        Assert.Equal(expectedList, actualList);
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

        mockRepo.Setup(repo => repo.ViewMatchedUser(1111)).Returns(expectedList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        List<User> actualList = userBL.ViewMatchedUser(1111);

        //Assert
        Assert.Equal(expectedList, actualList);
    }

    [Fact]
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
    public void AddMessage()
    {
        //Arrange
        int messageID = 123456;
        int senderID = 1111;
        int receiverID = 2222;
        string messageText = "Message test string";
        DateTime timeStamp = DateTime.Today;

        Message expectedMessage = new Message()
        {
            messageID = messageID,
            SenderID = senderID,
            ReceiverID = receiverID,
            messageText = messageText,
            messageTimeStamp = timeStamp
        };


        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.AddMessage(expectedMessage)).Returns(expectedMessage);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        Message actualMessage = userBL.AddMessage(expectedMessage);

        //Assert
        Assert.Equal(expectedMessage, actualMessage);
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

    [Fact]
    public void GetPassedUsersID()
    {
        //Arrange
        List<int> expectedList = new List<int>();
        expectedList.Add(11111);
        expectedList.Add(22222);

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        
        //mockRepo.Setup(repo => repo.GetAllUsers()).Returns(expectedList);
        mockRepo.Setup(repo => repo.GetPassedUsersID(00000)).Returns(expectedList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        List<int> actualList = userBL.GetPassedUsersID(00000);

        //Assert
        Assert.Equal(expectedList, actualList);
    }

    [Fact]
    public void AddPassedUserID()
    {
        //Arrange
        int expectedResult = 11111;

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        
        //mockRepo.Setup(repo => repo.GetAllUsers()).Returns(expectedList);
        mockRepo.Setup(repo => repo.AddPassedUserID(00000,11111)).Returns(expectedResult);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        int actualResult = userBL.AddPassedUserID(00000,11111);

        //Assert
        Assert.Equal(expectedResult, actualResult);
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
    public async Task RegisterUserAsync()
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

        mockRepo.Setup(repo => repo.RegisterUserAsync(expectedUser)).ReturnsAsync(expectedUser);
        mockRepo.Setup(repo => repo.GetAllUsers()).Returns(new List<User>());

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualUser = await userBL.RegisterUserAsync(expectedUser);

        //Assert
        Assert.Equal(expectedUser, actualUser);
    }

    [Fact]
    public async Task ViewMatchedUserAsync()
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

        mockRepo.Setup(repo => repo.ViewMatchedUserAsync(1111)).ReturnsAsync(expectedList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        List<User> actualList = await userBL.ViewMatchedUserAsync(1111);

        //Assert
        Assert.Equal(expectedList, actualList);
    }

    [Fact]
    public async Task UpdateUserAsync()
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

        mockRepo.Setup(repo => repo.UpdateUserAsync(expectedUser)).ReturnsAsync(expectedUser);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualUser = await userBL.UpdateUserAsync(expectedUser);

        //Assert
        Assert.Equal(expectedUser, actualUser);
    }

    [Fact]
    public async Task GetConversationAsync()
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

        mockRepo.Setup(repo => repo.GetConversationAsync(1111,2222)).ReturnsAsync(expectedList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        List<Message> actualList = await userBL.GetConversationAsync(1111,2222);

        //Assert
        Assert.Equal(expectedList, actualList);
    }

    [Fact]
    public async Task AddMessageAsync()
    {
        //Arrange
        int messageID = 123456;
        int senderID = 1111;
        int receiverID = 2222;
        string messageText = "Message test string";
        DateTime timeStamp = DateTime.Today;

        Message expectedMessage = new Message()
        {
            messageID = messageID,
            SenderID = senderID,
            ReceiverID = receiverID,
            messageText = messageText,
            messageTimeStamp = timeStamp
        };


        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.AddMessageAsync(expectedMessage)).ReturnsAsync(expectedMessage);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        Message actualMessage = await userBL.AddMessageAsync(expectedMessage);

        //Assert
        Assert.Equal(expectedMessage, actualMessage);
    }

    [Fact]
    public async Task GetUserByNameAsync()
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

        mockRepo.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(expectedList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        List<User> actualList = await userBL.SearchUserAsync("Elk");

        //Assert
        Assert.Equal(expectedList, actualList);
    }

    [Fact]
    public async Task GetPassedUsersIDAsync()
    {
        //Arrange
        List<int> expectedList = new List<int>();
        expectedList.Add(11111);
        expectedList.Add(22222);

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        
        //mockRepo.Setup(repo => repo.GetAllUsers()).Returns(expectedList);
        mockRepo.Setup(repo => repo.GetPassedUsersIDAsync(00000)).ReturnsAsync(expectedList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        List<int> actualList = await userBL.GetPassedUsersIDAsync(00000);

        //Assert
        Assert.Equal(expectedList, actualList);
    }

    [Fact]
    public async Task AddPassedUserIDAsync()
    {
        //Arrange
        int expectedResult = 11111;

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        
        //mockRepo.Setup(repo => repo.GetAllUsers()).Returns(expectedList);
        mockRepo.Setup(repo => repo.AddPassedUserIDAsync(00000,11111)).ReturnsAsync(expectedResult);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        int actualResult = await userBL.AddPassedUserIDAsync(00000,11111);

        //Assert
        Assert.Equal(expectedResult, actualResult);
    }
    
}