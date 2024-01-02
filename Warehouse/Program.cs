
using System.ComponentModel;

namespace Warehouse {
    class Program
    {

        // stała
        public const string FILE_NAME = @"C:\WarehouseFiles\ImportFile.xlsx";

        static void Main(string[] args)
        {
            //Użytkownik zostanie przywitany +
            //Dostanie możliwość wyboru akcji +
            ///a. Stworzenie nowego przedmiotu +
            ///b. Usunięcie przedmiotu +
            ///c. Sprawdzenie stanu magazynowego
            ///d. Zwrócenie listy przedmiotów o zadanym filtrze (nazwa kategorii)
            ////a1 Najpierw dostanę do wyboru kategorię produktu +
            ////a2 Zostanę poproszony o wprowadzenie wszystkich szczegółów +
            ////b1 Zostanę poproszony o id albo nazwę produktu +
            ////b2 Usunę ten produkt z listy produktów +
            ////c1 Zostanę poproszony o wprowadzenie id produktu
            ////c2 Wyświetlę wszystkie informacje związane z tym produktem
            ////d1 Zostanę poproszony o wprowadzenie nazwy albo id kategorii
            ////d2 Wyświetlę listę produktów

           MenuActionService actionService = new MenuActionService();
           actionService = Initialize(actionService);

           Console.WriteLine("Welcome to warehouse app!!!");
            while (true)
            {
                Console.WriteLine("Please let me know what you want to do:");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                var operation = Console.ReadKey();
                ItemService itemService = new ItemService();
                switch (operation.KeyChar)
                {
                    case '1':
                        var keyInfo = itemService.AddNewItemView(actionService);
                        var id = itemService.AddNewItem(keyInfo.KeyChar);
                        break;
                    case '2':
                        var removeId = itemService.RemoveItemView();
                        itemService.RemoveItem(removeId);
                        break;
                    case '3':
                        var detailId = itemService.ItemDetailSelectionView();
                        itemService.ItemDetailView(detailId);
                        break;
                    case '4':
                        break;
                    default:
                        Console.WriteLine("Action you entered does not exist");
                        break;
                }

            }
           // Console.WriteLine("1. Add Item");
           // Console.WriteLine("2. Remove Item");
           // Console.WriteLine("3. Check Item");
           // Console.WriteLine("Press 1, 2 or 3...");

           // string operation = Console.ReadLine();

            // Console.WriteLine($"You have chosen option number: {operation}");

            // Zmienna
            // int chosenOperation = 0;

            //  Int32.TryParse(operation, out chosenOperation);

            //  Console.WriteLine("Select item category");
            //   Console.WriteLine("1. Grocery");
            //  Console.WriteLine("2. Clothing");
            //  Console.WriteLine("3. Electronics");

            //  string category = Console.ReadLine();

            //   ItemType chosenCategory;

            //Enum.TryParse(category, out chosenCategory);
        }
        private static MenuActionService Initialize(MenuActionService actionService)
            {
                actionService.AddNewAction(1, "Add item", "Main");
                actionService.AddNewAction(2, "Remove item", "Main");
                actionService.AddNewAction(3, "Show details", "Main");
                actionService.AddNewAction(4, "List of item", "Main");

                actionService.AddNewAction(1, "Clothing", "AddNewItemMenu");
                actionService.AddNewAction(2, "Electronics", "AddNewItemMenu");
                actionService.AddNewAction(3, "Grocery", "AddNewItemMenu");
                return actionService;
            }
    }
    

}