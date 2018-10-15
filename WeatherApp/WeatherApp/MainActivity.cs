using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using WeatherApp.Core;
using System;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button search;
        EditText input;
        TextView temperature;
        TextView pressure;
        TextView windSpeed;
        ImageView weatherIcon;
        ProgressBar progressBar;

        protected  override  void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            search = FindViewById<Button>(Resource.Id.search);
            input = FindViewById<EditText>(Resource.Id.input);
            temperature = FindViewById<TextView>(Resource.Id.temperature);
            pressure = FindViewById<TextView>(Resource.Id.pressure);
            windSpeed = FindViewById<TextView>(Resource.Id.windSpeed);
            weatherIcon = FindViewById<ImageView>(Resource.Id.weatherIcon);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            
            search.Click += Button_Click;

            SwapWeather();
            SwapProgressBar();
        }

        private async void Button_Click(object sender, System.EventArgs e)
        {
            if (temperature.Visibility == Android.Views.ViewStates.Visible)
            {
                SwapWeather();
            }

            SwapProgressBar();
            var weather = await Core.Core.GetWeather(input.Text);
            if(weather != null)
            {
                temperature.Text = weather.Temperature;
                pressure.Text = weather.Pressure;
                windSpeed.Text = weather.WindSpeed;

                weatherIcon.SetImageResource(Resources.GetIdentifier(weather.ImageName, "drawable", PackageName));
                SwapWeather();
            }

            SwapProgressBar();
        }

        private void SwapWeather()
        {
            if (temperature.Visibility == Android.Views.ViewStates.Invisible)
            {
                temperature.Visibility = Android.Views.ViewStates.Visible;
                pressure.Visibility = Android.Views.ViewStates.Visible;
                windSpeed.Visibility = Android.Views.ViewStates.Visible;
                weatherIcon.Visibility = Android.Views.ViewStates.Visible;
            }
            else
            {
                temperature.Visibility = Android.Views.ViewStates.Invisible;
                pressure.Visibility = Android.Views.ViewStates.Invisible;
                windSpeed.Visibility = Android.Views.ViewStates.Invisible;
                weatherIcon.Visibility = Android.Views.ViewStates.Invisible;
            }
        }

        private void SwapProgressBar()
        {
            if (progressBar.Visibility == Android.Views.ViewStates.Invisible)
            {
                progressBar.Visibility = Android.Views.ViewStates.Visible;
            }
            else
            {
                progressBar.Visibility = Android.Views.ViewStates.Invisible;
            }
        }
    }
}