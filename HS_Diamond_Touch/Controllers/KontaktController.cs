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
    public class KontaktController : ControllerBase
    {
        HS_Diamond_TouchContext db = new HS_Diamond_TouchContext();

        [HttpPost]
        public IActionResult unosKontaka([FromBody] QA kontaktPodaci)
        {
            db.Add(kontaktPodaci);
            db.SaveChanges();
            return Ok(kontaktPodaci);
        }

        [HttpGet]
        public IActionResult prikazKontaktPitanja()
        {
            List<QA> prikazPitanja = db.QAs.OrderBy(r => r.RedniBroj).ToList();
            return Ok(prikazPitanja);
        }
    }
}
