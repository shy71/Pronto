using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
//using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;

namespace ProntoV2
{
    class buildTable
    {
        static string folder;
        static SQLiteConnection conn;

        buildTable()
        {
            folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(folder, "myAmmazingApp.db"));
            conn.CreateTable<Item>();
            //conn.CreateTable<Product>();
            //  conn.CreateTable<Products>();
        }

        public static void Initialize()
        {
            folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(folder, "myAmmazingApp.db"));
            conn.CreateTable<Item>();
            //conn.CreateTable<Product>();
            //  conn.CreateTable<Products>(); }
        }

        public void Close() { conn.Close();folder = string.Empty; }
         
        public void Create()
        {
            Item itm1 = new Item("7296014048203", true, "tishu", "haznazuzi", "israel", "nice tishu", "pieces", 2, false, true, "gram", 24, 12, true, true);
            Item itm2 = new Item("013495113537", true, "klik", "elit", "israel", "klik white and brown", "100 g", 2, false, true, "gram", 10, (float)9.4, true, true);
            Item itm3 = new Item("729001370255", true, "schweps", "haznazuzi", "italy", "good shweps drink", "100 ml", 2, false, true, "ml", 12, 3, true, true);
            buildTable.AddItem(conn, itm1);
            buildTable.AddItem(conn, itm2);
            buildTable.AddItem(conn, itm3);
        }

        public static void AddItem(Item itm)
        {
            conn.Insert(itm);
            Console.WriteLine(itm.ToString());
        }

        public static void buildItUp(Stream strm)
        {
            LoadPrices myLoader = new LoadPrices();
            foreach (var item in myLoader.GetPricesList(strm))
            {
                AddItem(item);
            }
        }

        public static IEnumerable<Item> GetProduction(string barcode)
        {
            return conn.Table<Item>().Where(itm => itm.ItemCode == barcode);
        }

        public static IEnumerable<Item> Search(string query)
        {
            return conn.Table<Item>().Where(itm =>itm.ManufactureCountry.Contains(query) || itm.ManufacturerItemDescription.Contains(query) || itm.ManufacturerName.Contains(query) );
        }
    }
}