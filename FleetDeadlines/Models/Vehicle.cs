using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace FleetDeadlines.Models
{
    public partial class Vehicle : DbContext
    {
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
        [JsonConverter(typeof(ParseStringConverter))]
        public long? RealDrivingEmissions { get; set; }

        [JsonProperty("motExpiryDate", NullValueHandling = NullValueHandling.Ignore)]
        public string? MotExpiryDate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasKey(x => x.RegistrationNumber);
        }
    }

    public partial class Vehicle
    {
        public static Vehicle[] FromJson(string json) => JsonConvert.DeserializeObject<Vehicle[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Vehicle[] self) => JsonConvert.SerializeObject(self, FleetDeadlines.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object? ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
