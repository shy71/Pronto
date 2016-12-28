using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProntoV2
{
    /*static class XmlTools
    {
        public static void Addx<t>(this t a) where t : new()
        {
          //  var documents = ProntoV2.GetFolderPath(ProntoV2.SpecialFolder.MyDocuments); TODO
            // var filename = Path.Combine(documents, "purchaes.xml"); TODO
            //File.WriteAllText(filename, "Write this text into a file!");TODO
            //pathAttribute v = a.GetType().GetCustomAttribute<pathAttribute>();
            //XElement x = XElement.Load(typeof(t).GetCustomAttribute<pathAttribute>().path);
            //x.Add(a.t_to_xml());
            //x.Save(v.path);
        }
        public static void removex<t>(string key) where t : new()
        {
            var new_t = Get_Allx<t>().Where(y => y.get_key() != key).ToList();
            FileStream fss;
            fss = new FileStream(typeof(t).GetCustomAttribute<pathAttribute>().path, FileMode.Create);
            fss.Flush();
            XmlSerializer xmlss = new XmlSerializer(typeof(List<t>));
            xmlss.Serialize(fss, new_t);
            fss.Close();
        }
        public static void update<t>(this t a) where t : new()
        {
            removex<t>(a.get_key());
            a.Addx();
        }
        public static t get_t<t>(string key) where t : new()
        {
            var v = Get_Allx<t>();
            return (from Product in v
                    where Product.get_key() == key
                    select Product).FirstOrDefault();
        }
        public static IEnumerable<t> Get_Allx<t>() where t : new()
        {
            pathAttribute v = typeof(t).GetCustomAttribute<pathAttribute>();
            if (!new FileInfo(typeof(t).GetCustomAttribute<pathAttribute>().path).Exists)
            {
                FileStream fs;
                fs = new FileStream(v.path, FileMode.OpenOrCreate);
                XmlSerializer xmls = new XmlSerializer(typeof(List<t>));
                xmls.Serialize(fs, new List<t>());
                fs.Close();
                return null;
            }
            FileStream fss;
            fss = new FileStream(v.path, FileMode.OpenOrCreate);

            XmlSerializer xmlss = new XmlSerializer(typeof(List<t>));
            List<t> r = (List<t>)xmlss.Deserialize(fss);
            fss.Close();
            return r;
        }
        public static void SaveAllItems(List<Item> l)
        {
          
        }
    }
    //{
        //    public static void Addx<t>(this t a) where t : new()
        //    {
        //  var documents = ProntoV2.GetFolderPath(ProntoV2.SpecialFolder.MyDocuments); TODO
        // var filename = Path.Combine(documents, "purchaes.xml"); TODO
        //File.WriteAllText(filename, "Write this text into a file!");TODO
        //pathAttribute v = a.GetType().GetCustomAttribute<pathAttribute>();
        //XElement x = XElement.Load(typeof(t).GetCustomAttribute<pathAttribute>().path);
        //x.Add(a.t_to_xml());
        //x.Save(v.path);
        //    }
        //    public static void removex<t>(string key) where t : new()
        //    {
        //        var new_t = Get_Allx<t>().Where(y => y.get_key() != key).ToList();
        //        FileStream fss;
        //        fss = new FileStream(typeof(t).GetCustomAttribute<pathAttribute>().path, FileMode.Create);
        //        fss.Flush();
        //        XmlSerializer xmlss = new XmlSerializer(typeof(List<t>));
        //        xmlss.Serialize(fss, new_t);
        //        fss.Close();
        //    }
        //    public static void update<t>(this t a) where t : new()
        //    {
        //        removex<t>(a.get_key());
        //        a.Addx();
        //    }
        //    public static t get_t<t>(string key) where t : new()
        //    {
        //        var v = Get_Allx<t>();
        //        return (from Product in v
        //                where Product.get_key() == key
        //                select Product).FirstOrDefault();
        //    }
        //    public static IEnumerable<t> Get_Allx<t>() where t : new()
        //    {
        //        pathAttribute v = typeof(t).GetCustomAttribute<pathAttribute>();
        //        if (!new FileInfo(typeof(t).GetCustomAttribute<pathAttribute>().path).Exists)
        //        {
        //            FileStream fs;
        //            fs = new FileStream(v.path, FileMode.OpenOrCreate);
        //            XmlSerializer xmls = new XmlSerializer(typeof(List<t>));
        //            xmls.Serialize(fs, new List<t>());
        //            fs.Close();
        //            return null;
        //        }
        //        FileStream fss;
        //        fss = new FileStream(v.path, FileMode.OpenOrCreate);

    }
        static string get_key<t>(this t a)
        {
            return (string)a.GetType().GetProperty(a.GetType().GetCustomAttribute<pathAttribute>().key).GetValue(a);
        }
        static XElement t_to_xml<t>(this t a)
        {
            pathAttribute v = a.GetType().GetCustomAttribute<pathAttribute>();
            XElement Root = new XElement(v.name);
            foreach (var Product in a.GetType().GetProperties())
            {
                XElement x = new XElement(Product.Name, Product.GetValue(a));
                Root.Add(x);
            }
            return Root;
        }
    }
   */

    public class LoadPrices
    {
        private XElement pricesRoot;
       
        private void LoadData(Stream strm)
        {
            try
            {
                pricesRoot = XElement.Load(strm);//check what is the path
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        public List<Item> GetPricesList(Stream strm)
        {
            LoadData(strm);
            List<Item> items;
            try
            {
                items = (from p in pricesRoot.Elements()
                         select new Item()
                         {
                             PriceUpdateDate = Convert.ToDateTime(p.Element("PriceUpdateDate").Value),
                             ItemCode = p.Element("ItemCode").Value,
                             ItemType = Convert.ToBoolean(p.Element("ItemType").Value),
                             ItemName = p.Element("ItemName").Value,
                             ManufactureCountry = p.Element("ManufactureCountry").Value,
                             ManufacturerName = p.Element("ManufacturerName").Value,
                             ManufacturerItemDescription = p.Element("ManufacturerItemDescription").Value,
                             UnitQty = p.Element("UnitQty").Value,
                             Quantity = float.Parse(p.Element("Quantity").Value),
                             bIsWeighted = bool.Parse(p.Element("bIsWeighted").Value),
                             UnitOfMeasure = p.Element("UnitOfMeasure").Value,                  //float
                             QtyInPackage = Convert.ToBoolean(p.Element("QtyInPackage").Value),
                             ItemPrice = Convert.ToInt32(p.Element("ItemPrice").Value),
                             UnitOfMeasurePrice = float.Parse(p.Element("UnitOfMeasurePrice").Value),        //float
                             AllowDiscount = Convert.ToBoolean(p.Element("AllowDiscount").Value),
                             ItemStatus = Convert.ToBoolean(p.Element("ItemStatus").Value)
                         }).ToList();
            }
            catch
            {
                items = null;
            }
            return items;
        }
    }
}