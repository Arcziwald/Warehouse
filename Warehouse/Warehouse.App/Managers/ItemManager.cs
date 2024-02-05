using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.App.Abstract;
using Warehouse.App.Concrete;
using Warehouse.Domain.Entity;

namespace Warehouse.App.Managers
{
    public class ItemManager
    {
        private readonly MenuActionService _actionService;
        private IService<Item> _itemService;
        public ItemManager(MenuActionService actionService, IService<Item> itemService)
        {
            _itemService = itemService;
            _actionService = actionService;
        }
        public int AddNewItem()
        {
            var addNewItemMenu = _actionService.GetMenuActionsByMenuName("AddNewItemMenu");
            Console.WriteLine("Please select item type:");
            foreach (var action in addNewItemMenu)
            {
                Console.WriteLine($"{action.Id}. {action.Name}");
            }

            if (!int.TryParse(Console.ReadLine(), out int typeId))
            {
                Console.WriteLine("Invalid input for type. Please enter a valid number.");
                return -1; // lub inna logika obsługi błędów
            }

            Console.WriteLine("Please insert name for item:");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Item name cannot be empty.");
                return -1; // lub inna logika obsługi błędów
            }

            var lastId = _itemService.GetLastId();
            Item item = new Item(lastId + 1, name, typeId);
            _itemService.AddItem(item);
            return item.Id;
        }

        public Item GetItemById(int id)
        {
            var item = _itemService.GetItemById(id);
            return item;
        }
    }
}