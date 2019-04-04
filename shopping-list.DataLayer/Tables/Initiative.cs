using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping_list.DataLayer.Tables
{
    public class Initiative
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InitiativeID { get; set; }
        public string InitiativeName { get; set; }
        public string InitiativeDescription { get; set; }
    }
}
