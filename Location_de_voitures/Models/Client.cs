using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Location_de_voitures.Models
{
    public class Client
    {
        [Key]
        public int Id_cli { get; set; }
        public string Nom { get; set; }
        public string adresseClient{ get; set; }
        
        public string Tel { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }
        public string Password { get; set; }

    }
}