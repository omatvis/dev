using Packt.Shared;

namespace Northwind.Common.UnitTests;

public class EntityModelTests
{
    [Fact]
    public void DatabaseConnectTest()
    {
        using var db = new NorthwindContext();
        Assert.True(db.Database.CanConnect());
    }

    [Fact]
    public void CategoryCountTest()
    {
        using var db = new NorthwindContext();
        int expected = 8;
        int actual = db.Categories.Count();
        Assert.Equal(expected, actual);
    }
}
