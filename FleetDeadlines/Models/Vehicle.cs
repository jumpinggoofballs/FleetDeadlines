using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FleetDeadlines.Models
{
    public class Vehicle
    {
        // RegistrationNumber *
        // ArtEndDate
        // Co2Emissions
        // EngineCapacity
        // EuroStatus
        // MarkedForExport
        // FuelType
        // MotStatus
        // RevenueWeight
        // Colour
        // Make
        // TypeApproval
        // YearOfManufacture
        // TaxDueDate
        // TaxStatus
        // DateOfLastV5CIssued
        // Wheelplan
        // MonthOfFirstDvlaRegistration
        // MonthOfFirstRegistration
        // RealDrivingEmissions
        // MotExpiryDate

        [Key]
        [JsonProperty("registrationNumber")]
        [Display(Name = "Registration Number")]
        public required string RegistrationNumber { get; set; }

        [JsonProperty("artEndDate", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "ART End Date")]
        public DateTimeOffset? ArtEndDate { get; set; }

        [JsonProperty("co2Emissions", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "CO2 Emissions")]
        public long? Co2Emissions { get; set; }

        [JsonProperty("engineCapacity", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Engine Capacity")]
        public long? EngineCapacity { get; set; }

        [JsonProperty("euroStatus", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Euro Status")]
        public string? EuroStatus { get; set; }

        [JsonProperty("markedForExport", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Marked For Export")]
        public bool? MarkedForExport { get; set; }

        [JsonProperty("fuelType", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Fuel Type")]
        public string? FuelType { get; set; }

        [JsonProperty("motStatus", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "MOT Status")]
        public string? MotStatus { get; set; }

        [JsonProperty("revenueWeight", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Revenue Weight")]
        public long? RevenueWeight { get; set; }

        [JsonProperty("colour", NullValueHandling = NullValueHandling.Ignore)]
        public string? Colour { get; set; }

        [JsonProperty("make", NullValueHandling = NullValueHandling.Ignore)]
        public string? Make { get; set; }

        [JsonProperty("typeApproval", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Type of Approval")]
        public string? TypeApproval { get; set; }

        [JsonProperty("yearOfManufacture", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Year Of Manufacture")]
        public long YearOfManufacture { get; set; }

        [JsonProperty("taxDueDate", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Tax Due Date")]
        public string? TaxDueDate { get; set; }

        [JsonProperty("taxStatus", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Tax Status")]
        public string? TaxStatus { get; set; }

        [JsonProperty("dateOfLastV5CIssued", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Date Of Last V5C Issued")]
        public DateTimeOffset DateOfLastV5CIssued { get; set; }

        [JsonProperty("wheelplan", NullValueHandling = NullValueHandling.Ignore)]
        public string? Wheelplan { get; set; }

        [JsonProperty("monthOfFirstDvlaRegistration", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Month Of First Dvla Registration")]
        public string? MonthOfFirstDvlaRegistration { get; set; }

        [JsonProperty("monthOfFirstRegistration", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Month Of First Registration")]
        public string? MonthOfFirstRegistration { get; set; }

        [JsonProperty("realDrivingEmissions", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Real Driving Emissions")]
        public long? RealDrivingEmissions { get; set; }

        [JsonProperty("motExpiryDate", NullValueHandling = NullValueHandling.Ignore)]
        [Display(Name = "Mot Expiry Date")]
        public string? MotExpiryDate { get; set; }
    }
}
