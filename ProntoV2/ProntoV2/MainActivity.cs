using Android.App;
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
            TraslateXML();
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            FindViewById(Resource.Id.shopNowButton).Click += (s, e) => StartActivity(typeof(ShopNowWindow));
           
            StartActivity(typeof(PreviousShoppings));
        }
        public void TraslateXML()
        {
            Stream input = Assets.Open("prices.xml");

            //new LoadPrices().GetPricesList(input);
             
        }
    }
}

