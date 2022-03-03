using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class juriController : ControllerBase
    {
        private static List<Juri> heroes = new List<Juri>
        {
        new Juri
            {
            Id = 1,
            Name = "Spider Man",
            FirstName = "Peter",
            LastName = "Parker",
            Place = "New York City"
            },
        new Juri
            {
            Id = 2,
            Name = "Iron Man",
            FirstName = "Tony",
            LastName = "Stark",
            Place = "Long Island"
            }
        };
        

        [HttpGet]
        public async Task<ActionResult<List<Juri>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Juri>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }
        
        [HttpPost]
        public async Task<ActionResult<List<Juri>>> AddHero(Juri hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<Juri>>> UpdateHero(Juri request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
                return BadRequest("Hero not found.");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Juri>>> DeleteHero(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not found.");

            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}
