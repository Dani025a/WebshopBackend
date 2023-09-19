using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebshopBackend.Models;

namespace WebshopBackend.Data;

public partial class WebshopContext : DbContext
{
    public WebshopContext(DbContextOptions<WebshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderLineItem> OrderLineItems { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserInformationView> UserInformationViews { get; set; }

    public virtual DbSet<VGetProductAndInventory> VGetProductAndInventories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PRIMARY");

            entity.ToTable("address");

            entity.HasIndex(e => e.FkUserId, "fk_user_id");

            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.City).HasMaxLength(40);
            entity.Property(e => e.FkUserId).HasColumnName("fk_user_id");
            entity.Property(e => e.StreetName)
                .HasMaxLength(40)
                .HasColumnName("Street name");
            entity.Property(e => e.StreetNumber).HasColumnName("Street number");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(40)
                .HasColumnName("ZIP Code");

            entity.HasOne(d => d.FkUser).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.FkUserId)
                .HasConstraintName("address_ibfk_1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PRIMARY");

            entity.ToTable("inventory");

            entity.HasIndex(e => e.FkProductId, "fk_inventory_prodcut");

            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");
            entity.Property(e => e.FkProductId).HasColumnName("fk_product_id");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.FkProduct).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.FkProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inventory_prodcut");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.FkOrderStatus, "fk_order_status");

            entity.HasIndex(e => e.FkPaymentId, "fk_payment_id");

            entity.HasIndex(e => e.FkUserId, "fk_user_id");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.FkOrderStatus).HasColumnName("fk_order_status");
            entity.Property(e => e.FkPaymentId).HasColumnName("fk_payment_id");
            entity.Property(e => e.FkUserId).HasColumnName("fk_user_id");

            entity.HasOne(d => d.FkOrderStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FkOrderStatus)
                .HasConstraintName("orders_ibfk_3");

            entity.HasOne(d => d.FkPayment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FkPaymentId)
                .HasConstraintName("orders_ibfk_2");

            entity.HasOne(d => d.FkUser).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FkUserId)
                .HasConstraintName("orders_ibfk_1");
        });

        modelBuilder.Entity<OrderLineItem>(entity =>
        {
            entity.HasKey(e => e.MyRowId).HasName("PRIMARY");

            entity.ToTable("order_line_items");

            entity.HasIndex(e => e.FkOrderId, "fk_order_id");

            entity.HasIndex(e => e.FkProductId, "fk_product_id");

            entity.Property(e => e.MyRowId).HasColumnName("my_row_id");
            entity.Property(e => e.FkOrderId).HasColumnName("fk_order_id");
            entity.Property(e => e.FkProductId).HasColumnName("fk_product_id");

            entity.HasOne(d => d.FkOrder).WithMany(p => p.OrderLineItems)
                .HasForeignKey(d => d.FkOrderId)
                .HasConstraintName("order_line_items_ibfk_1");

            entity.HasOne(d => d.FkProduct).WithMany(p => p.OrderLineItems)
                .HasForeignKey(d => d.FkProductId)
                .HasConstraintName("order_line_items_ibfk_2");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("PRIMARY");

            entity.ToTable("order_status");

            entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");
            entity.Property(e => e.Name)
                .HasColumnType("enum('Order received','In Progress','Order delivered')")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PRIMARY");

            entity.ToTable("payments");

            entity.HasIndex(e => e.FkUserId, "fk_user_id");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.FkUserId).HasColumnName("fk_user_id");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(10)
                .HasColumnName("total_price");

            entity.HasOne(d => d.FkUser).WithMany(p => p.Payments)
                .HasForeignKey(d => d.FkUserId)
                .HasConstraintName("payments_ibfk_1");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.PaymentDetailId).HasName("PRIMARY");

            entity.ToTable("payment_details");

            entity.HasIndex(e => e.FkPaymentId, "fk_payment_id");

            entity.Property(e => e.PaymentDetailId).HasColumnName("payment_detail_id");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(150)
                .HasColumnName("card_number");
            entity.Property(e => e.FkPaymentId).HasColumnName("fk_payment_id");
            entity.Property(e => e.TransactionNumber).HasColumnName("transaction_number");

            entity.HasOne(d => d.FkPayment).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.FkPaymentId)
                .HasConstraintName("payment_details_ibfk_1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.FkCategoryId, "fk_category_id");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.FkCategoryId).HasColumnName("fk_category_id");
            entity.Property(e => e.Imageurl)
                .HasMaxLength(255)
                .HasColumnName("imageurl");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");

            entity.HasOne(d => d.FkCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.FkCategoryId)
                .HasConstraintName("products_ibfk_2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(40)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(40)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<UserInformationView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("user_information_view");

            entity.Property(e => e.City).HasMaxLength(40);
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(81)
                .HasColumnName("fullName");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .HasColumnName("phone_number");
            entity.Property(e => e.StreetName)
                .HasMaxLength(40)
                .HasColumnName("street_name");
            entity.Property(e => e.StreetNumber).HasColumnName("street_number");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(40)
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<VGetProductAndInventory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_get_product_and_inventory");

            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
