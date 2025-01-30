namespace WeatherMap.Entities;

public class Weather
{
    public string sName { get; private set; }
    public int nZipCode { get; private set; }
    public string sCounty { get; private set; }
    public DateTime oDate { get; private set; }

    public Weather(string name, int zip, string county, DateTime date)
    {
        this.sName = name;
        this.nZipCode = zip;
        this.sCounty = county;
        this.oDate = date;
    }
}