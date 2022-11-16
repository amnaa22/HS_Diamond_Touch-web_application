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
    public class RezervacijeController : ControllerBase
    {
        HS_Diamond_TouchContext db = new HS_Diamond_TouchContext();

        [HttpGet]
        public IActionResult getFrizeri() //za select svega
        {
            List<Frizer> podaci = db.Frizers.OrderBy(r => r.Ime).ToList();
            return Ok(podaci);
        }

        [HttpGet]
        public IActionResult getManikeri() //za select svega
        {
            List<NailArtist> podaci = db.NailArtists.OrderBy(r => r.Ime).ToList();
            return Ok(podaci);
        }
        
        [HttpGet]
        public IActionResult getManikuru() //za select svega
        {
            List<Nokti> podaci = db.Noktis.OrderBy(r => r.NazivUsluge).ToList();
            return Ok(podaci);
        }

        [HttpGet]
        public IActionResult getMuskuUslugu() //za select svega
        {
            List<Bradum> podaci = db.Brada.OrderBy(r => r.NazivUsluge).ToList();
            return Ok(podaci);
        }

        [HttpGet]
        public IActionResult getFrizure() //za select svega
        {
            List<Frizure> podaci = db.Frizures.OrderBy(r => r.NazivUsluge).ToList();
            return Ok(podaci);
        }

        [HttpGet]
        public IActionResult getUslugu() //za select svega
        {
            List<Usluga> podaci = db.Uslugas.OrderBy(r => r.NazivUsluge).ToList();
            return Ok(podaci);
        }
    }
}
