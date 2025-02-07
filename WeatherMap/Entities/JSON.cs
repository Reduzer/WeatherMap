using System.Text.Json.Serialization;

namespace WeatherMap.Entities;

public class JSONObjectFromString
{
    [JsonPropertyName("name")] public string sName { get; set; }
    [JsonPropertyName("country")] public string sCountry { get; set; }
    [JsonPropertyName("lat")] public double Latitude { get; set; }
    [JsonPropertyName("lon")] public double Longitude { get; set; }
    [JsonPropertyName("temp_c")] public double dTemperature { get; set; }
    [JsonPropertyName("wind_kph")] public double dWindSpeed { get; set; }
    [JsonPropertyName("humidity")] public double dHumidity { get; set; }
}