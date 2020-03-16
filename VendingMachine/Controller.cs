using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine;

namespace VendingMachine
{
    public class Controller
    {
        PricingSystem moneyMachine = new PricingSystem();
        Printer printer = new Printer();
        static Item selectedItem;
        private const decimal fiveCoins = 5.00m;
        private const decimal tenCoins = 10.00m;
        private const decimal twentyCoins = 20.00m;
        private int userChoice = 0;

        //program entry point, starts item selection process
        public void selectYourItem()
        {
            Printer.printHeader();
            if (handleUserInput())
            {
                checkSelectionInArray();
            }
            else
            {
                Console.WriteLine("\nFejl! Du har ikke skrevet et gyldigt nummer!\n");
                selectYourItem();
            }
        }

        //this method loops to allow the user to choose another item, exit the program or start paying
        public void mainMenu()
        {
            while (moneyMachine.transactionComplete == false)
            {
                Console.WriteLine(Environment.NewLine +
                "\nTryk '1' for at betale, tryk '2' for at vælge mere, eller tryk '3' for at annullere\n");
                if (handleUserInput())
                {
                    selectionProcessing(userChoice);
                }
                else
                {
                    Console.WriteLine("\nFejl! Du har ikke skrevet et gyldigt nummer!\n");
                }
            }
        }

        //processes main menu selection
        private void selectionProcessing(int selection)
        {
            switch (selection)
            {
                case 1:
                    startPaymentProcess();
                    break;
                case 2:
                    selectYourItem();
                    break;
                case 3:
                    Console.WriteLine("\nVi ses!\n");
                    moneyMachine.transactionComplete = true;
                    break;
                default:
                    Console.WriteLine("\nFejl! Du har ikke skrevet et gyldigt nummer!\n");
                    break;
            }
        }

        //starts the payment loop, can be extended for different coins
        private void startPaymentProcess()
        {
            while (moneyMachine.transactionComplete == false)
            {
                Console.WriteLine("\nTast 1 for at indsætte 5 DKK || Tast 2 for at indsætte 10 DKK || Tast 3 for at indsætte 20 DKK\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine($"\nIndsat beløb ---> {fiveCoins} DKK\n");
                        moneyMachine.insertCoins(fiveCoins, moneyMachine.totalAmount);
                        break;
                    case "2":
                        Console.WriteLine($"\nIndsat beløb ---> {tenCoins} DKK\n");
                        moneyMachine.insertCoins(tenCoins, moneyMachine.totalAmount);
                        break;
                    case "3":
                        Console.WriteLine($"\nIndsat beløb ---> {twentyCoins} DKK\n");
                        moneyMachine.insertCoins(twentyCoins, moneyMachine.totalAmount);
                        break;

                    default:
                        Console.WriteLine("\nFejl! Du har ikke indkastet et gyldigt beløb!\n");
                        break;
                }
            }
        }

        //checks that the item selected exists in the vending machine array
        private void checkSelectionInArray()
        {
            if (userChoice - 1 < Vendor.machine.Length && userChoice - 1 >= 0)
            {
                selectedItem = Vendor.machine[userChoice - 1];
                Console.WriteLine($"\nDu har valgt: {selectedItem.name}\n");
                quantityCheck();
            }
            else
            {
                Console.WriteLine("\nNummeret du har tastet findes ikke, prøv venligst igen\n");
                selectYourItem();
            }
        }

        //checks the amount of an item required for purchase
        private void quantityCheck()
        {
            Console.WriteLine($"\nHvor mange {selectedItem.name} vil du købe?\n");
            if (handleUserInput())
            {
                moneyMachine.totalAmount += selectedItem.price * userChoice;
                selectedItem.quantityToVend += userChoice;
                Console.WriteLine(
                $"\nDu har tilføjet {userChoice} {selectedItem.name} ||| Total: {moneyMachine.totalAmount} DKK\n");
            }
            else
            {
                Console.WriteLine("\nUgyldigt antal!\n");
                quantityCheck();
            }
        }

        //reads user input and attempts to convert it to an integer
        private Boolean handleUserInput()
        {
            return Int32.TryParse(Console.ReadLine(), out userChoice);
        }
    }
}
