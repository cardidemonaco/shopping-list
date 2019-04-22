using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using shopping_list.DataLayer;

namespace shopping_list.WebApp.Pages.Manage.Brands
{
    public class IndexModel : PageModel
    {
        private Shopping_listDataContext _context = new Shopping_listDataContext();

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        [TempData]
        public string Message { get; set; }

        [TempData]
        public bool Success { get; set; }

        public PaginatedList<DataLayer.Brand> Brands { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "BrandName_desc" : "";

            if (searchString != null)
                pageIndex = 1;
            else
                searchString = currentFilter;

            CurrentFilter = searchString;

            IQueryable<DataLayer.Brand> brands = _context.Brand;

            if (!String.IsNullOrEmpty(searchString))
            {
                brands = brands.Where(x => x.BrandName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "BrandName_desc":
                    brands = brands.OrderByDescending(x => x.BrandName);
                    break;
                default:
                    brands = brands.OrderBy(x => x.BrandName);
                    break;
            }

            int pageSize = 5; //Set page size
            Brands = await PaginatedList<DataLayer.Brand>.CreateAsync(
                brands.AsNoTracking(), pageIndex ?? 1, pageSize);
        }

        public IQueryable<Item> GetItems(int BrandID)
        {
            return _context.Items.Join(_context.ItemBrand, i => i.ItemId, ib => ib.ItemId, (i, ib) => new { i, ib })
                                 .Where(x => x.ib.BrandId == BrandID)
                                 .Select(x => x.i);
        }

        public Item GetItem(int ItemId)
        {
            return _context.Items.Where(x => x.ItemId == ItemId).SingleOrDefault();
        }
    }
}