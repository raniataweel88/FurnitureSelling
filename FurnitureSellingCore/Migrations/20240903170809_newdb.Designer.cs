﻿// <auto-generated />
using System;
using FurnitureSellingCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FurnitureSellingCore.Migrations
{
    [DbContext(typeof(FurnitureSellingDbContext))]
    [Migration("20240903170809_newdb")]
    partial class newdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FurnitureSellingCore.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsActiveId")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("Paymentmetod")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("longtext");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemRequestId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("longtext");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("ItemId");

                    b.HasIndex("ItemRequestId");

                    b.ToTable("CartItem", (string)null);
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Colors")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DateAdd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<float?>("DisacountAmount")
                        .HasColumnType("float");

                    b.Property<int?>("DiscountType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<float?>("PriceAfterDiscount")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int?>("RestQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Sizes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("isHaveDiscount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.ItemRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("NoteAdmain")
                        .HasColumnType("longtext");

                    b.Property<float?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ItemRequest", (string)null);
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.Logins", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsLoggedIn")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastLoginTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("LoginId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Login", (string)null);
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerNote")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2024, 9, 3, 20, 8, 8, 869, DateTimeKind.Local).AddTicks(1859));

                    b.Property<string>("DeliveryNote")
                        .HasColumnType("longtext");

                    b.Property<float?>("Fee")
                        .HasColumnType("float");

                    b.Property<int?>("Paymentmethod")
                        .HasColumnType("int");

                    b.Property<bool?>("Preparingrequest")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("RecivingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("StatusDelivery")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<float?>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("OrderId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float?>("Blane")
                        .HasColumnType("float");

                    b.Property<string>("CardHolder")
                        .HasColumnType("longtext");

                    b.Property<string>("CardNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.ProductWarranty", b =>
                {
                    b.Property<int>("ProductWarrantyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("WarrantyCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("WarrantyEndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("WarrantyStartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ProductWarrantyId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("ProductWarrantys");
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.Raview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RatingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RatingNumber")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Raviews");
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("IV")
                        .HasColumnType("longtext");

                    b.Property<string>("Key")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("PlateNumber")
                        .HasColumnType("longtext");

                    b.Property<float?>("Salary")
                        .HasColumnType("float");

                    b.Property<int?>("UserType")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.WishList", b =>
                {
                    b.Property<int>("WishListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WishListId");

                    b.HasIndex("ItemId");

                    b.ToTable("WishList", (string)null);
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.Cart", b =>
                {
                    b.HasOne("FurnitureSellingCore.Models.Order", null)
                        .WithOne()
                        .HasForeignKey("FurnitureSellingCore.Models.Cart", "OrderId");

                    b.HasOne("FurnitureSellingCore.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.CartItem", b =>
                {
                    b.HasOne("FurnitureSellingCore.Models.Cart", null)
                        .WithMany()
                        .HasForeignKey("CartId");

                    b.HasOne("FurnitureSellingCore.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("FurnitureSellingCore.Models.ItemRequest", null)
                        .WithMany()
                        .HasForeignKey("ItemRequestId")
                        .HasConstraintName("FK_CustomName");
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.Item", b =>
                {
                    b.HasOne("FurnitureSellingCore.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.ItemRequest", b =>
                {
                    b.HasOne("FurnitureSellingCore.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.Logins", b =>
                {
                    b.HasOne("FurnitureSellingCore.Models.User", null)
                        .WithOne()
                        .HasForeignKey("FurnitureSellingCore.Models.Logins", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.ProductWarranty", b =>
                {
                    b.HasOne("FurnitureSellingCore.Models.Item", null)
                        .WithOne()
                        .HasForeignKey("FurnitureSellingCore.Models.ProductWarranty", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FurnitureSellingCore.Models.WishList", b =>
                {
                    b.HasOne("FurnitureSellingCore.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemId");
                });
#pragma warning restore 612, 618
        }
    }
}
