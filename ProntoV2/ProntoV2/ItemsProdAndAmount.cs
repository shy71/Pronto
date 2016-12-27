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
        public ItemsProdAndAmount(Item p, int am)
        {
            Key = p;
            Amount = am;
        }

        public Item Key { get; set; }
        public int Amount { get; set; }
    }
}