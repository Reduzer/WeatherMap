using System.Net.Http;
using WeatherMap.Entities;

namespace WeatherMap.APIRequests;

public class WeatherAPI
{
    private HttpClient m_oClient;
    private const string m_sBaseURL = "https://api.openweathermap.org/data/2.5/";
    
    private string m_sAPIKey;

    public WeatherAPI()
    {
        m_sAPIKey = FileReader.FileReader.Instance.ReadFile();   
    }

    public Weather GetDataForCity(string sName)
    {
        return null;
    }

    public Weather GetDataForCity(int zipcode)
    {
        return null;
    }

    public Weather GetDataForCity(double latitude, double longitude)
    {
        return null;
    }

    private string prepareRequest()
    {
        using (HttpRequestMessage oRequest = new HttpRequestMessage(HttpMethod.Get, m_sBaseURL))
        {
            
        }
        
        return String.Empty;
    }
}