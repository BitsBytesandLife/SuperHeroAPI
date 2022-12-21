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
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetHero(int id)
        {
            var currentHero = await _context.SuperHeroes.FindAsync(id); 
            if (currentHero == null)
                return BadRequest("Hero not found");
            return Ok(currentHero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero newHero)
        {
            _context.SuperHeroes.Add(newHero);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var Dbhero = await _context.SuperHeroes.FindAsync(request.Id);
            if (Dbhero == null)
                return BadRequest("Hero not found");

                Dbhero.Name = request.Name;
                Dbhero.FirstName = request.FirstName;
                Dbhero.LastName = request.LastName;
                Dbhero.Place = request.Place;

                await _context.SaveChangesAsync();
                //heroes.Add(newHero);
            return Ok(await _context.SuperHeroes.ToListAsync());
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
