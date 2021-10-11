using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRESTController.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Itemquality { get; set; }
        public int Quantity { get; set; }

        public Item(string name, int itemquality, int quantity)
        {
            Name = name;
            Itemquality = itemquality;
            Quantity = quantity;
        }
        public Item()
        {
        }

        public override string ToString()
        {
            return $"ID: {Id} | Name: {Name} | Item Quality: {Itemquality} | Quantity: {Quantity}";
        }
    }
}
