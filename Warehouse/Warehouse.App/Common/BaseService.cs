using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.App.Abstract;
using Warehouse.Domain.Common;

namespace Warehouse.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        public BaseService()
        {
            Items = new List<T>();
        }

        public int GetLastId()
        {
            if (Items.Any())
            {
                return Items.Max(p => p.Id);
            }
            return 0;
        }

        public int AddItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }

        public List<T> GetAllItems()
        {
            return Items;
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }

        public int UpdateItem(T item)
        {
            var entity = Items.FirstOrDefault(p => p.Id == item.Id);
            if (entity != null)
            {
                // Zaktualizuj właściwości encji
                // Na przykład: entity.Name = item.Name;
                // Dalsze aktualizacje właściwości...
            }
            return item.Id; // Zwróć ID przekazanego elementu, nawet jeśli nie znajduje się on w liście
        }

        public T GetItemById(int id)
        {
            return Items.FirstOrDefault(p => p.Id == id) ?? default!;
        }
    }
}