namespace WeatherMap.JSON;

public class WeatherMapper
{
    private static WeatherMapper _instance;
    
    private WeatherMapper()
    {
        
    }

    public static WeatherMapper Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new WeatherMapper();
                return _instance;
            }
            else
            {
                return _instance;
            }
        }
    }
    
    
}