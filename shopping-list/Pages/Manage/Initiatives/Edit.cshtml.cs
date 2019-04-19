using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using shopping_list.DataLayer;

namespace shopping_list.WebApp.Pages.Manage.Initiatives
{
    public class EditModel : PageModel
    {
        private Shopping_listDataContext _context = new Shopping_listDataContext();

        [BindProperty]
        public Initiative Initiative { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Initiative = await _context.Initiatives.FindAsync(id);

            if (Initiative == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
                return Page();

            var initiativeToUpdate = await _context.Initiatives.FindAsync(id);

            initiativeToUpdate.InitiativeName = Initiative.InitiativeName;
            initiativeToUpdate.InitiativeDescription = Initiative.InitiativeDescription;

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}