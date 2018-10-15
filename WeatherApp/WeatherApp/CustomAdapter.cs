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

namespace WeatherApp
{
    public class CustomAdapter : BaseAdapter<Weather>
    {
        public List<Weather> items;
        Activity context;

        public CustomAdapter(Activity context, List<Weather> items) : base()
        {
            this.context = context;
            this.items = items;
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
            
            var image = view.FindViewById<TextView>(Resource.Id.imageView1);
            var packName = MainActivity.packName
            image.SetImageResource(Resources.GetIdentifier(items[position].ImageName, "drawable", packName));
            
            return view;
        }
    }
}