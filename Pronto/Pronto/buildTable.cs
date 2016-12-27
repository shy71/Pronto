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

namespace Pronto
{
    class buildTable
    {
        string folder;
        SQLiteConnection conn;

        buildTable()
        {

            folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(folder, "myAmmazingApp.db"));
            conn.CreateTable<Product>();
            conn.CreateTable<Products>();
        }
        
        
        public static void AddStock(SQLiteConnection db, string symbol,Product p)
        {
            db.Insert(p);
            Console.WriteLine(p.ToString());
        }

        // empty!!!!!!!!!!!!!!!!!!
        public void buildItUp()
        {

        }

        public IEnumerable<Product> GetProduction (string barcode)
        {
            return conn.Table<Product>().Where(p => p.Barcode == barcode);
        }

        public IEnumerable<Product> Search(string query)
        {
            return conn.Table<Product>().Where(p => p.Description.Contains(query));
        }        
            
    }
}