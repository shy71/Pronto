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
using ProntoV2;

namespace ProntoV2
{

    class PurchesManager
    {

        public List<Purchase> Load(string file)
        {
            List<Purchase> listofa = new List<Purchase>();
            XmlSerializer formatter = new XmlSerializer(typeof(Purchase));
            FileStream aFile = new FileStream(file, FileMode.Open);
            byte[] buffer = new byte[aFile.Length];
            aFile.Read(buffer, 0, (int)aFile.Length);
            MemoryStream stream = new MemoryStream(buffer);
            return (List<Purchase>)formatter.Deserialize(stream);
        }

        public void Save(Purchase listofa)
        {
            string path =DateTime.Now.ToShortDateString();
            int i = 1;
            string finalPath = path;
            while (File.Exists(Application.Context.FilesDir + "/"+finalPath))
            {
                finalPath = path + i++;
            }
            path =/* Application.Context.FilesDir + "/"+*/ finalPath.Replace("/","-");

            var outputStream =Application.Context.OpenFileOutput(path, FileCreationMode.Private);
            String str = "";
            foreach (var item in listofa.GetItems())
            {
                str+=item.Key.ItemCode+","+item.Amount;
            }
            outputStream.Write(Encoding.ASCII.GetBytes(str), 0, str.Length);
            outputStream.Close();
        }
    }


}