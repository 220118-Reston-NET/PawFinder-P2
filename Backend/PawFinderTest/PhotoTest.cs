using Xunit;
using PawFinderModel;
using System;

namespace PawFinderTest;

public class PhotoTest
{

    [Fact]
    public void TestDataInt()
    {

        //Arrange
        Photo newPhoto = new Photo();
        int photoID = 222;
        int userID = 2222;


        //Act
        newPhoto.photoID = photoID;
        newPhoto.userID = userID;

        //Assert
        Assert.NotNull(newPhoto.photoID);
        Assert.Equal(photoID, newPhoto.photoID);

        Assert.NotNull(newPhoto.userID);
        Assert.Equal(userID, newPhoto.userID);

    }

    [Fact]
    public void TestDataString()
    {

        //Arrange
        Photo newPhoto = new Photo();
        string fileName = "./fileName";

        //Act
        newPhoto.fileName = fileName;

        //Assert
        Assert.NotNull(newPhoto.fileName);
        Assert.Equal(fileName, newPhoto.fileName);

    }

} 