﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using shopping_list.DataLayer;

namespace shopping_list.WebApp.Pages.Manage
{
    public class BrandEditModel : PageModel
    {
        private Shopping_listDataContext _sl = new Shopping_listDataContext();

        [BindProperty]
        public Brand Brand { get; set; }

        [TempData]
        public string Message { get; set; }

        [TempData]
        public bool Success { get; set; }

        public IQueryable<Brand> GetBrands()
        {
            return _sl.Brand;
        }

        public void OnGet()
        {

        }

        public void OnPostEdit(int id)
        {
            Brand = _sl.Brand.Find(id);
        }

        public IActionResult OnPostUpdate(int id)
        {
            try
            {
                Brand.BrandId = id; //Set the primary key
                _sl.Brand.Update(Brand); //The rest of the new values are automatically bound
                _sl.SaveChanges(); //Update the database

                Message = "Good or Service update successful"; //Alert the user
                Success = true;
            }
            catch
            {
                Message = "Good or Service update not successful"; //Alert the user
                Success = false;
            }

            return RedirectToPage("./Brands");
        }
    }
}