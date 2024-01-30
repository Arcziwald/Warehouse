using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.App.Common;
using Warehouse.Domain;
using Warehouse.Domain.Entity;

namespace Warehouse.App.Concrete
{
    public class ItemService : BaseService<Item>
    {
        //public void ItemsByTypeIdView(int typeId)
        //{
        //    List<Item> toShow = new List<Item>();
        //    foreach(var item in Items)
        //    {
        //        if (item.TypeId == typeId)
        //        {
        //            toShow.Add(item);
        //        }
        //    }

        //    Console.WriteLine(toShow.ToStringTable(new[] { "Id", "Name" }, a => a.Id, a => a.Name));
        //}

        //public int ItemTypeSelectionView()
        //{
        //    Console.WriteLine("Please enter Type Id for item type you want to show:");
        //    var itemId = Console.ReadKey();
        //    int id;
        //    Int32.TryParse(itemId.KeyChar.ToString(), out id);

        //    return id;
        //}

        //public void ItemDetailView(int detailId)
        //{
        //    Item productToShow = new Item(1, "");
        //    foreach (var item in Items)
        //    {
        //        if (item.Id == detailId)
        //        {
        //            productToShow = item;
        //            break;
        //        }
        //    }

        //    Console.WriteLine($"Item id: {productToShow.Id}");
        //    Console.WriteLine($"Item name: {productToShow.Name}");
        //    Console.WriteLine($"Item type id: {productToShow.TypeId}");
        //}

        //public int ItemDetailSelectionView()
        //{
        //    Console.WriteLine("Please enter id for item you want to show:");
        //    var itemId = Console.ReadKey();
        //    int id;
        //    Int32.TryParse(itemId.KeyChar.ToString(), out id);

        //    return id;
        //}
    }
}