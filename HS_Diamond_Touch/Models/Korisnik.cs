using System;
using System.Collections.Generic;

#nullable disable

namespace HS_Diamond_Touch.Models
{
    public partial class Korisnik
    {
        public int IdKorisnika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? BrojTelefona { get; set; }
        public string Spol { get; set; }
    }
}
