using System.ComponentModel.DataAnnotations;

namespace shopping_list.DataLayer
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
