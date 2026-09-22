using Northwind.DataContext.SqlServer;

namespace Northwind.UnitTests
{
    public class EntityModelTests
    {
        [Fact]
        public void DatabaseConnectTest() 
        {
            using NorthwindContext db = new();
            Assert.True(db.Database.CanConnect());
        }

        [Fact]
        public void CountCategoriesTest()
        {
            using NorthwindContext db = new();
            int categoryCount = db.Categories.Count();
            Assert.Equal(8, categoryCount);
        }

        [Fact]
        public void CheckProductWithKey1IsChai()
        {
            using NorthwindContext db = new();
            var product = db.Products.Find(1);
            Assert.NotNull(product);
            Assert.Equal("Chai", product.ProductName);
        }
    }
}
