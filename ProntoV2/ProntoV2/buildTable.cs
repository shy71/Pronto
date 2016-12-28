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
        string folder;
        SQLiteConnection conn;

        public buildTable()
        {
            folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(folder, "myAmmazingApp.db"));
            conn.CreateTable<Item>();
            //conn.CreateTable<Product>();
            //  conn.CreateTable<Products>();
        }


        public static void AddItem(SQLiteConnection db, Item itm)
        {
            db.Insert(itm);
            Console.WriteLine(itm.ToString());
        }

        public void AddItem(Item itm)
        {
            AddItem(conn, itm);
        }

        public void buildItUp(Stream strm)
        {
            LoadPrices myLoader = new LoadPrices();
            foreach (var item in myLoader.GetPricesList(strm))
            {
                AddItem(item);
            }
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