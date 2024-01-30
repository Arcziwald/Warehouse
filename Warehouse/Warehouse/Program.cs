using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Warehouse.Helpers;
using Warehouse.App.Abstract;
using Warehouse.App.Common;
using Warehouse.App.Concrete;
using Warehouse.App.Managers;
using Warehouse.Domain.Entity;

namespace Warehouse
{
    public class Program
    {
        //Stała
        public const string FILE_NAME = @"C:\WarehouseFiles\ImportFile.xlsx";
        static void Main(string[] args)
        {
            

            MenuActionService actionService = new MenuActionService();
            ItemService itemService = new ItemService();
            ItemManager itemManger = new ItemManager(actionService, itemService);

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
                        var newId = itemManger.AddNewItem();
                        break;

                    case '2':
                        //var removeId = itemService.RemoveItemView();
                        //itemService.RemoveItem(removeId);
                        break;

                    case '3':
                        //var detailId = itemService.ItemDetailSelectionView();
                        //itemService.ItemDetailView(detailId);
                        break;

                    case '4':
                        //var typeId = itemService.ItemTypeSelectionView();
                        //itemService.ItemsByTypeIdView(typeId);
                        break;

                    default:
                        Console.WriteLine("Action you entered does not exist");
                        break;
                }
            }
        }
    }
}