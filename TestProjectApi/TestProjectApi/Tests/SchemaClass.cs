using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestProjectApi.Tests
{

    public partial class SchemaClass
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("coatOfArms")]
        public string CoatOfArms { get; set; }

        [JsonProperty("words")]
        public string Words { get; set; }

        [JsonProperty("titles")]
        public string[] Titles { get; set; }

        [JsonProperty("seats")]
        public string[] Seats { get; set; }

        [JsonProperty("currentLord")]
        public Uri CurrentLord { get; set; }

        [JsonProperty("heir")]
        public string Heir { get; set; }

        [JsonProperty("overlord")]
        public Uri Overlord { get; set; }

        [JsonProperty("founded")]
        public string Founded { get; set; }

        [JsonProperty("founder")]
        public string Founder { get; set; }

        [JsonProperty("diedOut")]
        public string DiedOut { get; set; }

        [JsonProperty("ancestralWeapons")]
        public string[] AncestralWeapons { get; set; }

        [JsonProperty("cadetBranches")]
        public object[] CadetBranches { get; set; }

        [JsonProperty("swornMembers")]
        public Uri[] SwornMembers { get; set; }
    }

    public partial class SchemaClass
    {
        public static SchemaClass[] FromJson(string json) => JsonConvert.DeserializeObject<SchemaClass[]>(json, TestProjectApi.Tests.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SchemaClass[] self) => JsonConvert.SerializeObject(self, TestProjectApi.Tests.Converter.Settings);
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
}

