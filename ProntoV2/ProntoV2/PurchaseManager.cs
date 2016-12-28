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

        public Purchase Load(string file)
        {
            var input =new StreamReader(Application.Context.OpenFileInput(file));
            string str = input.ReadToEnd();
            var array=str.Split(',');
            Purchase pur = new Purchase();
            int i = 0;
            for ( i = 0; i < array.Length-1; i += 2)
                pur.AddItem(new ItemsProdAndAmount(buildTable.GetProduction(array[i]).First(), Convert.ToInt32(array[i + 1])));
            pur.ShopID =Convert.ToInt32( array.Last());
            return pur;
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
            path = finalPath.Replace("/","-");

            var outputStream =new StreamWriter( Application.Context.OpenFileOutput(path, FileCreationMode.Private));
            String str = "";
            foreach (var item in listofa.GetItems())
            {
                str += item.Key.ItemCode + "," + item.Amount;
            }
            str += listofa.ShopID;
            
            outputStream.Write(str);
            outputStream.Close();
        }
    }


}