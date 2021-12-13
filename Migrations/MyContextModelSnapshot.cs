﻿// <auto-generated />
using System;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChefsNDishes.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ChefsNDishes.Models.Chef", b =>
                {
                    b.Property<int>("chefId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("firstname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("lastname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("chefId");

                    b.ToTable("Chefs");
                });

            modelBuilder.Entity("ChefsNDishes.Models.Dish", b =>
                {
                    b.Property<int>("dishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("calories")
                        .HasColumnType("int");

                    b.Property<int>("chefId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("tastiness")
                        .HasColumnType("int");

                    b.HasKey("dishId");

                    b.HasIndex("chefId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("ChefsNDishes.Models.Dish", b =>
                {
                    b.HasOne("ChefsNDishes.Models.Chef", "chef")
                        .WithMany("dishes")
                        .HasForeignKey("chefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
