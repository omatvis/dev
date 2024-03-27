namespace PrimeFactorUnitTests;

using static PrimeFactorLib.PrimeFactorLib;

public class PrimeFactorUnitTests
{
    [Fact]
    public void TestIfValueIsOutOfRange()
    {
        // arrange
        int n = 1001;
        // act
        Action act = () => PrimeFactors(n);
        // assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void TestPrimeFactorsOfFour() {
        // arrange
        int n = 4;
        // act
        string expectedResult = PrimeFactors(n);
        // assert
        string actualResut = "2 x 2";
        Assert.Equal(expectedResult, actualResut);
    }

    [Fact]
    public void TestPrimeFactorsOfSeven() {
        // arrange
        int n = 7;
        // act
        string expectedResult = PrimeFactors(n);
        // assert
        string actualResut = "7";
        Assert.Equal(expectedResult, actualResut);
    } 
    [Fact]
    public void TestPrimeFactorsOfThirty() {
        // arrange
        int n = 30;
        // act
        string expectedResult = PrimeFactors(n);
        // assert
        string actualResut = "5 x 3 x 2";
        Assert.Equal(expectedResult, actualResut);
    }       

    [Fact]
    public void TestPrimeFactorsOfForty() {
        // arrange
        int n = 40;
        // act
        string expectedResult = PrimeFactors(n);
        // assert
        string actualResut = "5 x 2 x 2 x 2";
        Assert.Equal(expectedResult, actualResut);
    }

    [Fact]
    public void TestPrimeFactorsOfFifty() {
        // arrange
        int n = 50;
        // act
        string expectedResult = PrimeFactors(n);
        // assert
        string actualResut = "5 x 5 x 2";
        Assert.Equal(expectedResult, actualResut);
    }        
}