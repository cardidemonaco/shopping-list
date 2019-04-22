using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using shopping_list.DataLayer;

namespace shopping_list.WebApp.Pages.Manage.Initiatives
{
    public class IndexModel : PageModel
    {
        private Shopping_listDataContext _context = new Shopping_listDataContext();

        public IndexModel()
        {
  
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Initiative> Initiatives { get; set; } //Object that has all the data

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "InitiativeName_desc" : "";
            
            if (searchString != null)
                pageIndex = 1;
            else
                searchString = currentFilter;

            CurrentFilter = searchString;

            IQueryable<Initiative> initiatives = _context.Initiatives;

            if (!String.IsNullOrEmpty(searchString))
            {
                initiatives = initiatives.Where(x => x.InitiativeName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "InitiativeName_desc":
                    initiatives = initiatives.OrderByDescending(x => x.InitiativeName);
                    break;
                default:
                    initiatives = initiatives.OrderBy(x => x.InitiativeName);
                    break;
            }

            int pageSize = 5; //Set page size
            Initiatives = await PaginatedList<Initiative>.CreateAsync(
                initiatives.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}