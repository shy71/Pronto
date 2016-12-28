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
using ZXing.Mobile;
using ZXing.QrCode;
using Android.Preferences;
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
            ManageShoppingItems.SetActivtiy(this);
            Refresh();
            //FindViewById(Resource.Id.addBtn).Click += null;
            FindViewById(Resource.Id.checkoutBtn).Click += (s, e) => StartActivity(typeof(ReviewCheckout));
            MobileBarcodeScanner.Initialize(Application);
            FindViewById(Resource.Id.addBtn).Click += OpenBarcode;
        }
        private async void OpenBarcode(object sender, EventArgs e)
        {   
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            scanner.TopText = "scan the product barcode";
            var result = await scanner.Scan();
            try {
                if (result != null)
                AddItem(buildTable.GetProduction(result.Text).FirstOrDefault());
            }
            catch { }
        }

        public void Refresh()
        {
            LinearLayout main = ((LinearLayout)FindViewById(Resource.Id.main));
            main.RemoveAllViews();
            foreach (var item in ManageShoppingItems.Items)
                AddItemToList(item.Key,item.Amount);
        }
        public void AddItem(Item item)
        {
            ManageShoppingItems.Items.Add(new ItemsProdAndAmount(item, 1));
            AddItemToList(item);
        }
        private void AddItemToList(Item item,int amount=1)
        {
            if (item == null)
                return;
            LinearLayout view = (LinearLayout)((LayoutInflater)this.GetSystemService(Context.LayoutInflaterService)).Inflate(Resource.Layout.ListItem, null);
            //view.FindViewById(Resource.Id.foodIcon)
            ((TextView)view.FindViewById(Resource.Id.foodName)).Text = (item.ManufacturerItemDescription.Length > 15) ? item.ManufacturerItemDescription.Substring(0, 15) : item.ManufacturerItemDescription;
            ((TextView)view.FindViewById(Resource.Id.foodCompany)).Text = (item.ManufacturerName.Length > 15) ? item.ManufacturerName.Substring(0, 15) : item.ManufacturerName;
            ((TextView)view.FindViewById(Resource.Id.pricePerUnit)).Text = item.ItemPrice.ToString() + '¤';
            ((TextView)view.FindViewById(Resource.Id.qty)).Text = amount.ToString();
            view.Click += (e, s) =>
            {
                var activity2 = new Intent(this, typeof(ItemDetails));
                activity2.PutExtra("ItemCode", item.ItemCode);
                activity2.PutExtra("ItemQty", ((TextView)view.FindViewById(Resource.Id.pricePerUnit)).Text);
                StartActivity(activity2);
            };
            ((LinearLayout)FindViewById(Resource.Id.main)).AddView(view);
        }
    }

}