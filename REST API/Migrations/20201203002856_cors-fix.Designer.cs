﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REST_API.Data;

namespace REST_API.Migrations
{
    [DbContext(typeof(REST_APIContext))]
    [Migration("20201203002856_cors-fix")]
    partial class corsfix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("REST_API.Models.BagLetters", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BagNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("LetterCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ShipmentBagsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("Id");

                    b.HasIndex("ShipmentBagsId");

                    b.ToTable("BagLetters");
                });

            modelBuilder.Entity("REST_API.Models.BagParcels", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BagNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("ShipmentBagsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ShipmentBagsId");

                    b.ToTable("BagParcels");
                });

            modelBuilder.Entity("REST_API.Models.Parcel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BagParcelsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DestinationCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParcelNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RecipientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("Id");

                    b.HasIndex("BagParcelsId");

                    b.ToTable("Parcel");
                });

            modelBuilder.Entity("REST_API.Models.Shipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Airport")
                        .HasColumnType("int");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("ShipmentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("REST_API.Models.ShipmentBags", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ShipmentId");

                    b.ToTable("ShipmentBags");
                });

            modelBuilder.Entity("REST_API.Models.BagLetters", b =>
                {
                    b.HasOne("REST_API.Models.ShipmentBags", "ShipmentBags")
                        .WithMany("ListBagLet")
                        .HasForeignKey("ShipmentBagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShipmentBags");
                });

            modelBuilder.Entity("REST_API.Models.BagParcels", b =>
                {
                    b.HasOne("REST_API.Models.ShipmentBags", "ShipmentBags")
                        .WithMany("ListBagPar")
                        .HasForeignKey("ShipmentBagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShipmentBags");
                });

            modelBuilder.Entity("REST_API.Models.Parcel", b =>
                {
                    b.HasOne("REST_API.Models.BagParcels", "BagParcels")
                        .WithMany("ListParcels")
                        .HasForeignKey("BagParcelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BagParcels");
                });

            modelBuilder.Entity("REST_API.Models.ShipmentBags", b =>
                {
                    b.HasOne("REST_API.Models.Shipment", "Shipment")
                        .WithMany("ListBags")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("REST_API.Models.BagParcels", b =>
                {
                    b.Navigation("ListParcels");
                });

            modelBuilder.Entity("REST_API.Models.Shipment", b =>
                {
                    b.Navigation("ListBags");
                });

            modelBuilder.Entity("REST_API.Models.ShipmentBags", b =>
                {
                    b.Navigation("ListBagLet");

                    b.Navigation("ListBagPar");
                });
#pragma warning restore 612, 618
        }
    }
}
