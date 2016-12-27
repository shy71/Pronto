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
    class Item
    {
        public DateTime PriceUpdateDate { get; set; }
        public string ItemCode { get; set; }
        public bool ItemType { get; set; }
        public string ItemName { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufactureCountry { get; set; }
        public string ManufacturerItemDescription { get; set; }
        public string UnitQty { get; set; }
        public float Quantity { get; set; }
        public bool bIsWeighted { get; set; }
        public string UnitOfMeasure { get; set; }
        public bool QtyInPackage { get; set; }
        public int ItemPrice { get; set; }
        public float UnitOfMeasurePrice { get; set; }
        public bool AllowDiscount { get; set; }
        public bool ItemStatus { get; set; }
    }
}