using Xunit;
using PawFinderModel;
using System;

namespace PawFinderTest;

public class LikeTest
{

        [Fact]
    public void TestDataInt()
    {

        //Arrange
        Like newLike = new Like();
        int likerId = 1111;
        int likedID = 2222;


        //Act
        newLike.LikedID = likedID;
        newLike.LikerID = likerId;

        //Assert
        Assert.NotNull(newLike.LikedID);
        Assert.Equal(likedID, newLike.LikedID);

        Assert.NotNull(newLike.LikerID);
        Assert.Equal(likerId, newLike.LikerID);

    }

}