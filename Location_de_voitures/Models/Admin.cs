using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Location_de_voitures.Models
{
    public class Admin
    {
        [Key]
        public string idAdmin { get; set; }

        public string email { get; set; }
        public string Password { get; set; }
    }
}