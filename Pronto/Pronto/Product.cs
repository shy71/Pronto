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
    [path(@"Products.xml","Product","Barcode")]
    class Product
    {
        private String barcode;
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

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }
        int quantity;

        public override string ToString()
        {
            return "barcode:"+barcode+ "; manufacturer:"+ manufacturer+"; description:"+description+";"
        }
    }
}