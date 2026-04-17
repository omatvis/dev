using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

public partial class NorthwindDb : DbContext
{
    public NorthwindDb()
    {
    }

    public NorthwindDb(DbContextOptions<NorthwindDb> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=172.26.219.91;Database=Northwind;User Id=sa;Password=Password6^;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ReorderLevel).HasDefaultValue((short)0, "DF_Products_ReorderLevel");
            entity.Property(e => e.UnitPrice).HasDefaultValue(0m, "DF_Products_UnitPrice");
            entity.Property(e => e.UnitsInStock).HasDefaultValue((short)0, "DF_Products_UnitsInStock");
            entity.Property(e => e.UnitsOnOrder).HasDefaultValue((short)0, "DF_Products_UnitsOnOrder");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_Products_Categories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
