﻿using Android.App;
using Android.OS;
using System.IO;
namespace ProntoV2
{
    [Activity(Label = "ProntoV2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            StartActivity(typeof(PreviousShoppings));
        }
        public void TraslateXML()
        {
            Stream input = Assets.Open("my_asset.txt");

            new LoadPrices().GetPricesList(input);
             
        }
    }
}

