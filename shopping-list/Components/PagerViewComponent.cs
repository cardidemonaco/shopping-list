using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DotNetPaging;

namespace shopping_list.WebApp.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            result.LinkTemplate = Url.Action(RouteData.Values["page"].ToString(), new { page = "{0}" });

            return View("Default", result);
        }
    }
}
