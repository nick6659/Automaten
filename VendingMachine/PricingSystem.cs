using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine;

namespace VendingMachine
{
    public class PricingSystem
    {
        public decimal balance = 0;
        public decimal change = 0;
        public decimal totalAmount = 0;
        public bool transactionComplete = false;

        public void insertCoins(decimal amount, decimal priceOfItem)
        {
            balance += amount;
            checkPurchace(balance, priceOfItem);
        }

        public void checkPurchace(decimal currentBalance, decimal priceOfItem)
        {
            if (currentBalance >= priceOfItem)
            {
                change = currentBalance - priceOfItem;
                Console.WriteLine($"\n***Tak for dit køb, byttepenge ---> {change} DKK***\n"
                + "\nTag venligst dine varer:-\n");
                Printer.vendRequestedItems();
                transactionComplete = true;
            }
            else
            {
                Console.WriteLine($"\nDu mangler at betale ---> {priceOfItem - balance} DKK. Indkast venligst det resterende\n");
            }
        }
    }
}
