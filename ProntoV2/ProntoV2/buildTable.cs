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
using Java.IO;

namespace ProntoV2
{
    public class buildTable
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
            conn = new SQLiteConnection(Path.Combine(folder, "myAmmazingApp.db"));
            conn.CreateTable<Item>();
            Create();
            //conn.CreateTable<Product>();
            //  conn.CreateTable<Products>(); }
        }

        public static string getDBPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myAmmazingApp.db");
        }

        public static void Close() { conn.Close();folder = string.Empty; }
         
        public static void Create()
        {
            Item itm1 = new Item("7290000066318", true, "במבה 80 גרם", "אסם", "IL", "במבה", "גרמים", 80.00, false, false, "100 גרם", 4.50, 5.63, true, true);
            Item itm2 = new Item("013495113537", true, "קליק חום לבן מעורב 75 גר", "יוניליוור", "IL", "קליק מעורב", "גרמים", 75.00, false, false, "100 גרם", 5.90, 7.87 , true, true);
            Item itm3 = new Item("7290011051396", true, "שוופס אפרסק מוגז 1.5ליטר", "יפאורה שותפות מובגלת לשיווק", "IL", "שוופס אפרסק", "ליטרים",1.50, false, false, "ליטר", 6.50, 4.33, true, true);
             Item itm4 = new Item("7290000043012", true, "שוקו שוק עמיד 200 מל", "תנובה", "IL", "שוקו עמיד", "מיליליטרים", 250, false, false, "מל 100", 4.3, 1.72, true, true);

            buildTable.AddItem(itm1);
            buildTable.AddItem(itm2);
            buildTable.AddItem(itm3);
            buildTable.AddItem(itm4);
        }

        public static void AddItem(Item itm)
        {
            conn.Insert(itm);
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