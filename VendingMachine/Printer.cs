using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class Printer
    {
        public static string howToSelect = "Tast venligst nummeret på den vare du ønsker: \n" ;
        public static string header = "\nNummer |    Pris   |      Vare\n";
        public static string purchasedItems = "\nNavn\n";
        public static int length = Vendor.machine.Length;

        public static void printHeader()
        {
            for (int i = 0; i < length; i++)
            {
                header += $"   {i + 1}   | {Vendor.machine[i].price} DKK | {Vendor.machine[i].name}\n";
            }
            Console.WriteLine(howToSelect + header);
            header = "";
        }
        public static void vendRequestedItems()
        {
            for (int i = 0; i < length; i++)
            {
                if (Vendor.machine[i].quantityToVend > 0)
                {
                    purchasedItems += $"{Vendor.machine[i].name} | {Vendor.machine[i].quantityToVend}" + Environment.NewLine;
                }
            }
            Console.WriteLine(purchasedItems);
        }
    }
}
