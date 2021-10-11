using System.Collections.Generic;
using FirstRESTController.Models;

namespace FirstRESTController.Managers
{
    public interface IItemsManager
    {
        List<Item> GetAll(string substring);
        Item GetById(int id);
        Item Add(Item newItem);
        Item Delete(int id);
        Item Update(int id, Item updates);
        void DeleteAll();
    }
}