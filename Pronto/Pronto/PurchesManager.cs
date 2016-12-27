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
using System.Xml.Serialization;
using System.IO;
using Pronto;

namespace Pronto
{

    class PurchesManager
    {

        private List<Purchase> Load(string file)
        {
            List<Purchase> listofa = new List<Purchase>();
            XmlSerializer formatter = new XmlSerializer(typeof(Purchase));
            FileStream aFile = new FileStream(file, FileMode.Open);
            byte[] buffer = new byte[aFile.Length];
            aFile.Read(buffer, 0, (int)aFile.Length);
            MemoryStream stream = new MemoryStream(buffer);
            return (List<Purchase>)formatter.Deserialize(stream);
        }

        private void Save(List<Product> listofa, string path)
        {
            FileStream outFile = File.Create(path);
            XmlSerializer formatter = new XmlSerializer(typeof(Purchase));
            formatter.Serialize(outFile, listofa);
        }
    }


}