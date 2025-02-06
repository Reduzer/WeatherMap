using System.Text.Json.Serialization;

namespace WeatherMap.Entities;

public class JSON
{
    [JsonPropertyName("sName")] public string sName { get; set; }
    [JsonPropertyName("sCounty")] public string sCounty { get; set; }
    [JsonPropertyName("dLatitude")] public double Latitude { get; set; }
    [JsonPropertyName("dLongitude")] public double Longitude { get; set; }
    [JsonPropertyName("dTemperature")] public double dTemperature { get; set; }
    [JsonPropertyName("dWindSpeed")] public double dWindSpeed { get; set; }
    [JsonPropertyName("dHumidity")] public double dHumidity { get; set; }
}