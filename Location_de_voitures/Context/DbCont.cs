using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Location_de_voitures.Models;

namespace Location_de_voitures.Context
{
    public class DbCont:DbContext
    {
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<LocationDeVoiture> LocationDeVoitures { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Voiture> Voitures { get; set; }
    }
}