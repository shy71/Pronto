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
    public class Item
    {


        public Item() { }
        public Item(string ic, bool it, string name,string mn,string mCountry, string Description,string unitQty, double qty,bool bIsWhighted, bool quantitInPackage,string unitOfMeasure, double price,double unitofmeasureprice, bool allowD, bool status)
        {
            ItemCode = ic;
            ItemType = it;
            ItemName = name;
            ManufacturerName = mn;
            ManufactureCountry = mCountry;
            ManufacturerItemDescription = Description;
            UnitQty = unitQty;
            Quantity = qty;
            bIsWeighted = bIsWhighted;
            UnitOfMeasure = unitOfMeasure;
            QtyInPackage = quantitInPackage;
            ItemPrice = price;
            UnitOfMeasurePrice = unitofmeasureprice;
            AllowDiscount = allowD;
            ItemStatus = status;
        }


        public DateTime PriceUpdateDate { get; set; }
        public string ItemCode { get; set; }
        public bool ItemType { get; set; }
        public string ItemName { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufactureCountry { get; set; }
        public string ManufacturerItemDescription { get; set; }
        public string UnitQty { get; set; }
        public double Quantity { get; set; }
        public bool bIsWeighted { get; set; }
        public string UnitOfMeasure { get; set; }
        public bool QtyInPackage { get; set; }
        public double ItemPrice { get; set; }
        public double UnitOfMeasurePrice { get; set; }
        public bool AllowDiscount { get; set; }
        public bool ItemStatus { get; set; }
    }
}