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
using ProntoV2;

namespace ProntoV2
{
    class Purchase
    {
        private List<ItemsProdAndAmount> items = new List<ItemsProdAndAmount>();

        public List<ItemsProdAndAmount> GetItems()
        {
            return items;
        }

        public void AddItem(ItemsProdAndAmount ipaa)
        {
            foreach (var item in items)
            {
                if (item.Key.Equals(ipaa.Key))
                {
                    item.Amount += ipaa.Amount;
                    return;
                }
            }
            items.Add(ipaa);
        }

        public bool RemoveItem(Item p)
        {
            foreach (var item in items)
            {
                if (item.Key.Equals(p))
                    if (item.Amount > 1)
                    {
                        item.Amount--;
                        return true;
                    }
                    else if (item.Amount == 1)
                    {
                        items.Remove(item);
                        return true;
                    }
                    else
                        return false;
            }
            return false;
        }




        public int TotalItemsPrice()
        {
            int count = 0;
            foreach (var item in items)
            {
               // count += item.Key.Price * item.Amount; todo
            }
            return count;
        }

        private int shopID;

        public int ShopID
        {
            get { return shopID; }
            set { shopID = value; }
        }


    }
}