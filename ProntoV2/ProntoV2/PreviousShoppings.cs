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

namespace ProntoV2
{
    [Activity(Label = "PreviousShoppings")]
    public class PreviousShoppings : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ActionBar.Hide();
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PreviousShoppings);
            LinearLayout item1 = (LinearLayout)((LayoutInflater)this.GetSystemService(Context.LayoutInflaterService)).Inflate(Resource.Layout.PreviousShoppingPreview, null);
            LinearLayout item2 = (LinearLayout)((LayoutInflater)this.GetSystemService(Context.LayoutInflaterService)).Inflate(Resource.Layout.PreviousShoppingPreview, null);
            LinearLayout item3 = (LinearLayout)((LayoutInflater)this.GetSystemService(Context.LayoutInflaterService)).Inflate(Resource.Layout.PreviousShoppingPreview, null);
            LinearLayout item4 = (LinearLayout)((LayoutInflater)this.GetSystemService(Context.LayoutInflaterService)).Inflate(Resource.Layout.PreviousShoppingPreview, null);

            GridLayout main = (GridLayout)FindViewById(Resource.Id.main);

            main.AddView(item1);
            main.AddView(item2);
            main.AddView(item3);
            main.AddView(item4);
            // listView.AddView(item);
        }
    }
}