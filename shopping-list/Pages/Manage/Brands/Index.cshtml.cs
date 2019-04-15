using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using shopping_list.DataLayer;
using PagedList;
using DotNetPaging;

namespace shopping_list.WebApp.Pages.Manage
{
    public class BrandsModel : PageModel
    {
        private Shopping_listDataContext _sl = new Shopping_listDataContext();

        public PagedResult<Brand> _brandsPaged;

        [TempData]
        public string Message { get; set; }

        [TempData]
        public bool Success { get; set; }

        public PagedResult<Brand> GetBrands(int page = 1)
        {
            _brandsPaged = _sl.Brand.OrderBy(x => x.BrandName).GetPaged(page, 10);

            return _brandsPaged;
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

        public void OnPostInsert(Brand b, string[] Items)
        {
            //Save new Brand...
            Brand newBrand = new Brand { BrandName = b.BrandName, BrandNotes = b.BrandNotes, BrandWebsite = b.BrandWebsite };
            _sl.Brand.Add(newBrand);
            _sl.SaveChanges(); //Need to save to the database now so we get the ID

            //Save each Good or Service the Brand offers...
            foreach (string item in Items)
            {
                _sl.ItemBrand.Add(new ItemBrand { BrandId = newBrand.BrandId, ItemId = Convert.ToInt32(item) });
            }

            //Persist to database
            _sl.SaveChanges(); 
        }

        public void OnPostUpdate(Brand b)
        {
            _sl.Brand.Update(b);
            _sl.SaveChanges();
        }

        public void OnPostDelete(int id)
        {
            var b = _sl.Brand.Find(id);
            _sl.Brand.Remove(b);
            _sl.SaveChanges();
        }

        public void OnPostBrandDetails(PagedResult<Brand> brandsPaged)
        {
            _brandsPaged = brandsPaged;
        }
    }
}