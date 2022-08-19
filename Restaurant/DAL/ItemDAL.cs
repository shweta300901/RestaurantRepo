using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
namespace DAL
{
    public class ItemDAL : IItemDAL<Item>
    {
        public bool SaveItem(Item item)
        {
            try
            {
                using (RestaurantDBEntities1 dbContext = new RestaurantDBEntities1())
                {
                    dbContext.Items.Add(item);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteItem(int ItemId)
        {
            try
            {
                using (RestaurantDBEntities1 dbContext = new RestaurantDBEntities1())
                {
                    var itemToDelete = dbContext.Items.Where(items => items.ItemId == ItemId).FirstOrDefault();
                    dbContext.Items.Remove(itemToDelete);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateItem(Item item)
        {
            try
            {
                using (RestaurantDBEntities1 dbContext = new RestaurantDBEntities1())
                {
                    var existingItem = dbContext.Items.Where(items => items.ItemId == item.ItemId).FirstOrDefault();
                    existingItem.ItemId = item.ItemId;
                    existingItem.ItemName = item.ItemName;
                    existingItem.ItemPrice = item.ItemPrice;
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Item GetItem(int ItemId)
        {
            try
            {
                using (RestaurantDBEntities1 dbContext = new RestaurantDBEntities1())
                {
                    var itemById = dbContext.Items.Where(items => items.ItemId == ItemId).FirstOrDefault();
                    return itemById;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Item> GetItems()
        {
            try
            {
                using (RestaurantDBEntities1 dbContext = new RestaurantDBEntities1())
                {
                    var allItem = dbContext.Items.ToList();
                    return allItem;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int GetMaxItemId()
        {
            try
            {
                using (RestaurantDBEntities1 dbContext = new RestaurantDBEntities1())
                {
                    var maxItemId = dbContext.Items.Max(items => items.ItemId);
                    return maxItemId;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
