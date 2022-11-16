using System;
using System.Collections.Generic;

#nullable disable

namespace HS_Diamond_Touch.Models
{
    public partial class Rezervacija
    {
        public int IdRezervacije { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public int? BrojTelefona { get; set; }
        public string Spol { get; set; }
        public DateTime? Datum { get; set; }
        public TimeSpan? Vrijeme { get; set; }
        public int? IdUsluga { get; set; }
        public int? IdFrizure { get; set; }
        public int? IdBrada { get; set; }
        public int? IdNokti { get; set; }
        public int? IdFrizera { get; set; }
        public int? IdNailArtist { get; set; }
        public string Napomena { get; set; }

        public virtual Frizer IdFrizeraNavigation { get; set; }
        public virtual NailArtist IdNailArtistNavigation { get; set; }
        public virtual Usluga IdUslugaNavigation { get; set; }
    }
}
