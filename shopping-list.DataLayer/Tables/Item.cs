using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace shopping_list.DataLayer
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemBrand { get; set; }
    }
}
