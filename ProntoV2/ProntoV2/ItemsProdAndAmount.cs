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
using ProntoV2;

namespace ProntoV2
{
    class ItemsProdAndAmount
    {
        public ItemsProdAndAmount(Product p, int am)
        {
            key = p;
            amount = am;
        }

        private Product key;
        private int amount;

        public Product Key
        {
            set { key = value; }
            get { return key; }
        }

        public int Amount
        {
            set { amount = value; }
            get { return amount; }
        }
    }
}