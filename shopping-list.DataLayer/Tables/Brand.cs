using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping_list.DataLayer
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int BrandId { get; set; }
        [Required]
        public string BrandName { get; set; }
        public string BrandWebsite { get; set; }
        public string BrandNotes { get; set; }
    }
}
