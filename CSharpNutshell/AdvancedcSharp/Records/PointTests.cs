using System;
using Xunit;

public class PointTests
{
    [Fact]
    public void Constructor_SetsCoordinatesCorrectly()
    {
        var point = new Point(3.0, 4.0);
        Assert.Equal(3.0, point.X);
        Assert.Equal(4.0, point.Y);
    }

    [Fact]
    public void DistanceFromOrigin_ComputesCorrectly()
    {
        var point = new Point(3.0, 4.0);
        Assert.Equal(5.0, point.DistanceFromOrigin, 10); // 3-4-5 triangle
    }

    [Fact]
    public void X_SetToNaN_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Point(double.NaN, 1.0));
    }

    [Fact]
    public void Y_SetToNaN_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Point(1.0, double.NaN));
    }

    [Fact]
    public void Deconstruct_ReturnsCorrectValues()
    {
        var point = new Point(7.0, 8.0);
        point.Deconstruct(out double x, out double y);
        Assert.Equal(7.0, x);
        Assert.Equal(8.0, y);
    }

    [Fact]
    public void ValueEquality_WorksForSameCoordinates()
    {
        var p1 = new Point(2.0, 2.0);
        var p2 = new Point(2.0, 2.0);
        Assert.Equal(p1, p2);
    }
}