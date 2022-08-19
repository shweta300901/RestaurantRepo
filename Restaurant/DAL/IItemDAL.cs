using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
namespace DAL
{
    public interface IItemDAL<Item>
    {
        bool SaveItem(Item item);

        bool DeleteItem(int ItemId);

        bool UpdateItem(Item item);

        Item GetItem(int ItemId);

        List<Item> GetItems();

        int GetMaxItemId();
    }
}
