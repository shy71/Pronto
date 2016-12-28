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
using System.IO;
using SQLite;

namespace ProntoV2
{
    class Test
    {
        string folder;
        SQLiteConnection conn;

        public Test()
        {
            folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(folder, "myAmmazingApp.db"));
            conn.CreateTable<Item>();
        }
        
        public void Create()
        {
            Item itm1 = new Item("7296014048203", true, "tishu", "haznazuzi", "israel", "nice tishu", "pieces", 2, false,true,"gram",24,12,true,true);
            Item itm2 = new Item("013495113537", true, "klik", "elit", "israel", "klik white and brown", "100 g", 2, false, true, "gram", 10, (float)9.4, true, true);
            Item itm3 = new Item("729001370255", true, "shweps", "haznazuzi", "italy", "good shweps drink", "100 ml", 2, false, true, "ml", 12, 3, true, true);
            buildTable.AddItem(conn, itm1);
            buildTable.AddItem(conn, itm2);
            buildTable.AddItem(conn, itm3);
        }

        public IEnumerable<Item> GetProduction(string barcode)
        {
            return conn.Table<Item>().Where(itm => itm.ItemCode == barcode);
        }

        public IEnumerable<Item> Search(string query)
        {
            return conn.Table<Item>().Where(itm => itm.ManufacturerItemDescription.Contains(query));
        }

    }
}