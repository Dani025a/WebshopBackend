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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");
        
        modelBuilder.Entity<Address>(entity =>
        {

            entity.HasOne(d => d.FkUser).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.FkUserId)
                .HasConstraintName("address_ibfk_1");
        });



        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasOne(d => d.FkProduct).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.FkProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inventory_prodcut");
        });

        modelBuilder.Entity<Order>(entity =>
        {

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

            entity.HasOne(d => d.FkOrder).WithMany(p => p.OrderLineItems)
                .HasForeignKey(d => d.FkOrderId)
                .HasConstraintName("order_line_items_ibfk_1");

            entity.HasOne(d => d.FkProduct).WithMany(p => p.OrderLineItems)
                .HasForeignKey(d => d.FkProductId)
                .HasConstraintName("order_line_items_ibfk_2");
        });


        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasOne(d => d.FkUser)
                .WithMany(p => p.Payments)
                .HasForeignKey(d => d.FkUserId)
                .HasConstraintName("payments_ibfk_1");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasOne(d => d.FkPayment)
                .WithOne()
                .HasForeignKey<PaymentDetail>(d => d.FkPaymentId)
                .HasConstraintName("payment_details_ibfk_1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasOne(d => d.FkCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.FkCategoryId)
                .HasConstraintName("products_ibfk_2");
        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
