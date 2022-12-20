using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Model;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>()
        {
             new SuperHero
             {
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
             },
              new SuperHero
             {
                Id = 2,
                Name = "Iron Man",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "New York City"
             },
               new SuperHero
             {
                Id = 3,
                Name = "Deadpool",
                FirstName = "Wade",
                LastName = "Wilson",
                Place = "New York City"
             },
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetHero(int id)
        {
            var currentHero = heroes.Find(h => h.Id == id);
            if (currentHero == null)
                return BadRequest("Hero not found");
            return Ok(currentHero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero newHero)
        {
            heroes.Add(newHero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
                return BadRequest("Hero not found");

                hero.Name = request.Name;
                hero.FirstName = request.FirstName;
                hero.LastName = request.LastName;
                hero.Place = request.Place;

                //heroes.Add(newHero);
            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var currentHero = heroes.Find(h => h.Id == id);
            if (currentHero == null)
                return BadRequest("Hero not found");
            heroes.Remove(currentHero);
            return Ok(currentHero);
        }


    }
}
