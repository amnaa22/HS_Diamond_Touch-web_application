using System;
using System.Collections.Generic;

#nullable disable

namespace HS_Diamond_Touch.Models
{
    public partial class NailArtist
    {
        public NailArtist()
        {
            Rezervacijas = new HashSet<Rezervacija>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Smjena { get; set; }
        public string Kvalifikacije { get; set; }
        public string Certifikati { get; set; }
        public string Email { get; set; }
        public int? BrojTelefona { get; set; }
        public string Slika { get; set; }

        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
    }
}
