using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using shopping_list.DataLayer;

namespace shopping_list.WebApp.Pages.Manage.Brands
{
    public class DeleteModel : PageModel
    {
        private Shopping_listDataContext _context = new Shopping_listDataContext();

        [BindProperty]
        public DataLayer.Brand Brand { get; set; }

        public string ErrorMessage { get; set; }

        public IQueryable<Item> GetItems(int BrandID)
        {
            return _context.Items.Join(_context.ItemBrand, i => i.ItemId, ib => ib.ItemId, (i, ib) => new { i, ib })
                                 .Where(x => x.ib.BrandId == BrandID)
                                 .Select(x => x.i);
        }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
                return NotFound();

            Brand = await _context.Brand.AsNoTracking().FirstOrDefaultAsync(x => x.BrandId == id);

            if (Brand == null)
                return NotFound();

            if (saveChangesError.GetValueOrDefault())
                ErrorMessage = "Delete failed.";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var Initiative = await _context.Brand.AsNoTracking().FirstOrDefaultAsync(x => x.BrandId == id);

            if (Initiative == null)
                return NotFound();

            try
            {
                _context.Brand.Remove(Brand);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
        }
    }
}