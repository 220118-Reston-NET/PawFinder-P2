using Xunit;
using PawFinderModel;

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

    /*

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public DateTime UserDOB { get; set; }
        public string UserBio { get; set; }
        public string UserBreed { get; set; }
        public string UserSize { get; set; }

    */

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
    
}