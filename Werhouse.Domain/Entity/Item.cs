using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Warehouse.Domain.Common;
using Werhouse.Domain.Common;

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
        }

        public Item(int id, string name, int typeId)
        {
            Name = name;
            TypeId = typeId;
            Id = id;
        }
    }
}