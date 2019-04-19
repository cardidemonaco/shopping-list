using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping_list.DataLayer
{
    public class Initiative
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InitiativeID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string InitiativeName { get; set; }
        [Display(Name = "Description")]
        public string InitiativeDescription { get; set; }
    }
}
