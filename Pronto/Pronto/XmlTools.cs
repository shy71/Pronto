using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;

namespace Pronto
{
    static class XmlTools
    {
        public static void Addx<t>(this t a) where t : new()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents, "purchaes.xml");
            File.WriteAllText(filename, "Write this text into a file!");
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
    [AttributeUsage(AttributeTargets.Class)]
    public class pathAttribute : Attribute
    {
        public string key;
        public string name;
        public string path { get; set; }
        public pathAttribute(string p, string n, string k)
        {
            path = @"Assets/xml/" + p;
            name = n;
            key = k;
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
        }
    }
}