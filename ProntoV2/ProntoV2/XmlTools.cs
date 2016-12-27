using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProntoV2
{
    static class XmlTools
    {
        public static List<Item> getAllItem(Stream f)
        {
            FileStream fss;
            fss = f as FileStream;
            XmlSerializer xmlss = new XmlSerializer(typeof(List<Item>));
            List<Item> r = (List<Item>)xmlss.Deserialize(fss);
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
}