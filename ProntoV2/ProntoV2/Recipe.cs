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
    [Activity(Label = "Recipe")]
    public class Recipe : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ActionBar.Hide();

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Recipe);
            LinearLayout main = (LinearLayout)FindViewById(Resource.Id.main);
           main.SetGravity(GravityFlags.Right);
           main.AddView(GetText("קבלה"));
            foreach (var item in ManageShoppingItems.Items)
            {
                main.AddView(GetItem(item));
            }

        }
        LinearLayout GetItem(ItemsProdAndAmount item)
        {
            LinearLayout lin=new LinearLayout(Application.Context);
            
            lin.SetGravity(GravityFlags.Right);
            lin.AddView(GetText(item.Amount+"x"));
            lin.AddView(GetText(item.Key.ItemPrice + " - "));
            lin.AddView(GetText(item.Key.ManufacturerItemDescription));
            return lin;


        }
        TextView GetText(string text)
        {

            var view=new TextView(Application.Context);
            view.TextSize = 25;
            view.Text = text;
            return view;
        }
    }
}