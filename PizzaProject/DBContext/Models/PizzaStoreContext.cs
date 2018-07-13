using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBContext.Models
{
    public partial class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext()
        {
        }

        public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LocationDb> LocationDb { get; set; }
        public virtual DbSet<OrderDb> OrderDb { get; set; }
        public virtual DbSet<UserDb> UserDb { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=platt-1806.database.windows.net,1433;Initial Catalog=PizzaStore;Persist Security Info=False;User ID=philipaplatt;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationDb>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("LocationDB");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Address).HasMaxLength(50);
            });

            modelBuilder.Entity<OrderDb>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("OrderDB");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.LocId).HasColumnName("LocID");

                entity.Property(e => e.Opizza1)
                    .HasColumnName("OPizza1")
                    .HasMaxLength(50);

                entity.Property(e => e.Opizza10)
                    .HasColumnName("OPizza10")
                    .HasMaxLength(50);

                entity.Property(e => e.Opizza11)
                    .HasColumnName("OPizza11")
                    .HasMaxLength(50);

                entity.Property(e => e.Opizza12)
                    .HasColumnName("OPizza12")
                    .HasMaxLength(50);

                entity.Property(e => e.Opizza2)
                    .HasColumnName("OPizza2")
                    .HasMaxLength(50);

                entity.Property(e => e.Opizza3)
                    .HasColumnName("OPizza3")
                    .HasMaxLength(50);

                entity.Property(e => e.Opizza4)
                    .HasColumnName("OPizza4")
                    .HasMaxLength(50);

                entity.Property(e => e.Opizza5)
                    .HasColumnName("OPizza5")
                    .HasMaxLength(50);

                entity.Property(e => e.Opizza6)
                    .HasColumnName("OPizza6")
                    .HasMaxLength(50);

                entity.Property(e => e.Opizza7)
                    .HasColumnName("OPizza7")
                    .HasMaxLength(50);

                entity.Property(e => e.Opizza8)
                    .HasColumnName("OPizza8")
                    .HasMaxLength(50);

                entity.Property(e => e.Opizza9)
                    .HasColumnName("OPizza9")
                    .HasMaxLength(50);

                entity.Property(e => e.TimeofOrder).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Loc)
                    .WithMany(p => p.OrderDb)
                    .HasForeignKey(d => d.LocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKtoLoc");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderDb)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKtoUser");
            });

            modelBuilder.Entity<UserDb>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserDB");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.DefaultStore).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });
        }
    }
}
