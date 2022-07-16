﻿// <auto-generated />
using BurgerApp.DataAccess_Refactored;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BurgerApp.DataAccess_Refactored.Migrations
{
    [DbContext(typeof(BurgerAppDbContext))]
    partial class BurgerAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BurgerApp.Domain_Refactored.Models.Burger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("HasFries")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("TypeOfBurger")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Burgers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HasFries = true,
                            Name = "Veggie",
                            Price = 450.0,
                            TypeOfBurger = 3
                        },
                        new
                        {
                            Id = 2,
                            HasFries = true,
                            Name = "Black Angus",
                            Price = 500.0,
                            TypeOfBurger = 1
                        },
                        new
                        {
                            Id = 3,
                            HasFries = false,
                            Name = "The beyond Burger",
                            Price = 450.0,
                            TypeOfBurger = 2
                        });
                });

            modelBuilder.Entity("BurgerApp.Domain_Refactored.Models.BurgerBasket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BurgerId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfBurgers")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BurgerId");

                    b.HasIndex("OrderId");

                    b.ToTable("BurgerBasket");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BurgerId = 2,
                            NumberOfBurgers = 2,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 2,
                            BurgerId = 1,
                            NumberOfBurgers = 1,
                            OrderId = 2
                        },
                        new
                        {
                            Id = 3,
                            BurgerId = 3,
                            NumberOfBurgers = 3,
                            OrderId = 3
                        });
                });

            modelBuilder.Entity("BurgerApp.Domain_Refactored.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BurgerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("StoreAddress")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BurgerId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BurgerId = 1,
                            IsDelivered = true,
                            PaymentMethod = 1,
                            StoreAddress = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BurgerId = 3,
                            IsDelivered = false,
                            PaymentMethod = 2,
                            StoreAddress = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            BurgerId = 2,
                            IsDelivered = false,
                            PaymentMethod = 2,
                            StoreAddress = 3,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("BurgerApp.Domain_Refactored.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "09692, Canicosa De La Sierra",
                            FirstName = "Ricky",
                            LastName = "Rubio"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Long Branch, Cedar Avenue 331, New Jersey",
                            FirstName = "John",
                            LastName = "Krasinski"
                        },
                        new
                        {
                            Id = 3,
                            Address = "47 W 13th St, New York, NY 10011",
                            FirstName = "Paul",
                            LastName = "Ekman"
                        });
                });

            modelBuilder.Entity("BurgerApp.Domain_Refactored.Models.BurgerBasket", b =>
                {
                    b.HasOne("BurgerApp.Domain_Refactored.Models.Burger", "Burger")
                        .WithMany("FoodPornBasket")
                        .HasForeignKey("BurgerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurgerApp.Domain_Refactored.Models.Order", "Order")
                        .WithMany("FoodPornBasket")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burger");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BurgerApp.Domain_Refactored.Models.Order", b =>
                {
                    b.HasOne("BurgerApp.Domain_Refactored.Models.Burger", "Burger")
                        .WithMany()
                        .HasForeignKey("BurgerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurgerApp.Domain_Refactored.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burger");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BurgerApp.Domain_Refactored.Models.Burger", b =>
                {
                    b.Navigation("FoodPornBasket");
                });

            modelBuilder.Entity("BurgerApp.Domain_Refactored.Models.Order", b =>
                {
                    b.Navigation("FoodPornBasket");
                });

            modelBuilder.Entity("BurgerApp.Domain_Refactored.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
