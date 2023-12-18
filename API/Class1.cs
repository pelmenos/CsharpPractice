using System.Net;
using Default;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API;

public class ApiManager
{
    private static JObject _getWhetherJson(string city)
    {
        string API_URL = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=b6c926e991d8a79686142fdd9354e7c8&units=metric";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API_URL);
        request.Method = "GET";
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader reader = new StreamReader(stream);
        string jsonString = reader.ReadToEnd();

        response.Close();
        return JObject.Parse(jsonString);
    }

    public static double GetTemperature(string? city)
    {
        JObject json = _getWhetherJson(city);
        return Double.Parse(json["main"]["temp"].ToString());
    }
}