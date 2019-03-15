using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping_list.DataLayer
{
    public class ItemLocation
    {
        //Item table fields
        public int ItemId { get; set; }
        public Item Item { get; set; }

        //Location table fields
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
