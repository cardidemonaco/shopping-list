using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shopping_list.DataLayer.Controllers
{
    public class ItemController
    {
        private Shopping_listDataContext _sl = new Shopping_listDataContext();

        public IQueryable<Item> GetItems()
        {
            return _sl.Items;
        }
    }
}
