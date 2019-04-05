using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
                _sl.Items.Add(new Item { ItemName = item.ItemName, ItemDescription = item.ItemDescription });
                _sl.SaveChanges();
            }
        }

        public void OnPostUpdate(Item item)
        {
            using (Shopping_listDataContext _sl = new Shopping_listDataContext())
            {
                _sl.Items.Update(item);
                _sl.SaveChanges();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(string ItemId)
        {
            using (Shopping_listDataContext _sl = new Shopping_listDataContext())
            {
                var item = await _sl.Items.FindAsync(ItemId);
                _sl.Items.Remove(item);
                _sl.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
