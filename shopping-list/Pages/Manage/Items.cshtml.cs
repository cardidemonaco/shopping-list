using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using shopping_list.DataLayer.Controllers;

namespace shopping_list.WebApp.Pages.Manage
{
    public class ItemsModel : PageModel
    {
        public ItemController _ic = new ItemController();

        public void OnGet()
        {

        }
    }
}