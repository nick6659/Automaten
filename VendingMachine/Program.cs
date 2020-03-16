using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10;)
            {
                var vendingMachineRun = new Controller();
                vendingMachineRun.selectYourItem();
                vendingMachineRun.mainMenu();
                Console.ReadLine();
            }

        }
    }
}
