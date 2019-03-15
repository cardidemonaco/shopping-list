using System;
using System.Collections.Generic;
using System.Text;

namespace shopping_list.DataLayer
{
    public class ItemCategory
    {
        //Item table fields
        public int ItemID { get; set; }
        public Item Item { get; set; }

        //Category table fields
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
