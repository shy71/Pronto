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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ShopNowWindow);
            //FindViewById(Resource.Id.addBtn).Click += null;
            FindViewById(Resource.Id.checkoutBtn).Click += (s, e) => StartActivity(typeof(ReviewCheckout));
            //LinearLayout item1 = (LinearLayout)((LayoutInflater)this.GetSystemService(Context.LayoutInflaterService)).Inflate(Resource.Layout.ListItem, null);
            //LinearLayout item2 = (LinearLayout)((LayoutInflater)this.GetSystemService(Context.LayoutInflaterService)).Inflate(Resource.Layout.ListItem, null);

            //LinearLayout main = (LinearLayout)FindViewById(Resource.Id.main);
            //TextView text = new TextView(Application.Context);
            //text.Text = "shya";
            //main.AddView(item1);
            //main.AddView(item2);
            // listView.AddView(item);
            
        }
        public void AddItemToList(Item item)
        {
            LinearLayout view = (LinearLayout)((LayoutInflater)this.GetSystemService(Context.LayoutInflaterService)).Inflate(Resource.Layout.ListItem, null);
            //view.FindViewById(Resource.Id.foodIcon)
            ((TextView)view.FindViewById(Resource.Id.foodName)).Text = (item.ManufacturerItemDescription.Length > 15) ? item.ManufacturerItemDescription.Substring(0, 15) : item.ManufacturerItemDescription;
            ((TextView)view.FindViewById(Resource.Id.foodCompany)).Text = (item.ManufacturerName.Length > 15) ? item.ManufacturerName.Substring(0, 15) : item.ManufacturerName;
            ((TextView)view.FindViewById(Resource.Id.pricePerUnit)).Text = item.ItemPrice.ToString() + '¤';
            ((TextView)view.FindViewById(Resource.Id.foodQTY)).Text ="1";
            view.Click += (e,s)=>
            {
                var activity2 = new Intent(this, typeof(ItemDetails));
                activity2.PutExtra("ItemCode",item.ItemCode);
                activity2.PutExtra("ItemQty",Convert.ToInt32(((TextView)view.FindViewById(Resource.Id.pricePerUnit)).Text));
                StartActivity(activity2);
            };
        }
    }

}