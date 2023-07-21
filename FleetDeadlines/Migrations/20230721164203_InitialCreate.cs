using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetDeadlines.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    RegistrationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ArtEndDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    Co2Emissions = table.Column<long>(type: "INTEGER", nullable: true),
                    EngineCapacity = table.Column<long>(type: "INTEGER", nullable: true),
                    EuroStatus = table.Column<string>(type: "TEXT", nullable: true),
                    MarkedForExport = table.Column<bool>(type: "INTEGER", nullable: true),
                    FuelType = table.Column<string>(type: "TEXT", nullable: true),
                    MotStatus = table.Column<string>(type: "TEXT", nullable: true),
                    RevenueWeight = table.Column<long>(type: "INTEGER", nullable: true),
                    Colour = table.Column<string>(type: "TEXT", nullable: true),
                    Make = table.Column<string>(type: "TEXT", nullable: true),
                    TypeApproval = table.Column<string>(type: "TEXT", nullable: true),
                    YearOfManufacture = table.Column<long>(type: "INTEGER", nullable: false),
                    TaxDueDate = table.Column<string>(type: "TEXT", nullable: true),
                    TaxStatus = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfLastV5CIssued = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Wheelplan = table.Column<string>(type: "TEXT", nullable: true),
                    MonthOfFirstDvlaRegistration = table.Column<string>(type: "TEXT", nullable: true),
                    MonthOfFirstRegistration = table.Column<string>(type: "TEXT", nullable: true),
                    RealDrivingEmissions = table.Column<long>(type: "INTEGER", nullable: true),
                    MotExpiryDate = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.RegistrationNumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
