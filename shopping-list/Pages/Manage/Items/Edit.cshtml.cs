using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using shopping_list.DataLayer;

namespace shopping_list.WebApp.Pages.Manage
{
    public class ItemEditModel : PageModel
    {
        private Shopping_listDataContext _sl = new Shopping_listDataContext();

        [BindProperty]
        public Item Item { get; set; }

        [TempData]
        public string Message { get; set; }

        [TempData]
        public bool Success { get; set; }

        public void OnPostEdit(int id)
        {
            Item = _sl.Items.Find(id);
        }

        public IActionResult OnPostUpdate(int id)
        {
            try
            {
                Item.ItemId = id; //Set the primary key
                _sl.Items.Update(Item); //The rest of the new values are automatically bound
                _sl.SaveChanges(); //Update the database

                Message = "Good or Service update successful"; //Alert the user
                Success = true;
            }
            catch
            {
                Message = "Good or Service update not successful"; //Alert the user
                Success = false;
            }

            return RedirectToPage("./Items");
        }
    }
}