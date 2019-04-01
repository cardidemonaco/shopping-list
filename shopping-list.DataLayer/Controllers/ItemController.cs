using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace shopping_list.DataLayer.Controllers
{
    public class ItemController : PageModel 
    {
        public static IQueryable<Item> GetItems()
        {
            Shopping_listDataContext _sl = new Shopping_listDataContext();
            return _sl.Items;
        }

        public void OnPostInsert(Item item)
        {
            using (Shopping_listDataContext _sl = new Shopping_listDataContext())
            {
                _sl.Items.Add(new Item { ItemName = item.ItemName });
                _sl.SaveChanges();
            }
        }
    }
}
