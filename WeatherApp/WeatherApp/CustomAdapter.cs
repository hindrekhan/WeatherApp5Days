using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WeatherApp.Core;
using Android.Support.V7.App;
using Android.Content.Res;

namespace WeatherApp
{
    public class CustomAdapter : BaseAdapter<Weather>
    {
        List<Weather> items;
        List<int> images;
        Activity context;

        public CustomAdapter(Activity context, List<Weather> items, List<int> images) : base()
        {
            this.context = context;
            this.items = items;
            this.images = images;
        }

        public override Weather this[int position]
        {
            get { return items[position]; }
        }

        public override int Count { get { return items.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
               view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);

            view.FindViewById<TextView>(Resource.Id.date).Text = items[position].Date;

            var image = view.FindViewById<ImageView>(Resource.Id.icon);
            image.SetImageResource(images[position]);

            view.FindViewById<TextView>(Resource.Id.tempHigh).Text = items[position].Temperature;
            view.FindViewById<TextView>(Resource.Id.tempLow).Text = items[position].TemperatureLow;
            
            return view;
        }
    }
}