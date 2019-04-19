using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using shopping_list.DataLayer;

namespace shopping_list.WebApp.Pages.Manage.Initiatives
{
    public class CreateModel : PageModel
    {
        private Shopping_listDataContext _context = new Shopping_listDataContext();

        public void OnGet()
        {
            
        }

        [BindProperty]
        public Initiative Initiative { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var emptyInitiative = new Initiative();

            if (await TryUpdateModelAsync<Initiative>(
                emptyInitiative,
                "Initiative",
                x => x.InitiativeName, x => x.InitiativeDescription))
            {
                _context.Initiatives.Add(emptyInitiative);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}