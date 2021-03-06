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
        List<Photo> photoList = new List<Photo>();
        Photo newPhoto = new Photo();
        photoList.Add(newPhoto);

        //Act
        newUser.UserDOB = userDOB;
        newUser.Photo = photoList;

        //Assert
        Assert.NotNull(newUser.UserDOB);
        Assert.Equal(userDOB, newUser.UserDOB);

        Assert.Equal(photoList, newUser.Photo);

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
    public void GetUserByUsernameList()
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
    public void GetUserByUsername()
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

        mockRepo.Setup(repo => repo.GetUserByUsername("Elk")).Returns(expectedUser);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualUser = userBL.GetUserByUsername("Elk");

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

    // [Fact]
    // public void UpdateUser()
    // {
    //     //Arrange
    //     int userID = 1111;
    //     string userName = "Elk";
    //     string userPassword = "E132456";
    //     DateTime userDOB = DateTime.Today;
    //     string userBio = "Bio testing string";
    //     string userBreed = "Spitz";
    //     string userSize = "Big";


    //     User expectedUser = new User()
    //     {
    //         UserID = userID,
    //         UserName = userName,
    //         UserPassword = userPassword,
    //         UserDOB = userDOB,
    //         UserBio = userBio,
    //         UserBreed = userBreed,
    //         UserSize = userSize,
    //     };


    //     Mock<IRepository> mockRepo = new Mock<IRepository>();

    //     mockRepo.Setup(repo => repo.UpdateUser(expectedUser)).Returns(expectedUser);

    //     IUserBL userBL = new UserBL(mockRepo.Object);

    //     //Act
    //     User actualUser = userBL.UpdateUser(expectedUser);

    //     //Assert
    //     Assert.Equal(expectedUser, actualUser);
    // }

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
        
        mockRepo.Setup(repo => repo.AddPassedUserID(00000,11111)).Returns(expectedResult);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        int actualResult = userBL.AddPassedUserID(00000,11111);

        //Assert
        Assert.Equal(expectedResult, actualResult);
    }


    [Fact]
    public async Task SearchLikedUserAsync()
    {
        //Arrange
        int likerID = 11111;
        int likedID = 22222;

        Like newLike = new Like();
        newLike.LikerID = likerID;
        newLike.LikedID = likedID;

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        List<Like> newLikeList = new List<Like>();
        newLikeList.Add(newLike);
        
        
        mockRepo.Setup(repo => repo.GetLikedUserAsync(likerID)).ReturnsAsync(newLikeList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //ActexpectedList
        List<Like> actualList = await userBL.SearchLikedUserAsync(likerID,likedID);

        //Assert
        Assert.Equal(newLikeList, actualList);
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
    public async Task GetUserByUsernameAsync()
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

        mockRepo.Setup(repo => repo.GetUserByUsernameAsync("Elk")).ReturnsAsync(expectedUser);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualUser = await userBL.GetUserByUsernameAsync("Elk");

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

    [Fact]
    public async Task SearchPassedUserAsync()
    {
        //Arrange
        int userID = 11111;
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

        int userIdOne = 11111;

        List<int> newIntList = new List<int>();
        newIntList.Add(userIdOne);

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        
        mockRepo.Setup(repo => repo.GetUserAsync(userID)).ReturnsAsync(newUser);
        mockRepo.Setup(repo => repo.GetPassedUsersIDAsync(00000)).ReturnsAsync(newIntList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        List<User> actualResult = await userBL.SearchPassedUserAsync(00000,11111);

        //Assert
        Assert.Equal(newUser, actualResult[0]);
    }

    [Fact]
    public async Task UpdateUserBioSizeAsync()
    {
        //Arrange
        int userID = 1111;
        string userBio = "Bio testing string";
        string userSize = "Big";


        User expectedUser = new User()
        {
            UserID = userID,
            UserBio = userBio,
            UserSize = userSize,
        };


        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.UpdateUserBioSizeAsync(expectedUser.UserID, expectedUser.UserBio, expectedUser.UserSize)).ReturnsAsync(expectedUser);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualUser = await userBL.UpdateUserBioSizeAsync(expectedUser.UserID, expectedUser.UserBio, expectedUser.UserSize);

        //Assert
        Assert.Equal(expectedUser, actualUser);
    }

     [Fact]
    public async Task UpdateUserBioAsync()
    {
        //Arrange
        int userID = 1111;
        string userBio = "Bio testing string";
        string userSize = null;


        User expectedUser = new User()
        {
            UserID = userID,
            UserBio = userBio,
            UserSize = userSize,
        };


        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.UpdateUserBioAsync(expectedUser.UserID, expectedUser.UserBio)).ReturnsAsync(expectedUser);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualUser = await userBL.UpdateUserBioSizeAsync(expectedUser.UserID, expectedUser.UserBio, expectedUser.UserSize);

        //Assert
        Assert.Equal(expectedUser, actualUser);
    }

     [Fact]
    public async Task UpdateUserSizeAsync()
    {
        //Arrange
        int userID = 1111;
        string userBio = null;
        string userSize = "Big";


        User expectedUser = new User()
        {
            UserID = userID,
            UserBio = userBio,
            UserSize = userSize,
        };


        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.UpdateUserSizeAsync(expectedUser.UserID, expectedUser.UserSize)).ReturnsAsync(expectedUser);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualUser = await userBL.UpdateUserBioSizeAsync(expectedUser.UserID, expectedUser.UserBio, expectedUser.UserSize);

        //Assert
        Assert.Equal(expectedUser, actualUser);
    }

    [Fact]
    public async Task AddPhotoAsync()
    {
        //Arrange
        Photo expectedPhoto = new Photo();

        

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.AddPhotoAsync(expectedPhoto)).ReturnsAsync(expectedPhoto);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        Photo actualPhoto = await userBL.AddPhotoAsync(expectedPhoto);

        //Assert
        Assert.Equal(expectedPhoto, actualPhoto);
    }

    [Fact]
    public async Task GetPhotobyUserIDAsync()
    {
        //Arrange
        Photo expectedPhoto = new Photo();
        int userId = 11111;

        List<Photo> expectedPhotoList = new List<Photo>();
        expectedPhotoList.Add(expectedPhoto);

        

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.GetPhotobyUserIDAsync(userId)).ReturnsAsync(expectedPhotoList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        List<Photo> actualPhotoList = await userBL.GetPhotobyUserIDAsync(userId);

        //Assert
        Assert.Equal(expectedPhotoList, actualPhotoList);
    }

    [Fact]
    public async Task GetLikedUserAsync()
    {
        //Arrange
        int likerID = 11111;
        int likedID = 22222;

        Like newLike = new Like();
        newLike.LikerID = likerID;
        newLike.LikedID = likedID;

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        List<Like> newLikeList = new List<Like>();
        newLikeList.Add(newLike);
        
        
        mockRepo.Setup(repo => repo.GetLikedUserAsync(likerID)).ReturnsAsync(newLikeList);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //ActexpectedList
        List<Like> actualList = await userBL.GetLikedUserAsync(likerID);

        //Assert
        Assert.Equal(newLikeList, actualList);
    }

    [Fact]
    public void AddLikedUser()
    {
        //Arrange
        int userID = 11111;
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

        int likerID = 11111;
        int likedID = 22222;

        Like newLike = new Like();
        newLike.LikerID = likerID;
        newLike.LikedID = likedID;

        Like newLikeTwo = new Like();
        newLikeTwo.LikerID = likedID;
        newLikeTwo.LikedID = likerID;

        PawFinderModel.Match newMatch = new PawFinderModel.Match();
        newMatch.MatcherOneID = likerID;
        newMatch.MatcherTwoID = likedID;

        List<Like> newLikeList = new List<Like>();
        newLikeList.Add(newLikeTwo);

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        
        mockRepo.Setup(repo => repo.GetLikedUser(likedID)).Returns(newLikeList);
        mockRepo.Setup(repo => repo.AddMatch(likerID,likedID)).Returns(newMatch);
        mockRepo.Setup(repo => repo.AddLikedUser(likerID,likedID)).Returns(newUser);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualResult = userBL.AddLikedUser(likerID,likedID);

        //Assert
        Assert.Equal(newUser, actualResult);

    }

    [Fact]
    public async Task AddLikedUserAsync()
    {
        //Arrange
        int userID = 11111;
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

        int likerID = 11111;
        int likedID = 22222;

        Like newLike = new Like();
        newLike.LikerID = likerID;
        newLike.LikedID = likedID;

        Like newLikeTwo = new Like();
        newLikeTwo.LikerID = likedID;
        newLikeTwo.LikedID = likerID;

        PawFinderModel.Match newMatch = new PawFinderModel.Match();
        newMatch.MatcherOneID = likerID;
        newMatch.MatcherTwoID = likedID;

        List<Like> newLikeList = new List<Like>();
        newLikeList.Add(newLikeTwo);

        Mock<IRepository> mockRepo = new Mock<IRepository>();
        
        mockRepo.Setup(repo => repo.GetLikedUserAsync(likedID)).ReturnsAsync(newLikeList);
        mockRepo.Setup(repo => repo.AddMatchAsync(likerID,likedID)).ReturnsAsync(newMatch);
        mockRepo.Setup(repo => repo.AddLikedUserAsync(likerID,likedID)).ReturnsAsync(newUser);

        IUserBL userBL = new UserBL(mockRepo.Object);

        //Act
        User actualResult = await userBL.AddLikedUserAsync(likerID,likedID);

        //Assert
        Assert.Equal(newUser, actualResult);

    }


}