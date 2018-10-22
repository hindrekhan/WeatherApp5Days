using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApp.Core;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace WeatherApp
{
    [Activity(Label = "WeatherListActivity", Theme = "@style/MyTheme")]
    public class WeatherListActivity : AppCompatActivity
    {
        ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.weather_list);

            listView = FindViewById<ListView>(Resource.Id.listView1);

            string input = Intent.Extras.GetString("input");
            update_weather(input);
        }

        private async void update_weather(string input)
        {
            var weathers = await Core.Core.Get5DaysWeather(input);

            if (weathers != null)
            {
                List<int> images = new List<int>();

                foreach (Weather weather in weathers)
                {
                    images.Add(Resources.GetIdentifier(weather.ImageName, "drawable", PackageName));
                }

                listView.Adapter = new CustomAdapter(this, weathers, images);
            }
        }
    }
}