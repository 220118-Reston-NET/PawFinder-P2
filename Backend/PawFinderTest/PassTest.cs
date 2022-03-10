using Xunit;
using PawFinderModel;
using System;

namespace PawFinderTest;

public class PassTest
{

    [Fact]
    public void TestDataInt()
    {

        //Arrange
        Pass newPass = new Pass();
        int passerID = 1111;
        int passeeID = 2222;


        //Act
        newPass.PasseeID = passeeID;
        newPass.PasserID = passerID;

        //Assert
        Assert.NotNull(newPass.PasseeID);
        Assert.Equal(passeeID, newPass.PasseeID);

        Assert.NotNull(newPass.PasserID);
        Assert.Equal(passerID, newPass.PasserID);

    }

}