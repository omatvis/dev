using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Northwind.EntityModels
{
    public class Product : IComparable<Product>
    {
        public int ProductId { get; set; } // The primary key.

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; } = string.Empty;

        [Column("UnitPrice", TypeName = "money")]
        public decimal? Cost { get; set; }
        [Column("UnitsInStock")]
        public short? Stock { get; set; }
        public bool Discontinued { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return string.Compare(ProductName, other.ProductName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
