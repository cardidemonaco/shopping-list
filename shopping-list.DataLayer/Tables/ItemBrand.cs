using System;
using System.Collections.Generic;
using System.Text;

namespace shopping_list.DataLayer
{
    public class ItemBrand
    {
        //Item table fields
        public int ItemId { get; set; }
        public Item Item { get; set; }

        //Brand table fields
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
