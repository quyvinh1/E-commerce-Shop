using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAssignment.Models
{
    public partial class PRN211_ProjectContext : DbContext
    {
        public PRN211_ProjectContext()
        {
        }

        public PRN211_ProjectContext(DbContextOptions<PRN211_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderLine> OrderLines { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserInfo> UserInfos { get; set; } = null!;
        public virtual DbSet<WishList> WishLists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=123;database=PRN211_Project;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Bid)
                    .HasName("PK__Brand__DE90ADE7A814EEF9");

                entity.ToTable("Brand");

                entity.Property(e => e.Bid).HasColumnName("bid");

                entity.Property(e => e.Bname)
                    .HasMaxLength(255)
                    .HasColumnName("bname");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DateOrder)
                    .HasColumnType("date")
                    .HasColumnName("Date_order");

                entity.Property(e => e.TotalPrice).HasColumnName("Total_price");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__User_id__3E52440B");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OrderLine");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderLine__Order__44FF419A");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderLine__Produ__440B1D61");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCategoryId).HasColumnName("Product_category_id");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Product__BrandId__628FA481");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .HasConstraintName("FK__Product__Product__398D8EEE");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("Product_Category");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Category_name");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.DatePost)
                    .HasColumnType("date")
                    .HasColumnName("Date_post");

                entity.Property(e => e.Review1).HasColumnName("Review");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Review__ProductI__4222D4EF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Review__UserId__412EB0B6");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserInfo");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Avatar).HasColumnName("avatar");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UId).HasColumnName("uID");

                entity.HasOne(d => d.UIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("FK__UserInfo__uID__6477ECF3");
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.ToTable("WishList");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__WishList__Produc__5EBF139D");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__WishList__UsersI__5FB337D6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
