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
        [Display(Name = "Initiative Name")]
        public string InitiativeName { get; set; }
        public string InitiativeDescription { get; set; }
    }
}
