using PracticeLib;

namespace PracticeLibUnitTests;

public class BitwiseOperatorTests
{
    [Fact]
    public void ComplementTest()
    {
        // Arrange
        int a = 0b000000000000000000000000000001;
        string expected = "11111111111111111111111111111110";

        // Act
        string actual = BitwiseOperator.Complement(a);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AndTest()
    {
        // Arrange
        int a = 0b000000000000000000000000001011;
        int b = 0b000000000000000000000000001101;
        string expected = "1001";

        // Act
        string actual = BitwiseOperator.And(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OrTest()
    {
        // Arrange
        int a = 0b000000000000000000000000001011;
        int b = 0b000000000000000000000000001101;
        string expected = "1111";

        // Act
        string actual = BitwiseOperator.Or(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void XorTest()
    {
        // Arrange
        int a = 0b000000000000000000000000001011;
        int b = 0b000000000000000000000000001101;
        string expected = "110";

        // Act
        string actual = BitwiseOperator.Xor(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShiftRightTest()
    {
        // Arrange
        int a = 0b100000000000000000000000001101;
        int b = 0b000000000000000000000000000010;
        string expected = "1000000000000000000000000011";

        // Act
        string actual = BitwiseOperator.ShiftRight(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShiftLeftTest()
    {
        // Arrange
        int a = 0b000000000000000000000000001011;
        int b = 0b000000000000000000000000000010;
        string expected = "101100";

        // Act
        string actual = BitwiseOperator.ShiftLeft(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void UnsignedShiftRightTest()
    {
        // Arrange
        int a = 0b100000000000000000000000000101;
        int b = 0b000000000000000000000000000010;
        string expected = "1000000000000000000000000001";

        // Act
        string actual = BitwiseOperator.UnsignedShiftRight(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }
}
