using HS_Diamond_Touch.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HS_Diamond_Touch.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UslugeController : ControllerBase
    {

        HS_Diamond_TouchContext db = new HS_Diamond_TouchContext();

        [HttpGet]
        public IActionResult prikazUsluga()
        {
            List<Usluga> prikazUsluga = db.Uslugas.OrderBy(r => r.IdUsluge).ToList();
            return Ok(prikazUsluga);
        }

        [HttpGet]
        public IActionResult prikazMuskihUsluga()
        {
            List<Bradum> prikazMuskihUsluga = db.Brada.OrderBy(r => r.IdBrada).ToList();
            return Ok(prikazMuskihUsluga);
        }

        [HttpGet]
        public IActionResult prikazFrizura()
        {
            List<Frizure> prikazFrizura = db.Frizures.OrderBy(r => r.IdFrizure).ToList();
            return Ok(prikazFrizura);
        }
        
        [HttpGet]
        public IActionResult prikazNoktiju()
        {
            List<Nokti> prikazNoktiju = db.Noktis.OrderBy(r => r.IdNokti).ToList();
            return Ok(prikazNoktiju);
        }

        [HttpPost]
        public IActionResult unosUsluge([FromBody] Usluga uslugaPodaci)
        {
            db.Add(uslugaPodaci);
            db.SaveChanges();
            return Ok(uslugaPodaci);
        }

        [HttpPost]
        public IActionResult unosMuskeUsluge([FromBody] Bradum muskaUsluga)
        {
            db.Add(muskaUsluga);
            db.SaveChanges();
            return Ok(muskaUsluga);
        }

        [HttpPost]
        public IActionResult unosFrizure([FromBody] Frizure frizuraUsluga)
        {
            db.Add(frizuraUsluga);
            db.SaveChanges();
            return Ok(frizuraUsluga);
        }

        [HttpPost]
        public IActionResult unosManikure([FromBody] Nokti noktiUsluga)
        {
            db.Add(noktiUsluga);
            db.SaveChanges();
            return Ok(noktiUsluga);
        }

        [HttpGet("{id}")]
        public IActionResult getUslugaById(int id)
        {
            List<Usluga> rezultat = db.Uslugas.Where(r => r.IdUsluge.Equals(id)).ToList();
            return Ok(rezultat);
        }
        
        [HttpGet("{id}")]
        public IActionResult getMuskaUslugaById(int id)
        {
            List<Bradum> rezultat = db.Brada.Where(r => r.IdBrada.Equals(id)).ToList();
            return Ok(rezultat);
        }

        [HttpGet("{id}")]
        public IActionResult getFrizuraUslugaById(int id)
        {
            List<Frizure> rezultat = db.Frizures.Where(r => r.IdFrizure.Equals(id)).ToList();
            return Ok(rezultat);
        }

        [HttpGet("{id}")]
        public IActionResult getNoktiUslugaById(int id)
        {
            List<Nokti> rezultat = db.Noktis.Where(r => r.IdNokti.Equals(id)).ToList();
            return Ok(rezultat);
        }

        [HttpPost]
        public IActionResult azurirajUslugu([FromBody] Usluga uslugaPodaci)
        {
            Usluga rezultat = db.Uslugas.Where(a => a.IdUsluge == uslugaPodaci.IdUsluge).FirstOrDefault();
            if (rezultat != null)
            {
                rezultat.NazivUsluge = (uslugaPodaci.NazivUsluge != null) ? uslugaPodaci.NazivUsluge : rezultat.NazivUsluge;
                rezultat.TrajanjeUsluge = (uslugaPodaci.TrajanjeUsluge != null) ? uslugaPodaci.TrajanjeUsluge : rezultat.TrajanjeUsluge;
                rezultat.KratkaCijena = (uslugaPodaci.KratkaCijena != null) ? uslugaPodaci.KratkaCijena : rezultat.KratkaCijena;
                rezultat.DugaCijena = (uslugaPodaci.DugaCijena != null) ? uslugaPodaci.DugaCijena : rezultat.DugaCijena;
                rezultat.ExtraDugaCijena = (uslugaPodaci.ExtraDugaCijena != null) ? uslugaPodaci.ExtraDugaCijena : rezultat.ExtraDugaCijena;

                db.SaveChanges();
            }
            else
            {
                return NotFound($"Usluga sa id {uslugaPodaci.IdUsluge} nije pronadjena");
            }

            return Ok(rezultat);
        }

        [HttpPost]
        public IActionResult azurirajMuskuUslugu([FromBody] Bradum muskiPodaci)
        {
            Bradum rezultat = db.Brada.Where(a => a.IdBrada == muskiPodaci.IdBrada).FirstOrDefault();
            if (rezultat != null)
            {
                rezultat.NazivUsluge = (muskiPodaci.NazivUsluge != null) ? muskiPodaci.NazivUsluge : rezultat.NazivUsluge;
                rezultat.TrajanjeUsluge = (muskiPodaci.TrajanjeUsluge != null) ? muskiPodaci.TrajanjeUsluge : rezultat.TrajanjeUsluge;
                rezultat.Cijena = (muskiPodaci.Cijena != null) ? muskiPodaci.Cijena : rezultat.Cijena;
                
                db.SaveChanges();
            }
            else
            {
                return NotFound($"Usluga sa id {muskiPodaci.IdBrada} nije pronadjena");
            }

            return Ok(rezultat);
        }

        [HttpPost]
        public IActionResult azurirajFrizure([FromBody] Frizure frizuraPodaci)
        {
            Frizure rezultat = db.Frizures.Where(a => a.IdFrizure == frizuraPodaci.IdFrizure).FirstOrDefault();
            if (rezultat != null)
            {
                rezultat.NazivUsluge = (frizuraPodaci.NazivUsluge != null) ? frizuraPodaci.NazivUsluge : rezultat.NazivUsluge;
                rezultat.TrajanjeUsluge = (frizuraPodaci.TrajanjeUsluge != null) ? frizuraPodaci.TrajanjeUsluge : rezultat.TrajanjeUsluge;
                rezultat.Cijena = (frizuraPodaci.Cijena != null) ? frizuraPodaci.Cijena : rezultat.Cijena;

                db.SaveChanges();
            }
            else
            {
                return NotFound($"Usluga sa id {frizuraPodaci.IdFrizure} nije pronadjena");
            }

            return Ok(rezultat);
        }

        [HttpPost]
        public IActionResult azurirajNokte([FromBody] Nokti noktiPodaci)
        {
            Nokti rezultat = db.Noktis.Where(a => a.IdNokti == noktiPodaci.IdNokti).FirstOrDefault();
            if (rezultat != null)
            {
                rezultat.NazivUsluge = (noktiPodaci.NazivUsluge != null) ? noktiPodaci.NazivUsluge : rezultat.NazivUsluge;
                rezultat.TrajanjeUsluge = (noktiPodaci.TrajanjeUsluge != null) ? noktiPodaci.TrajanjeUsluge : rezultat.TrajanjeUsluge;
                rezultat.Cijena = (noktiPodaci.Cijena != null) ? noktiPodaci.Cijena : rezultat.Cijena;

                db.SaveChanges();
            }
            else
            {
                return NotFound($"Usluga sa id {noktiPodaci.IdNokti} nije pronadjena");
            }

            return Ok(rezultat);
        }

        [HttpDelete("{param:int}")]
        public IActionResult brisanjeUsluge(int param)
        {
            Usluga rezultat = db.Uslugas.Where(a => a.IdUsluge == param).FirstOrDefault();
            if (rezultat == null)
            {
                return NotFound($"Podatak sa ID = {param} nije pronadjen");
            }
            else
            {
                db.Remove(rezultat);
                db.SaveChanges();
            }
            return Ok("Obrisano");
        }

        [HttpDelete("{param:int}")]
        public IActionResult brisanjeMuskeUsluge(int param)
        {
            Bradum rezultat = db.Brada.Where(a => a.IdBrada == param).FirstOrDefault();
            if (rezultat == null)
            {
                return NotFound($"Podatak sa ID = {param} nije pronadjen");
            }
            else
            {
                db.Remove(rezultat);
                db.SaveChanges();
            }
            return Ok("Obrisano");
        }

        [HttpDelete("{param:int}")]
        public IActionResult brisanjeFrizure(int param)
        {
            Frizure rezultat = db.Frizures.Where(a => a.IdFrizure == param).FirstOrDefault();
            if (rezultat == null)
            {
                return NotFound($"Podatak sa ID = {param} nije pronadjen");
            }
            else
            {
                db.Remove(rezultat);
                db.SaveChanges();
            }
            return Ok("Obrisano");
        }

        [HttpDelete("{param:int}")]
        public IActionResult brisanjeNoktiju(int param)
        {
            Nokti rezultat = db.Noktis.Where(a => a.IdNokti == param).FirstOrDefault();
            if (rezultat == null)
            {
                return NotFound($"Podatak sa ID = {param} nije pronadjen");
            }
            else
            {
                db.Remove(rezultat);
                db.SaveChanges();
            }
            return Ok("Obrisano");
        }
    }
}
