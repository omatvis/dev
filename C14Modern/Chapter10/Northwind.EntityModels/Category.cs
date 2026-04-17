using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.EntityModels
{
    public class Category 
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        [Column(TypeName = "ntext")]
        public string? Description { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new SortedSet<Product>();

    }
}
