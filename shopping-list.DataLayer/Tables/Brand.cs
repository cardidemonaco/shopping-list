using System.Collections.Generic;
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
        [Display(Name = "Name")]
        public string BrandName { get; set; }
        [Display(Name = "Website")]
        public string BrandWebsite { get; set; }
        [Display(Name = "Notes")]
        public string BrandNotes { get; set; }
        public ICollection<ItemBrand> ItemBrands { get; set; }
    }
}
