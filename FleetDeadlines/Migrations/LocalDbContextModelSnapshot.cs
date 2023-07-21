﻿// <auto-generated />
using System;
using FleetDeadlines.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FleetDeadlines.Migrations
{
    [DbContext(typeof(LocalDbContext))]
    partial class LocalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("FleetDeadlines.Models.Vehicle", b =>
                {
                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("ArtEndDate")
                        .HasColumnType("TEXT");

                    b.Property<long?>("Co2Emissions")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Colour")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("DateOfLastV5CIssued")
                        .HasColumnType("TEXT");

                    b.Property<long?>("EngineCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EuroStatus")
                        .HasColumnType("TEXT");

                    b.Property<string>("FuelType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Make")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("MarkedForExport")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MonthOfFirstDvlaRegistration")
                        .HasColumnType("TEXT");

                    b.Property<string>("MonthOfFirstRegistration")
                        .HasColumnType("TEXT");

                    b.Property<string>("MotExpiryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MotStatus")
                        .HasColumnType("TEXT");

                    b.Property<long?>("RealDrivingEmissions")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("RevenueWeight")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TaxDueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaxStatus")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeApproval")
                        .HasColumnType("TEXT");

                    b.Property<string>("Wheelplan")
                        .HasColumnType("TEXT");

                    b.Property<long>("YearOfManufacture")
                        .HasColumnType("INTEGER");

                    b.HasKey("RegistrationNumber");

                    b.ToTable("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
