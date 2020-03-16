using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class Item
    {
        public string name;
        public decimal price;
        public int quantityToVend;

        public Item(string itemName, decimal itemPrice)
        {
            name = itemName;
            price = itemPrice;
        }
    }
}
