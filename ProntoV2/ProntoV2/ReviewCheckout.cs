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
    [Activity(Label = "ReviewCheckout")]
    public class ReviewCheckout : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ReviewCheckout);
            ((Spinner)FindViewById(Resource.Id.daySpinner)).Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, Enumerable.Range(1, 31).Select(x=>x.ToString()).ToList());
            ((Spinner)FindViewById(Resource.Id.monthSpinner)).Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, Enumerable.Range(1, 12).Select(x => x.ToString()).ToList());
        }
    }
}