using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class ItemService
    {
        public List<Item> Items { get; set; }
        public ItemService()
        {
            Items = new List<Item>();
        }

        public ConsoleKeyInfo AddNewItemView(MenuActionService actionService)
        {

            var AddNewItemMenu = actionService.GetMenuActionsByMenuName("AddNewItemMenu");
            Console.WriteLine("Please select item type: ");
            for (int i = 0; i < AddNewItemMenu.Count; i++)
            {
                Console.WriteLine($"{AddNewItemMenu[i].Id}. {AddNewItemMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            return operation;
        }

        public int AddNewItem(char itemType)
        {
            int itemTypeId;
            Int32.TryParse(itemType.ToString(), out itemTypeId);
            Item item = new Item();
            item.TypeId = itemTypeId;
            Console.WriteLine("Please enter id for new item: ");
            var id = Console.ReadLine();
            int itemId;
            Int32.TryParse(id, out itemId);
            Console.WriteLine("Please enter name for new item: ");
            var name = Console.ReadLine();

            item.Id = itemId;
            item.Name = name;

            Items.Add(item);
            return itemId;
        }

        public int RemoveItemView()
        {
            Console.WriteLine("Please enter id for item you want to remove: ");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            return id;
        }
        public void RemoveItem(int removeId)
        {
            Item productToRemove = new Item();
            foreach (var item in Items)
            {
                if (item.Id == removeId)
                {
                    productToRemove = item;
                    break;
                }
            }
            Items.Remove(productToRemove);
        }

        public void ItemDetailView(int detailId)
        {
            Item productToShow = new Item();
            foreach (var item in Items)
            {
                if (item.Id == detailId)
                {
                    productToShow = item;
                    break;
                }
            }
            Console.WriteLine($"Item id: {productToShow.Id}");
            Console.WriteLine($"Item name: {productToShow.Name}");
            Console.WriteLine($"Item type id: {productToShow.TypeId}");
        }

        public int ItemDetailSelectionView()
        {
            Console.WriteLine("Please enter id for item you want to show: ");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            return id;
        }
    }
}
