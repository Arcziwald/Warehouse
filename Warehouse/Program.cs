using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Warehouse
{
    public class Program
    {
        //Stała
        public const string FILE_NAME = @"C:\WarehouseFiles\ImportFile.xlsx";
        static void Main(string[] args)
        {

            //Podzielić solucję na projekty
            //Dodać interfejsy dla serwisów
            //Dodać bazowy serwis i bazowy model

            var genericItemService = new GenericService<Item>();

            Item itemForGeneric = new Item(1, "Apple");
            Item item2ForGeneric = new Item(2, "Strawberry");
            genericItemService.Add(itemForGeneric);
            genericItemService.Add(item2ForGeneric);

            var items = genericItemService.GetAll();

            NewMethod(genericItemService,
                        item2ForGeneric);
            
            var genericActionService = new GenericService<MenuAction>();
            MenuAction menuAction = new MenuAction(1);
            genericActionService.Add(menuAction);

            MenuActionService actionService = new MenuActionService();
            ItemService itemService = new ItemService();
            actionService = Initialize(actionService);

            Console.WriteLine("Welcome to warehouse app!");
            while (true)
            {
                Console.WriteLine("Please let me know what you want to do:");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                var operation = Console.ReadKey();

                switch (operation.KeyChar)
                {
                    case '1':
                        var keyInfo = itemService.AddNewItemView(actionService);

                        // Użytkownik już podaje nazwę przedmiotu w metodzie AddNewItem, więc tutaj tworzymy tylko nowy obiekt Item
                        Console.WriteLine("Please enter the ID for the new item:");
                        if (!int.TryParse(Console.ReadLine(), out int newItemId))
                        {
                            Console.WriteLine("Invalid input for ID. Using default ID 0.");
                            newItemId = 0; // Przykładowe ID, użyj domyślnego lub generuj unikalne ID.
                        }

                        var newItem = new Item(newItemId, ""); // Nazwa zostanie wprowadzona w metodzie AddNewItem

                        // Wywołanie metody AddNewItem z odpowiednimi argumentami
                        itemService.AddNewItem(keyInfo.KeyChar, newItemId, newItem);

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
                        var typeId = itemService.ItemTypeSelectionView();
                        itemService.ItemsByTypeIdView(typeId);
                        break;
                    default:
                        Console.WriteLine("Action you entered does not exist");
                        break;
                }


            }
        }
        static void NewMethod(GenericService<Item> genericItemService, Item item2ForGeneric)
        {
           NewMethod1(genericItemService, item2ForGeneric);
        }

        private static void NewMethod1(GenericService<Item> genericItemService, Item item2ForGeneric)
        {
            genericItemService.Remove(item2ForGeneric);
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add item", "Main");
            actionService.AddNewAction(2, "Remove item", "Main");
            actionService.AddNewAction(3, "Show details", "Main");
            actionService.AddNewAction(4, "List of Items", "Main");

            actionService.AddNewAction(1, "Clothing", "AddNewItemMenu");
            actionService.AddNewAction(2, "Electronics", "AddNewItemMenu");
            actionService.AddNewAction(3, "Grocery", "AddNewItemMenu");
            return actionService;
        }
    }
}