using System;
using System.Collections.Generic;

#nullable disable

namespace HS_Diamond_Touch.Models
{
    public partial class Usluga
    {
        public Usluga()
        {
            Rezervacijas = new HashSet<Rezervacija>();
        }

        public int IdUsluge { get; set; }
        public string NazivUsluge { get; set; }
        public string TrajanjeUsluge { get; set; }
        public string KratkaCijena { get; set; }
        public string SrednjaCijena { get; set; }
        public string DugaCijena { get; set; }
        public string ExtraDugaCijena { get; set; }

        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
    }
}
