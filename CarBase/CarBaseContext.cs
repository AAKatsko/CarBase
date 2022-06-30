using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarBase
{
    public partial class CarBaseContext : DbContext
    {
        public CarBaseContext()
        {
        }

        public CarBaseContext(DbContextOptions<CarBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BodyTypeTable> BodyTypeTables { get; set; } = null!;
        public virtual DbSet<CarsTable> CarsTables { get; set; } = null!;
        public virtual DbSet<CompanyTable> CompanyTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=CarBase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BodyTypeTable>(entity =>
            {
                entity.ToTable("BodyTypeTable");

                entity.Property(e => e.BodyType)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CarsTable>(entity =>
            {
                entity.ToTable("CarsTable");

                entity.Property(e => e.Model)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.BodyTypeNavigation)
                    .WithMany(p => p.CarsTables)
                    .HasForeignKey(d => d.BodyType)
                    .HasConstraintName("Fk_Cars_To_Body");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.CarsTables)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("Fk_Cars_To_Company");
            });

            modelBuilder.Entity<CompanyTable>(entity =>
            {
                entity.ToTable("CompanyTable");

                entity.Property(e => e.Company)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
