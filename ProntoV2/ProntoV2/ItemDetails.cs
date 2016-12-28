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
    [Activity(Label = "ItemDetails")]
    public class ItemDetails : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ItemDetails);
            string barcode = Intent.GetStringExtra("ItemCode") ?? "Data not available";
            string qty = Intent.GetStringExtra("ItemQty") ?? "Data not available";
            var conn=new buildTable();
            Item item=conn.GetProduction(barcode).FirstOrDefault();
            Toast.MakeText(Application.Context,"Could not found barcode",ToastLength.Short);
            Finish();
            ((TextView)FindViewById(Resource.Id.description)).Text = item.ItemName;
            ((TextView)FindViewById(Resource.Id.foodCompany)).Text = item.ManufacturerName;
            ((TextView)FindViewById(Resource.Id.pricePerUnit)).Text = item.ItemPrice.ToString();
            ((TextView)FindViewById(Resource.Id.qty)).Text = qty;
            ((TextView)FindViewById(Resource.Id.plusButton)).Click += (s,e)=>(Convert.ToInt32(((TextView)FindViewById(Resource.Id.qty)).Text)+1).ToString();
            ((TextView)FindViewById(Resource.Id.plusButton)).Click += (s, e) => (Convert.ToInt32(((TextView)FindViewById(Resource.Id.qty)).Text) -1).ToString();



            // Create your application here
        }
    }
}