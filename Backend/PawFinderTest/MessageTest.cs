using Xunit;
using PawFinderModel;
using System;

namespace PawFinderTest;

public class MessageTest
{

    [Fact]
    public void TestDataInt()
    {

        //Arrange
        Message newMassage = new Message();
        int messageID = 11111;
        int senderID = 2222;
        int receiverID = 3333;



        //Act
        newMassage.messageID = messageID;
        newMassage.SenderID = senderID;
        newMassage.ReceiverID = receiverID;

        //Assert
        Assert.NotNull(newMassage.messageID);
        Assert.Equal(messageID, newMassage.messageID);

        Assert.NotNull(newMassage.SenderID);
        Assert.Equal(senderID, newMassage.SenderID);

        Assert.NotNull(newMassage.ReceiverID);
        Assert.Equal(receiverID, newMassage.ReceiverID);

    }

    [Fact]
    public void TestDataString()
    {

        //Arrange
        Message newMassage = new Message();
        string messageText = "Test string message";

        //Act
        newMassage.messageText = messageText;

        //Assert
        Assert.NotNull(newMassage.messageText);
        Assert.Equal(messageText, newMassage.messageText);
    }

    [Fact]
    public void TestDataDateTime()
    {

        //Arrange
        Message newMassage = new Message();
        DateTime newDateTime = DateTime.Today;

        //Act
        newMassage.messageTimeStamp = newDateTime;

        //Assert
        Assert.NotNull(newMassage.messageTimeStamp);
        Assert.Equal(newDateTime, newMassage.messageTimeStamp);
    }

}