using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using WeatherMap.APIRequests;
using WeatherMap.Entities;

namespace WeatherMap;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private WeatherAPI m_oAPI;

    public MainWindow()
    {
        InitializeComponent();
        m_oAPI = new WeatherAPI();
    }

    private void UseCurrentLocationButton_OnClick(object sender, RoutedEventArgs e)
    {
        Search();
    }

    private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            Search();
        }
    }

    private void Search()
    {
        string sInput = LocationInput.Text.Trim();
        
        JSONObjectFromString? data = m_oAPI.GetDataForCity(sInput).Result;
        
        if (data != null)
        {
            LocationNameValue.Content = data.sName;
            LocationCountryValue.Content = data.sCountry;
            LocationLongitudeValue.Content = data.Longitude;
            LocationLatitudeValue.Content = data.Latitude;
            LocationTemperatureValue.Content = data.dTemperature;
            LocationWindSpeedValue.Content = data.dWindSpeed;
            LocationHumidityValue.Content = data.dHumidity;
        }
    }

    private void LocationInput_OnGotFocus(object sender, RoutedEventArgs e)
    {
        LocationInput.Text = string.Empty;
    }

    private void LocationInput_OnLostFocus(object sender, RoutedEventArgs e)
    {
        if (LocationInput.Text == String.Empty)
        {
            LocationInput.Text = "Location's Name";
        }
    }
}