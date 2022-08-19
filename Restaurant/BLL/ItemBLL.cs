using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
namespace BLL
{
    public class ItemBLL
    {
        ItemDAL ItemDAL = new ItemDAL();

        public bool AddItem(Item item)
        {
            int newItemId = ItemDAL.GetMaxItemId();
            newItemId++;
            item.ItemId = newItemId;
            return ItemDAL.SaveItem(item);
        }

        public bool RemoveItem(int ItemId)
        {
            return ItemDAL.DeleteItem(ItemId);
        }

        public bool EditItem(Item item)
        {
            return ItemDAL.UpdateItem(item);
        }

        public Item GetItemById(int ItemId)
        {
            return ItemDAL.GetItem(ItemId);
        }

        public List<Item> GetAllItem()
        {
            return ItemDAL.GetItems();
        }
    }
}
