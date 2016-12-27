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

namespace Pronto
{
    class Purchase
    {
        private Dictionary<Product, int> items;

        public Dictionary<Product, int> Items
        {
            get { return items; }
            set { items = value; }
        }   

        private int shopID;

        public int ShopID
        {
            get { return shopID; }
            set { shopID = value; }
        }


    }
}