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
    class Product
    {
        private String barcode;

        private int price;

        public int Price
        {
            set { price = value; }
            get { return price; }
        }

        public String Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }
        private String manufacturer;

        public String Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }
        private String description;

        public String Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}