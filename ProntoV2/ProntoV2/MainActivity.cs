using Android.App;
using Android.OS;
using System;
using System.IO;
using System.Linq;


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
            FindViewById(Resource.Id.historyBtn).Click +=(s,e)=> StartActivity(typeof(PreviousShoppings));
            buildTable.Initialize();
            TraslateXML();

            FindViewById(Resource.Id.shopNowButton).Click += OpenBarcode;
        }
        private async void OpenBarcode(object sender, EventArgs e)
        {
            StartActivity(typeof(ShopNowWindow));
            //var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            //scanner.TopText = "Scan Store QR";
            //var result = await scanner.Scan();
            //if (result != null)
            //{
            //    AlertDialog.Builder dlgAlert = new AlertDialog.Builder(this);
            //    dlgAlert.SetMessage("This is an alert with no consequence");
            //    dlgAlert.SetTitle("App Title");
            //    dlgAlert.SetPositiveButton("Retry", (s, ee) => OpenBarcode(sender, e));
            //    dlgAlert.SetCancelable(true);
            //    dlgAlert.Create().Show();
            //    //readDataBase
            //    StartActivity(typeof(ShopNowWindow));
            //}
            //else
            //    return;


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

