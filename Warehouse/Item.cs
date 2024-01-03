using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    public class AuditableModel
    {
        public int CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }

    public interface IItem
    {
        int Id { get; }
        string Name { get; set; }
        int TypeId { get; set; }
        int Quantity { get; set; }
        void ChangeQuantity(int quantity);
        void ShowDetails();
    }

    public class Item : IItem
    {
        public int Id { get; }

        public string Name { get; set; }
        public int TypeId { get; set; }
        public int Quantity { get; set; }
        protected bool isLowInWarehouse;

        public Item(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public virtual void ChangeQuantity(int quantity)
        {
            Quantity = quantity;
            if (quantity < 50)
            {
                isLowInWarehouse = true;
            }
        }

        public virtual void ShowDetails()
        {
            Console.WriteLine($"Item id is: {Id}");
        }
    }
    public class GroceryItem : Item
    {
        public DateTime ExpieryDate { get; set; }
        public GroceryItem(int id, string name) : base(id, name)
        {

        }

        public override void ShowDetails()
        {
            //Wyświetlił się obrazek cukinii
            base.ShowDetails();

            Console.WriteLine($"Items Expiery Date is: {ExpieryDate.ToShortDateString()}");
        }

        public override void ChangeQuantity(int quantity)
        {
            Quantity = quantity;
            if (quantity < 50)
            {
                isLowInWarehouse = true;
            }
        }
    }

    public class ClothingItem : Item
    {

        public ClothingItem(int id, string name) : base(id, name)
        {

        }

        public override void ChangeQuantity(int quantity)
        {
            Quantity = quantity;
            if (quantity < 50)
            {
                isLowInWarehouse = true;
            }
        }

        public new void ShowDetails()
        {
            base.ShowDetails();
            //Wyświetlił się obrazek koszula
        }
    }
}