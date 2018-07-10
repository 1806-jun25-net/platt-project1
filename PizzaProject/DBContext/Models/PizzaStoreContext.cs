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

        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaOrder> PizzaOrder { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServe
       }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("LocationID");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.OrderLocNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderLoc)
                    .HasConstraintName("FK_Order_Location");

                entity.HasOne(d => d.OrderUserNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderUser)
                    .HasConstraintName("FK_Order_Order");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.PizzaId)
                    .HasColumnName("PizzaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.HasPep).HasColumnName("hasPep");

                entity.Property(e => e.HasPin).HasColumnName("hasPin");
            });

            modelBuilder.Entity<PizzaOrder>(entity =>
            {
                entity.HasKey(e => e.JunctionId);

                entity.Property(e => e.JunctionId)
                    .HasColumnName("JunctionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_PizzaOrder_Order");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK_PizzaOrder_Pizza");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });
        }
    }
}
