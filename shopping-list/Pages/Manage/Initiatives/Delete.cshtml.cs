using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shopping_list.DataLayer;

namespace shopping_list.WebApp.Pages.Manage.Initiatives
{
    public class DeleteModel : PageModel
    {
        private Shopping_listDataContext _context = new Shopping_listDataContext();

        [BindProperty]
        public Initiative Initiative { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
                return NotFound();

            Initiative = await _context.Initiatives.AsNoTracking().FirstOrDefaultAsync(x => x.InitiativeID == id);

            if (Initiative == null)
                return NotFound();

            if (saveChangesError.GetValueOrDefault())
                ErrorMessage = "Delete failed.";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var Initiative = await _context.Initiatives.AsNoTracking().FirstOrDefaultAsync(x => x.InitiativeID == id);

            if (Initiative == null)
                return NotFound();

            try
            {
                _context.Initiatives.Remove(Initiative);
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