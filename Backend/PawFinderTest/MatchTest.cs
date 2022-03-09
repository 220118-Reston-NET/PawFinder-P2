using Xunit;
using PawFinderModel;
using System;

namespace PawFinderTest;

public class MatchTest
{

    [Fact]
    public void TestDataInt()
    {

        //Arrange
        Match newMatch = new Match();
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

}