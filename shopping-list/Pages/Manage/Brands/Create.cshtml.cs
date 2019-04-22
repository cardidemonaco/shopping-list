using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using shopping_list.DataLayer;

namespace shopping_list.WebApp.Pages.Manage.Brands
{
    public class CreateModel : PageModel
    {
        private Shopping_listDataContext _context = new Shopping_listDataContext();

        public void OnGet()
        {
            
        }

        [BindProperty]
        public DataLayer.Brand Brand { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var emptyInitiative = new DataLayer.Brand();

            if (await TryUpdateModelAsync<DataLayer.Brand>(
                emptyInitiative,
                "Brand",
                x => x.BrandName, x => x.BrandNotes, x => x.BrandWebsite))
            {
                _context.Brand.Add(emptyInitiative);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}