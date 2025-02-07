using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using WeatherMap.Entities;

namespace WeatherMap.APIRequests;

public class WeatherAPI
{
    private HttpClient m_oClient;
    private const string m_sBaseURL = "https://api.weatherapi.com/v1/current.json?key=";
    private string m_sAPIKey;

    public WeatherAPI()
    {
        m_sAPIKey = FileReader.FileReader.Instance.ReadFile();
    }

    public async Task<JSONObjectFromString?> GetDataForCity(string sName)
    {
        try
        {
            JSONObjectFromString? data = null;
            JSONObjectFromString temp = null;

            using (m_oClient = new HttpClient())
            {
                Uri uri = new Uri(m_sBaseURL + m_sAPIKey + "&q=" + sName);
                
                using (HttpResponseMessage response = m_oClient.GetAsync(uri).Result)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = response.Content.ReadAsStream())
                        {
                            using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
                            {
                                string sResponse = streamReader.ReadToEnd();

                                JsonNode? jobject = JsonObject.Parse(sResponse);

                                temp = JsonSerializer.Deserialize<JSONObjectFromString>(jobject["current"].ToString(), new JsonSerializerOptions { WriteIndented = true });
                                data = JsonSerializer.Deserialize<JSONObjectFromString>(jobject["location"].ToString(), new JsonSerializerOptions { WriteIndented = true });
                            }
                        }
                    }
                }
            }
            data.dTemperature = temp.dTemperature;
            data.dHumidity = temp.dHumidity;
            data.dWindSpeed = temp.dWindSpeed;
            
            return data;
        }
        catch (HttpRequestException e)
        {
            Debug.WriteLine("Exception catched! \n Message: {0}", e.Message);
            return null;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception catched! \n Message: {0}", e.Message);
            return null;
        }
    }
}