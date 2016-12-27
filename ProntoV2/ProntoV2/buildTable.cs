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
using SQLite;

namespace ProntoV2
{
    class buildTable
    {
        string folder;
        SQLiteConnection conn;

        buildTable()
        {
            folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(folder, "myAmmazingApp.db"));
            conn.CreateTable<Item>();
            //conn.CreateTable<Product>();
            //  conn.CreateTable<Products>();
        }


        public static void AddStock(SQLiteConnection db, string symbol, Item itm)
        {
            db.Insert(itm);
            Console.WriteLine(itm.ToString());
        }

        // empty!!!!!!!!!!!!!!!!!!
        public void buildItUp()
        {

        }

        public IEnumerable<Item> GetProduction(string barcode)
        {
            return conn.Table<Item>().Where(itm => itm.ItemCode == barcode);
        }

        public IEnumerable<Item> Search(string query)
        {
            return conn.Table<Item>().Where(itm => itm.(query));
        }

    }
}