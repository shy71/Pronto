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
    [path(@"Products.xml", "Product", "Barcode")]
    class Product
    {

        public string Barcode { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return "barcode:" + Barcode + "; manufacturer:" + Manufacturer + "; description:" + Description;
        }
    }
}