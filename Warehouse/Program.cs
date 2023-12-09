using System;

namespace Warehouse {
    class Program
    {

        // stała
        const string FILE_NAME = "C:\\WarehouseFiles\\ImportFile.xlsx";

        static void Main(string[] args)
        {
            Console.WriteLine("Wlcome to warehouse app!");
            Console.WriteLine("Please let me know what you want to do:");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Check Item");
            Console.WriteLine("Press 1, 2 or 3...");

            string choice = Console.ReadLine();

            Console.WriteLine($"You have chosen option number: {choice}");

            // Zmienna
            int chosenOption = 0;

            Int32.TryParse(choice, out chosenOption );

            Console.WriteLine("Please choose another option...");

            choice = Console.ReadLine();

            Int32.TryParse(choice, out chosenOption);
        }
    }

}