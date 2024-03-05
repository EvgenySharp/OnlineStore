﻿// <auto-generated />
using System;
using Catalog.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catalog.Persistence.Migrations
{
    [DbContext(typeof(СatalogDbContext))]
    [Migration("20240222150917_updatedatabase")]
    partial class updatedatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Catalog.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Catalog.Domain.Entities.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("Catalog.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddingDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDiscount")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ManufacturerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ManufacturerId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("ManufacturerId1");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Catalog.Domain.Entities.Product", b =>
                {
                    b.HasOne("Catalog.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Catalog.Domain.Entities.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("Catalog.Domain.Entities.Manufacturer", null)
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId1");

                    b.Navigation("Category");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Catalog.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Catalog.Domain.Entities.Manufacturer", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
