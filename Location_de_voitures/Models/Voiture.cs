using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Location_de_voitures.Models
{
    public class Voiture
    {
    
        [Key]
        public int Vmatricule { get; set; }
        public string Name { get; set; }
        public double PrixKm { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime datePriseduKm { get; set; }
        public int kilometrage { get; set; }
        public string ImgUrl { get; set; }
      

    }
}