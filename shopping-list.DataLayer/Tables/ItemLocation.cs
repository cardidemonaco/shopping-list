using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping_list.DataLayer
{
    public class ItemLocation
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
