using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using System;
using System.IO;
using System.Linq;
using ZXing.Mobile;


namespace ProntoV2
{
    [Activity(Label = "ProntoV2", MainLauncher = true, Icon = "@drawable/icon",ScreenOrientation =Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            ActionBar.Hide();
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
          //  PHPGetter.PHPGet();
            SetContentView (Resource.Layout.Main);
            FindViewById(Resource.Id.historyBtn).Click +=(s,e)=> StartActivity(typeof(PreviousShoppings));
            buildTable.Initialize();
            //buildTable.Create();
            //TraslateXML();
            //Log.Info("ProntoDB", "The file is in the path: " + buildTable.getDBPath());
            //if(!File.Exists(buildTable.getDBPath()))
            //{
            //    StreamReader input = new StreamReader(Assets.Open("ProntoDB.db"));
            //    using (StreamWriter outputFile = new StreamWriter(buildTable.getDBPath()))
            //    {
            //        input.BaseStream.CopyToAsync(outputFile.BaseStream);
            //    }
            //}

            FindViewById(Resource.Id.shopNowButton).Click += (s, e) => OpenBarcode(null, null);//StartActivity(typeof(ShopNowWindow));
        }
        private async void OpenBarcode(object sender, EventArgs e)
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            scanner.TopText = "Scan the store QR Code";
            var result = await scanner.Scan(Application.Context, MobileBarcodeScanningOptions.Default);
            try
            {
                if (result != null)
                {
                    var array = result.Text.Split(';');
                    var activity2 = new Intent(this, typeof(ShopNowWindow));
                    //get file with url in array[0]
                    activity2.PutExtra("StoreMsg", array[1]);
                    StartActivity(activity2);
                }

            }
            catch { }
        }

        public void TraslateXML()
        {
            /*
            Stream input = Assets.Open("prices.xml");

            new LoadPrices().GetPricesList(input);
            */
            Purchase p = new Purchase();
            Item t = new Item();
            t.ItemName = "king";
            t.ItemPrice = 2;
            ItemsProdAndAmount i = new ItemsProdAndAmount(t, 5);
            p.AddItem(i);

            PurchesManager pm = new PurchesManager();
            pm.Save(p);
            
            
        }

        public void TestSQL()
        {
            Test myTest = new Test();
           // myTest.Create();

            Item itm = myTest.GetProduction("7296014048203").First();

            
        }
    }
}

