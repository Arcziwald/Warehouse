using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Warehouse.Domain.Common;

namespace Warehouse.Domain.Entity
{
    public class Item : BaseEntity
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Type")]
        public int TypeId { get; set; }
        [XmlElement("Quantity")]
        public int Quantity { get; set; }
        protected bool isLowInWarehouse;

        public Item()
        {
            Name = string.Empty; // Inicjalizacja domyślną pustą wartością
        }
        public Item(int id, string name, int typeId)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Rzucenie wyjątku, jeśli name jest null
            TypeId = typeId;
        }
    }
}