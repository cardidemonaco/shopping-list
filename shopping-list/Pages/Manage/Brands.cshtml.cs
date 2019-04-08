using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using shopping_list.DataLayer;

namespace shopping_list.WebApp.Pages.Manage
{
    public class BrandsModel : PageModel
    {
        private Shopping_listDataContext _sl = new Shopping_listDataContext();

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

        public void OnPostInsert(Brand b)
        {
            _sl.Brand.Add(new Brand { BrandName = b.BrandName, BrandNotes = b.BrandNotes, BrandWebsite = b.BrandWebsite });
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
    }
}