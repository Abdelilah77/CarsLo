using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Location_de_voitures.Models
{
    public class LocationDeVoiture
    {
        [Key]
        public int idlocation { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateReservation { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime datePaiment { get; set; }
  
        public int Montant { get; set; }
        public int idCli { get; set; }
        public int idV { get; set; }
        public virtual Voiture _ { get; set; }
        public virtual Client __ { get; set; }
        public virtual Admin ___ { get; set; }


    }
}