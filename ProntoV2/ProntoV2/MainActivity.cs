﻿using Android.App;
using Android.OS;
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
            TestSQL();           
            
            // TraslateXML();
            // Set our view from the "main" layout resource
            //SetContentView (Resource.Layout.Main);
            //TraslateXML();
           // FindViewById(Resource.Id.shopNowButton).Click += (s, e) => StartActivity(typeof(ShopNowWindow));
           
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

