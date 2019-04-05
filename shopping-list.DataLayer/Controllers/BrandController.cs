using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace shopping_list.DataLayer.Controllers
{
    public class BrandController : PageModel
    {
        public static IQueryable<Brand> GetBrands()
        {
            Shopping_listDataContext _sl = new Shopping_listDataContext();
            return _sl.Brand;
        }

        public void OnPostInsert(Brand brand)
        {
            using (Shopping_listDataContext _sl = new Shopping_listDataContext())
            {
                _sl.Brand.Add(new Brand { BrandName = brand.BrandName,
                                            BrandNotes = brand.BrandNotes,
                                            BrandWebsite = brand.BrandWebsite });
                _sl.SaveChanges();
            }
        }

        public void OnPostUpdate(Brand brand)
        {
            using (Shopping_listDataContext _sl = new Shopping_listDataContext())
            {
                _sl.Brand.Update(brand);
                _sl.SaveChanges();
            }
        }

        public void OnPostDelete(Brand brand)
        {
            using (Shopping_listDataContext _sl = new Shopping_listDataContext())
            {
                _sl.Brand.Remove(brand);
                _sl.SaveChanges();
            }
        }
    }
}
