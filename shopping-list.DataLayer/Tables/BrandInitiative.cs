using System;
using System.Collections.Generic;
using System.Text;

namespace shopping_list.DataLayer.Tables
{
    public class BrandInitiative
    {
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        public int InitiativeID { get; set; }
        public Initiative Initiative { get; set; }
    }
}
