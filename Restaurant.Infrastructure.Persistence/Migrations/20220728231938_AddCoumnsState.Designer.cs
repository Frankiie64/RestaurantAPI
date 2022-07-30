﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.Infrastructure.Persistence.Context;

namespace Restaurant.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220728231938_AddCoumnsState")]
    partial class AddCoumnsState
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Restaurant.Core.Domain.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DishCategory")
                        .HasColumnType("int");

                    b.Property<int>("DishFor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Dish");
                });

            modelBuilder.Entity("Restaurant.Core.Domain.Entities.InfoDish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDish")
                        .HasColumnType("int");

                    b.Property<int>("IdIngredient")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDish");

                    b.HasIndex("IdIngredient");

                    b.ToTable("InfoDish");
                });

            modelBuilder.Entity("Restaurant.Core.Domain.Entities.Ingredients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Restaurant.Core.Domain.Entities.OrderWithDish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDish")
                        .HasColumnType("int");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdOrder");

                    b.ToTable("OrderWithDish");
                });

            modelBuilder.Entity("Restaurant.Core.Domain.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTable")
                        .HasColumnType("int");

                    b.Property<double>("Subtotal")
                        .HasColumnType("float");

                    b.Property<int>("stauts")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTable");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("Restaurant.Core.Domain.Entities.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stauts")
                        .HasColumnType("int");

                    b.Property<int>("TableOf")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("Restaurant.Core.Domain.Entities.InfoDish", b =>
                {
                    b.HasOne("Restaurant.Core.Domain.Entities.Dish", "Dish")
                        .WithMany("Ingredients")
                        .HasForeignKey("IdDish")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Core.Domain.Entities.Ingredients", "Ingredients")
                        .WithMany("Dishes")
                        .HasForeignKey("IdIngredient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("Restaurant.Core.Domain.Entities.OrderWithDish", b =>
                {
                    b.HasOne("Restaurant.Core.Domain.Entities.Request", "Order")
                        .WithMany("Dishes")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Restaurant.Core.Domain.Entities.Request", b =>
                {
                    b.HasOne("Restaurant.Core.Domain.Entities.Table", "Table")
                        .WithMany("Orders")
                        .HasForeignKey("IdTable")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Restaurant.Core.Domain.Entities.Dish", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("Restaurant.Core.Domain.Entities.Ingredients", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("Restaurant.Core.Domain.Entities.Request", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("Restaurant.Core.Domain.Entities.Table", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
