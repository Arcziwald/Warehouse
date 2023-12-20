
using System.ComponentModel;

namespace Warehouse {
    class Program
    {

        // stała
        public const string FILE_NAME = "C:\\WarehouseFiles\\ImportFile.xlsx";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to warehouse app!");
            Console.WriteLine("Please let me know what you want to do:");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Check Item");
            Console.WriteLine("Press 1, 2 or 3...");

            string choice = Console.ReadLine();

            Console.WriteLine($"You have chosen option number: {choice}");

            // Zmienna
            int chosenOption = 0;

            Int32.TryParse(choice, out chosenOption);

            Console.WriteLine("Please choose another option...");

            choice = Console.ReadLine();

            Int32.TryParse(choice, out chosenOption);

            Console.WriteLine("Select item category");
            Console.WriteLine("1. Grocery");
            Console.WriteLine("2. Clothing");
            Console.WriteLine("3. Electronics");

            string category = Console.ReadLine();

            ItemType chosenCategory;

            Enum.TryParse(category, out chosenCategory );

            int a = 5;
            int b = a;

            Console.WriteLine(a); // ma wyświetlić 5
            Console.WriteLine(b); // ma wyświetlić 5

            b = 50;

            Console.WriteLine(a); // ma wyświetlić 5
            Console.WriteLine(b); // ma wyświetlić 50

            Item item = new Item() { Id = 1, Name = "Apple" };
            item item2 = item;

            Console.WriteLine(item.Name); // ma wyświetlić Apple
            Console.WriteLine(item2.Name); // ma wyświetlić Apple

            item2.Name = "Watermelon";

            Console.WriteLine(item.Name); // ma wyświetlić Apple
            Console.WriteLine(item2.Name); // ma wyświetlić Watermelon
        }
    }

}