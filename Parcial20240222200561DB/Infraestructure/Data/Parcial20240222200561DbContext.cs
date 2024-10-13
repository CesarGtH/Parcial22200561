using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Parcial20240222200561DB.Infraestructure.Data;

public partial class Parcial20240222200561DbContext : DbContext
{
    public Parcial20240222200561DbContext()
    {
    }

    public Parcial20240222200561DbContext(DbContextOptions<Parcial20240222200561DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AutoParts> AutoParts { get; set; }

    public virtual DbSet<Mechanic> Mechanic { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Parcial20240222200561DB;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AutoParts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AutoPart__3214EC07298DC07F");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.PartName).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Mechanic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mechanic__3214EC070E24670A");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
