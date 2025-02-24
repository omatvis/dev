using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoadCertificate;

public partial class FinanceContext : DbContext
{
    public FinanceContext() { }

    public FinanceContext(DbContextOptions<FinanceContext> options)
        : base(options) { }

    public virtual DbSet<CoBatch> CoBatches { get; set; }

    public virtual DbSet<ScCertdet> ScCertdets { get; set; }

    public virtual DbSet<ScCertdist> ScCertdists { get; set; }

    public virtual DbSet<ScCertificate> ScCertificates { get; set; }

    public virtual DbSet<ScCertitem> ScCertitems { get; set; }

    public virtual DbSet<ScVatdist> ScVatdists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(
            "Server=127.0.0.1;Database=Finance;User Id=sa;Password=Testing1122;TrustServerCertificate=True;"
        );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoBatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__co_batch__3213E83F501E8473");
        });

        modelBuilder.Entity<ScCertdet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sc_certd__3213E83F9604AF3E");

            entity.Property(e => e.CdfPeriod).IsFixedLength();

            entity
                .HasOne(d => d.ScCertificate)
                .WithMany(p => p.ScCertdets)
                .HasConstraintName("FK__sc_certde__sc_ce__3F466844");
        });

        modelBuilder.Entity<ScCertdist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sc_certd__3213E83F875F8AED");

            entity
                .HasOne(d => d.ScCertificate)
                .WithMany(p => p.ScCertdists)
                .HasConstraintName("FK__sc_certdi__sc_ce__3C69FB99");
        });

        modelBuilder.Entity<ScCertificate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sc_certi__3213E83FE9927170");

            entity.Property(e => e.ContraPayment).IsFixedLength();
            entity.Property(e => e.SbpStatus).IsFixedLength();
            entity.Property(e => e.SbpZero).IsFixedLength();

            entity
                .HasOne(d => d.CoBatch)
                .WithMany(p => p.ScCertificates)
                .HasConstraintName("FK__sc_certif__co_ba__398D8EEE");
        });

        modelBuilder.Entity<ScCertitem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sc_certi__3213E83FED353F0C");

            entity.Property(e => e.SbiCat).IsFixedLength();

            entity
                .HasOne(d => d.ScCertificate)
                .WithMany(p => p.ScCertitems)
                .HasConstraintName("FK__sc_certit__sc_ce__44FF419A");
        });

        modelBuilder.Entity<ScVatdist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sc_vatdi__3213E83F5CCB8627");

            entity
                .HasOne(d => d.ScCertificate)
                .WithMany(p => p.ScVatdists)
                .HasConstraintName("FK__sc_vatdis__sc_ce__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
