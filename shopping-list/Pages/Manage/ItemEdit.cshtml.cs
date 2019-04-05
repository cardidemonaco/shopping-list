using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using shopping_list.DataLayer;

namespace shopping_list.WebApp.Pages.Manage
{
    public class ItemEditModel : PageModel
    {
        private Shopping_listDataContext _sl = new Shopping_listDataContext();

        public Item Item { get; set; }

        public void OnPost(int id)
        {
            Item = _sl.Items.Find(id);

        }

        public void OnPost()
        {
           

            _sl.Items.Update(Item);
            _sl.SaveChanges();
        }
    }
}