﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SawyerAir.Models;

namespace SawyerAir.Migrations
{
    [DbContext(typeof(FlightsContext))]
    partial class FlightsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SawyerAir.Models.Booking", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FlightClass")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RouteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookingId");

                    b.HasIndex("ClientId");

                    b.HasIndex("RouteId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("SawyerAir.Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CVC")
                        .HasColumnType("int");

                    b.Property<Guid>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("SawyerAir.Models.Class_Info", b =>
                {
                    b.Property<Guid>("Class_InfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NrSeats")
                        .HasColumnType("int");

                    b.Property<Guid>("PlaneClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<Guid>("RouteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Class_InfoId");

                    b.HasIndex("PlaneClassId");

                    b.HasIndex("RouteId");

                    b.ToTable("Class_Infos");
                });

            modelBuilder.Entity("SawyerAir.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("SawyerAir.Models.Flight", b =>
                {
                    b.Property<Guid>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("DepartureHour")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("DestinationHour")
                        .HasColumnType("time");

                    b.Property<Guid>("PlaneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RouteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FlightId");

                    b.HasIndex("PlaneId");

                    b.HasIndex("RouteId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("SawyerAir.Models.Line", b =>
                {
                    b.Property<Guid>("LineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LineId");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("SawyerAir.Models.Plane", b =>
                {
                    b.Property<Guid>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlaneId");

                    b.HasIndex("LineId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("SawyerAir.Models.PlaneClass", b =>
                {
                    b.Property<Guid>("PlaneClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlaneClassId");

                    b.ToTable("PlaneClasses");
                });

            modelBuilder.Entity("SawyerAir.Models.Route", b =>
                {
                    b.Property<Guid>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DepartureLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RouteId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("SawyerAir.Models.Route_Stop", b =>
                {
                    b.Property<Guid>("Route_StopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RouteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("StopTime")
                        .HasColumnType("real");

                    b.HasKey("Route_StopId");

                    b.HasIndex("RouteId");

                    b.HasIndex("StopId");

                    b.ToTable("Route_Stops");
                });

            modelBuilder.Entity("SawyerAir.Models.Stop", b =>
                {
                    b.Property<Guid>("StopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StopLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StopId");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("SawyerAir.Models.Booking", b =>
                {
                    b.HasOne("SawyerAir.Models.Client", "Client")
                        .WithMany("Bookings")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SawyerAir.Models.Route", "Route")
                        .WithMany("Bookings")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SawyerAir.Models.Card", b =>
                {
                    b.HasOne("SawyerAir.Models.Client", "Client")
                        .WithMany("Cards")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SawyerAir.Models.Class_Info", b =>
                {
                    b.HasOne("SawyerAir.Models.PlaneClass", "PlaneClass")
                        .WithMany("Class_Infos")
                        .HasForeignKey("PlaneClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SawyerAir.Models.Route", "Route")
                        .WithMany("Class_Infos")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SawyerAir.Models.Flight", b =>
                {
                    b.HasOne("SawyerAir.Models.Plane", "Plane")
                        .WithMany("Flight")
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SawyerAir.Models.Route", "Route")
                        .WithMany("Flights")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SawyerAir.Models.Plane", b =>
                {
                    b.HasOne("SawyerAir.Models.Line", "Line")
                        .WithMany("Planes")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SawyerAir.Models.Route_Stop", b =>
                {
                    b.HasOne("SawyerAir.Models.Route", "Route")
                        .WithMany("Route_Stops")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SawyerAir.Models.Stop", "Stop")
                        .WithMany("Route_Stops")
                        .HasForeignKey("StopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
