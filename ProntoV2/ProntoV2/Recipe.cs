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
using Android.Content.Res;

namespace ProntoV2
{
    [Activity(Label = "Recipe")]
    public class Recipe : Activity
    {
        double count = 0;
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
            var v = GetText(" סך-הכל: " + count.ToString());
            v.Gravity = GravityFlags.Left;
            v.SetTextColor(Android.Graphics.Color.Gray);
            v.SetTextSize(Android.Util.ComplexUnitType.Sp, 40);
            main.AddView(v);
            count = 0;
        }
        LinearLayout GetItem(ItemsProdAndAmount item)
        {
            count += item.Amount * item.Key.ItemPrice;
            LinearLayout lin=new LinearLayout(Application.Context);
            lin.SetGravity(GravityFlags.Right);
            var a = GetText(item.Amount + "x");
            a.SetTextColor(Android.Graphics.Color.Gray);
            lin.AddView(a);
            var i = GetText(item.Key.ItemPrice + " - ");
            i.SetTextColor(Android.Graphics.Color.Gray);
            lin.AddView(i);

            var m = GetText(item.Key.ManufacturerItemDescription);
            m.SetTextColor(Android.Graphics.Color.Gray);

            lin.AddView(m);
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