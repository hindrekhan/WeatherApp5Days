using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WeatherApp.Core
{
    public class Weather
    {
        public string Date { get; set; } = " ";
        public string Temperature { get; set; } = " ";
        public string TemperatureLow { get; set; } = " ";
        public string Pressure { get; set; } = " ";
        public string WindSpeed { get; set; } = " ";
        public string ImageName { get; set; } = " ";
    }
}