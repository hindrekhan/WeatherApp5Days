using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WeatherApp.Core
{
    public class Core
    {
        const string Key = "e75b73caed0d728414c37cd7037d4291";

        public static async Task<Weather> GetWeather(string location)
        {
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=" + location + "&APPID=" + Key + "&units=metric";

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);
            if (results["weather"] == null)
                return null;

            var weather = new Weather();
            weather.Temperature = (string)results["main"]["temp"] + " C";
            weather.Pressure = (string)results["main"]["pressure"] + " hPa";
            weather.WindSpeed = (string)results["wind"]["speed"] + " M/S";
            
            weather.ImageName = "_" + (string)results["weather"][0]["icon"];
            return weather;
        }

        public static async Task<List<Weather>> Get5DaysWeather(string location)
        {
            string queryString = "http://api.openweathermap.org/data/2.5/forecast?q=" + location + "&APPID="+ Key;

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);
            if (results == null)
                return null;
            
            List<Weather> weathers = new List<Weather>();

            for (int i = 0; i < 5; i++)
            {
                Weather weather = new Weather();
                weather.Temperature = (string)results["list"][0]["main"]["temp"];
                Debug.WriteLine(weather.Temperature);
            }

            return weathers;
        }
    }
}
