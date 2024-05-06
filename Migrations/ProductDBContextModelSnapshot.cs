﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product_API_TakeTwo.Data;

#nullable disable

namespace Product_API_TakeTwo.Migrations
{
    [DbContext(typeof(ProductDBContext))]
    partial class ProductDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Product_API_TakeTwo.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("AmountInStock")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            AmountInStock = 10,
                            Category = 0,
                            Price = 15000.00m,
                            ProductDescription = "Decent PC",
                            ProductName = "Gaming PC v1"
                        },
                        new
                        {
                            ProductID = 2,
                            AmountInStock = 12,
                            Category = 0,
                            Price = 20000.00m,
                            ProductDescription = "Average PC",
                            ProductName = "Gaming PC v2"
                        },
                        new
                        {
                            ProductID = 3,
                            AmountInStock = 8,
                            Category = 0,
                            Price = 25000.00m,
                            ProductDescription = "Good PC",
                            ProductName = "Gaming PC v3"
                        },
                        new
                        {
                            ProductID = 4,
                            AmountInStock = 5,
                            Category = 0,
                            Price = 30000.00m,
                            ProductDescription = "Very good PC",
                            ProductName = "Gaming PC v4"
                        },
                        new
                        {
                            ProductID = 5,
                            AmountInStock = 20,
                            Category = 2,
                            Price = 300.00m,
                            ProductDescription = "Black color",
                            ProductName = "T-Shirt"
                        },
                        new
                        {
                            ProductID = 6,
                            AmountInStock = 15,
                            Category = 2,
                            Price = 600.00m,
                            ProductDescription = "Light blue color",
                            ProductName = "Jeans"
                        },
                        new
                        {
                            ProductID = 7,
                            AmountInStock = 10,
                            Category = 2,
                            Price = 700.00m,
                            ProductDescription = "White color",
                            ProductName = "Shirt"
                        });
                });

            modelBuilder.Entity("Product_API_TakeTwo.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("ProductID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Product_API_TakeTwo.Models.Review", b =>
                {
                    b.HasOne("Product_API_TakeTwo.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
