using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using shopping_list.DataLayer;

namespace shopping_list.WebApp.Pages.Manage
{
    public class ItemsModel : PageModel
    {
        private Shopping_listDataContext _sl = new Shopping_listDataContext();

        public IQueryable<Item> GetItems()
        {
            return _sl.Items;
        }

        public void OnGet()
        {

        }

        public void OnPostInsert(Item item)
        {
            _sl.Items.Add(new Item { ItemName = item.ItemName, ItemDescription = item.ItemDescription });
            _sl.SaveChanges();
        }

        public void OnPostUpdate(Item item)
        {
            _sl.Items.Update(item);
            _sl.SaveChanges();
        }

        public void OnPostDelete(int id)
        {
            var item = _sl.Items.Find(id);
            _sl.Items.Remove(item);
            _sl.SaveChanges();
        }
    }
}
