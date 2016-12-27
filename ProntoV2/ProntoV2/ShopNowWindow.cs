using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
//g
namespace ProntoV2
{
    [Activity(Label = "ShopNowWindow")]
    public class ShopNowWindow : Activity
    {
        ListView listView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ShopNowWindow);
            LinearLayout item1 = (LinearLayout)((LayoutInflater)this.GetSystemService(Context.LayoutInflaterService)).Inflate(Resource.Layout.ListItem, null);
            LinearLayout item2 = (LinearLayout)((LayoutInflater)this.GetSystemService(Context.LayoutInflaterService)).Inflate(Resource.Layout.ListItem, null);

            LinearLayout main = (LinearLayout)FindViewById(Resource.Id.main);
            TextView text = new TextView(Application.Context);
            text.Text = "shya";
            main.AddView(item1);
            main.AddView(item2);
            // listView.AddView(item);
            
        }
    }

}