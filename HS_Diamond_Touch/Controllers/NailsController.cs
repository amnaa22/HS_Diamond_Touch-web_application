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
    public class NailsController : ControllerBase
    {
        HS_Diamond_TouchContext db = new HS_Diamond_TouchContext();

        [HttpGet]
        public IActionResult prikazManikira()
        {
            List<NailArtist> prikazManikira = db.NailArtists.OrderByDescending(r => r.Id).ToList();
            return Ok(prikazManikira);
        }
    }
}
