using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using shopping_list.DataLayer;
using shopping_list.DataLayer.Controllers;

namespace shopping_list.WebApp.Pages.Manage
{
    public class ItemsModel : PageModel
    {
        //private Shopping_listDataContext _sl = new Shopping_listDataContext();
        //public ItemController _ic = new ItemController();


        public void OnGet()
        {
            //var itemBrands = _sl.Items.Join(_sl.ItemBrand,
            //                        i => i.ItemId,
            //                        ib => ib.ItemId,
            //                        (i, ib) => new { i, ib });

            //foreach (var item in itemBrands)
            //{
                
            //}
            
        }
    }
}