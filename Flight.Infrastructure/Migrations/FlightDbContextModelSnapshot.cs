﻿// <auto-generated />
using System;
using Flight.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Flight.Infrastructure.Migrations
{
    [DbContext(typeof(FlightDbContext))]
    partial class FlightDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Flight.Domain.Entities.Flights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Airline_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Arival_Time")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Departure_Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Flight.Domain.Entities.Routes", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Departure_City_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Departure_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Origin_City_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Departure_City_Id", "Origin_City_Id", "Departure_Date")
                        .IsUnique();

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Flight.Domain.Entities.Subscriptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Agency_Id")
                        .HasColumnType("int");

                    b.Property<int>("Departure_City_Id")
                        .HasColumnType("int");

                    b.Property<int>("Origin_City_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Flight.Domain.Entities.Flights", b =>
                {
                    b.HasOne("Flight.Domain.Entities.Routes", "Route")
                        .WithMany("Flights")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Flight.Domain.Entities.Routes", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
