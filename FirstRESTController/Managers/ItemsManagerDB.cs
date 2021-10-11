using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRESTController.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace FirstRESTController.Managers
{
    public class ItemsManagerDB:IItemsManager
    {
        private ItemContext _context;

        public ItemsManagerDB(ItemContext context)
        {
            _context = context;
        }

        public List<Item> GetAll(string substring)
        {
            if (string.IsNullOrWhiteSpace(substring))
            {
                return _context.Items.ToList();
            }

            IEnumerable<Item> items = from item in _context.Items
                where item.Name.ToLower().Contains(substring.ToLower())
                select item;
            return items.ToList();
        }

        public Item GetById(int id)
        {
            return _context.Items.Find(id);
        }

        public Item Add(Item newItem)
        {
            newItem.Id = 0;
            _context.Items.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public Item Delete(int id)
        {
            Item item = _context.Items.Remove(GetById(id)).Entity;
            _context.SaveChanges();
            return item;
        }

        public Item Update(int id, Item updates)
        {
            Item item = GetById(id);
            item.Name = updates.Name;
            item.Itemquality = updates.Itemquality;
            item.Quantity = updates.Quantity;

            _context.Items.Update(item);
            _context.SaveChanges();
            return item;
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
    }
}
