using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using shopping_list.DataLayer;

namespace shopping_list.WebApp.Pages.Manage.Brand
{
    public class EditModel : PageModel
    {
        private Shopping_listDataContext _sl = new Shopping_listDataContext();

        [BindProperty]
        public DataLayer.Brand Brand { get; set; }

        [ViewData]
        public string Message { get; set; }

        [ViewData]
        public bool Success { get; set; }

        public IQueryable<Item> GetItems()
        {
            return _sl.Items;
        }

        public IQueryable<Item> GetItems(int BrandID)
        {
            return _sl.Items.Join(_sl.ItemBrand, i => i.ItemId, ib => ib.ItemId, (i, ib) => new { i, ib })
                                 .Where(x => x.ib.BrandId == BrandID)
                                 .Select(x => x.i);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Brand = await _sl.Brand.FindAsync(id);

            if (Brand == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, string[] Items)
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                var brandToUpdate = await _sl.Brand.FindAsync(id);

                brandToUpdate.BrandName = Brand.BrandName;
                brandToUpdate.BrandNotes = Brand.BrandNotes;
                brandToUpdate.BrandWebsite = Brand.BrandWebsite;

                _sl.Brand.Update(brandToUpdate); //The rest of the new values are automatically bound

                //Delete all items first, and then just below add them again...
                _sl.ItemBrand.RemoveRange(_sl.ItemBrand.Where(x => x.BrandId == brandToUpdate.BrandId));

                //Save each Good or Service the Brand offers...
                foreach (string item in Items)
                {
                    //Check first if the item exists, and if not add, it...
                    _sl.ItemBrand.Add(new ItemBrand { BrandId = brandToUpdate.BrandId, ItemId = Convert.ToInt32(item) });
                }

                //Persist to database
                await _sl.SaveChangesAsync();

                Message = "Good or Service update successful"; //Alert the user
                Success = true;
            }
            catch
            {
                Message = "Good or Service update not successful"; //Alert the user
                Success = false;
            }

            return RedirectToPage("./Index");
        }
    }
}
