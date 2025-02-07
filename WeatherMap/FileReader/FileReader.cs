using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace WeatherMap.FileReader;

public class FileReader
{
    private static FileReader _instance;
    
    private readonly string sPathToFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    private readonly string sFolderName = "Testing";
    private readonly string sFileName = "weatherApi.json";

    private string sFullPath;

    private FileReader()
    {
        sFullPath = Path.Combine(sPathToFolder, sFolderName);
        sFullPath = Path.Combine(sFullPath, sFileName);
    }

    public static FileReader Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new FileReader();
                return _instance;
            }
            else
            {
                return _instance;
            }
        }
    }

    public string ReadFile()
    {
        string sReturnString =  String.Empty;
        
        using (StreamReader reader = new StreamReader(sFullPath))
        {
            sReturnString = reader.ReadToEnd();
        }

        JsonObject json = JsonSerializer.Deserialize<JsonObject>(sReturnString);
        if (json.ContainsKey("key"))
        {
            sReturnString = json["key"].ToString();
        }
        
        return sReturnString;
    }
}