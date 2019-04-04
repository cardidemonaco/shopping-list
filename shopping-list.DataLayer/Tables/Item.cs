using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace shopping_list.DataLayer
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ItemId { get; set; }
        [Required]
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
    }
}
