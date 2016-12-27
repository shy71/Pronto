using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
namespace Pronto
{
    class Products
    {
        List<Product> cart=new List<Product>();
        public void add(Product i)
        {
            foreach (var P in cart)
            {
                if (P.Barcode == i.Barcode)
                {
                    P.Quantity += i.Quantity;
                    return;
                }
                   
            }
            i.Addx();
            cart.Add(i);
        }
        public List<Product> get_all()
        {
            return cart;
        }
        public Product get_last()
        {
            return cart.Last();
        }
        public List<Product> getAllFromXml()
        {
            return XmlTools.Get_Allx<Product>().ToList<Product>();
        }
    }
}