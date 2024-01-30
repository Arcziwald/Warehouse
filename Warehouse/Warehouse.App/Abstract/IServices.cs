using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.App.Abstract
{
    public interface IService<T>
    {
        List<T> Items { get; set; }

        List<T> GetAllItems();
        int GetLastId();
        T GetItemById(int id);
        int AddItem(T item);
        int UpdateItem(T item);
        void RemoveItem(T item);
    }
}