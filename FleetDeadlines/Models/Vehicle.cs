using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FleetDeadlines.Models
{
    public class Vehicle : DbContext
    {
        [Key]
        [JsonProperty("registrationNumber")]
        public required string RegistrationNumber { get; set; }

        [JsonProperty("artEndDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ArtEndDate { get; set; }

        [JsonProperty("co2Emissions", NullValueHandling = NullValueHandling.Ignore)]
        public long? Co2Emissions { get; set; }

        [JsonProperty("engineCapacity", NullValueHandling = NullValueHandling.Ignore)]
        public long? EngineCapacity { get; set; }

        [JsonProperty("euroStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string? EuroStatus { get; set; }

        [JsonProperty("markedForExport", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MarkedForExport { get; set; }

        [JsonProperty("fuelType", NullValueHandling = NullValueHandling.Ignore)]
        public string? FuelType { get; set; }

        [JsonProperty("motStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string? MotStatus { get; set; }

        [JsonProperty("revenueWeight", NullValueHandling = NullValueHandling.Ignore)]
        public long? RevenueWeight { get; set; }

        [JsonProperty("colour", NullValueHandling = NullValueHandling.Ignore)]
        public string? Colour { get; set; }

        [JsonProperty("make", NullValueHandling = NullValueHandling.Ignore)]
        public string? Make { get; set; }

        [JsonProperty("typeApproval", NullValueHandling = NullValueHandling.Ignore)]
        public string? TypeApproval { get; set; }

        [JsonProperty("yearOfManufacture", NullValueHandling = NullValueHandling.Ignore)]
        public long YearOfManufacture { get; set; }

        [JsonProperty("taxDueDate", NullValueHandling = NullValueHandling.Ignore)]
        public string? TaxDueDate { get; set; }

        [JsonProperty("taxStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string? TaxStatus { get; set; }

        [JsonProperty("dateOfLastV5CIssued", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset DateOfLastV5CIssued { get; set; }

        [JsonProperty("wheelplan", NullValueHandling = NullValueHandling.Ignore)]
        public string? Wheelplan { get; set; }

        [JsonProperty("monthOfFirstDvlaRegistration", NullValueHandling = NullValueHandling.Ignore)]
        public string? MonthOfFirstDvlaRegistration { get; set; }

        [JsonProperty("monthOfFirstRegistration", NullValueHandling = NullValueHandling.Ignore)]
        public string? MonthOfFirstRegistration { get; set; }

        [JsonProperty("realDrivingEmissions", NullValueHandling = NullValueHandling.Ignore)]
        public long? RealDrivingEmissions { get; set; }

        [JsonProperty("motExpiryDate", NullValueHandling = NullValueHandling.Ignore)]
        public string? MotExpiryDate { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Vehicle>().HasKey(x => x.RegistrationNumber);
        //}
    }
}
