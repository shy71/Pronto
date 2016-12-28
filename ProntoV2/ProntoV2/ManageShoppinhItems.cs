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
    static class ManageShoppingItems
    {
        static private List<ItemsProdAndAmount> items=new List<ItemsProdAndAmount>();
        static private ShopNowWindow activity;
        static public void SetActivtiy(ShopNowWindow act)
        {
            activity = act;
        }
        static public List<ItemsProdAndAmount> Items
        {
            get { return items; }
            set { items = value; }
        }
        static public int plusAmunt(Item item)
        {
           return ++Items.Find(x => x.Key.ItemCode.Equals(item.ItemCode)).Amount;
        }
        static public int minusAmunt(Item item)
        {
            return --Items.Find(x => x.Key.ItemCode.Equals(item.ItemCode)).Amount;
        }
        static public void Refresh()
        {
            activity.Refresh();
        }

    }
}