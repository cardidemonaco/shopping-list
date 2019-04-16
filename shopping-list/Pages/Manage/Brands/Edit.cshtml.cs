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
    public class BrandEditModel : PageModel
    {
        private Shopping_listDataContext _sl = new Shopping_listDataContext();

        [BindProperty]
        public Brand Brand { get; set; }

        [TempData]
        public string Message { get; set; }

        [TempData]
        public bool Success { get; set; }

        [TempData]
        public int CurrentPage { get; set; }

        public IQueryable<Brand> GetBrands()
        {
            return _sl.Brand;
        }

        public IQueryable<Item> GetItems()
        {
            return _sl.Items;
        }

        public IQueryable<ItemBrand> GetItemBrands(int BrandId)
        {
            return _sl.ItemBrand.Where(x => x.BrandId == BrandId);
        }

        public Item GetItem(int ItemId)
        {
            return _sl.Items.Where(x => x.ItemId == ItemId).SingleOrDefault();
        }

        public void OnGet()
        {

        }

        public void OnPostEdit(int id, int thePage)
        {
            SetPage(thePage); //set the current page
            Brand = _sl.Brand.Find(id);
        }

        public void SetPage(int page)
        {
            CurrentPage = page;
        }

        public IActionResult OnPostUpdate(int id, string[] Items, int thePage)
        {
            SetPage(thePage); //set the current page

            try
            {
                Brand.BrandId = id; //Set the primary key
                _sl.Brand.Update(Brand); //The rest of the new values are automatically bound
                _sl.SaveChanges(); //Update the database

                //Delete all items first, and then just below add them again...
                _sl.ItemBrand.RemoveRange(_sl.ItemBrand.Where(x => x.BrandId == Brand.BrandId));

                //Save each Good or Service the Brand offers...
                foreach (string item in Items)
                {
                    //Check first if the item exists, and if not add, it...
                    _sl.ItemBrand.Add(new ItemBrand { BrandId = Brand.BrandId, ItemId = Convert.ToInt32(item) });
                }

                //Persist to database
                _sl.SaveChanges();

                Message = "Good or Service update successful"; //Alert the user
                Success = true;
            }
            catch
            {
                Message = "Good or Service update not successful"; //Alert the user
                Success = false;
            }

            //return RedirectToPage("./Index", "defaultPaged", thePage);
            //return RedirectToAction("defaultPagedBrands");

            RouteData.Values["id"] = thePage; //set current page
            return RedirectToPage("./Index");
        }
    }
}
