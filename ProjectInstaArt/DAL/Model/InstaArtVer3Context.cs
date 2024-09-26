using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectInstaArt.DAL.Model
{
    public partial class InstaArtVer3Context : DbContext
    {
        public InstaArtVer3Context()
        {
        }

        public InstaArtVer3Context(DbContextOptions<InstaArtVer3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Import> Imports { get; set; } = null!;
        public virtual DbSet<ImportDetail> ImportDetails { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<PriceSetting> PriceSettings { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Shelf> Shelves { get; set; } = null!;
        public virtual DbSet<ShelvesHistory> ShelvesHistories { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9KB6FKU\\SQLEXPRESS;Database=InstaArtVer3; uid = sa; pwd = 123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName).HasMaxLength(200);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Phone);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Address).HasColumnType("ntext");

                entity.Property(e => e.Coin).HasColumnType("money");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Import>(entity =>
            {
                entity.Property(e => e.ImportId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.ImportDate).HasColumnType("date");

                entity.Property(e => e.Supplier).HasMaxLength(200);

                entity.HasOne(d => d.ImporterNavigation)
                    .WithMany(p => p.Imports)
                    .HasForeignKey(d => d.Importer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Imports_Users");
            });

            modelBuilder.Entity<ImportDetail>(entity =>
            {
                entity.Property(e => e.ImportDetailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BatchCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.ExpiredDate).HasColumnType("date");

                entity.Property(e => e.ImportId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManufactureDate).HasColumnType("date");

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Import)
                    .WithMany(p => p.ImportDetails)
                    .HasForeignKey(d => d.ImportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ImportDetails_Imports");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.ImportDetails)
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ImportDetails_Products");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.ImportDetails)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ImportDetails_Units");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Customer)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.OrderTitle).HasColumnType("ntext");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Customer)
                    .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.OrderDetailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImportDetailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.ImportDetail)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ImportDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_ImportDetails");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Products");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Unit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Units");
            });

            modelBuilder.Entity<PriceSetting>(entity =>
            {
                entity.HasKey(e => e.PriceRuleId);

                entity.Property(e => e.PriceRuleId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.PriceSettings)
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PriceSettings_Products");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.PriceSettings)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PriceSettings_Units");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductCode);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Company).HasMaxLength(250);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName).HasMaxLength(200);
            });

            modelBuilder.Entity<Shelf>(entity =>
            {
                entity.HasKey(e => e.ShelvesId);

                entity.Property(e => e.ShelvesId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImportDetailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.ImportDetail)
                    .WithMany(p => p.Shelves)
                    .HasForeignKey(d => d.ImportDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shelves_ImportDetails");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.Shelves)
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shelves_Products");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.Shelves)
                    .HasForeignKey(d => d.Unit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shelves_Units");
            });

            modelBuilder.Entity<ShelvesHistory>(entity =>
            {
                entity.Property(e => e.ShelvesHistoryId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.ImportDetailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.ImportDetail)
                    .WithMany(p => p.ShelvesHistories)
                    .HasForeignKey(d => d.ImportDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShelvesHistories_ImportDetails");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.ShelvesHistories)
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShelvesHistories_Products");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.ShelvesHistories)
                    .HasForeignKey(d => d.Unit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShelvesHistories_Units");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.StockId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImportDetailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.ImportDetail)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ImportDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stocks_ImportDetails");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stocks_Products");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stocks_Units");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.ProductCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UQ_Users_UserName")
                    .IsUnique();

                entity.Property(e => e.Address).HasColumnType("ntext");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
