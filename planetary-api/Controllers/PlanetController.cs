using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using planetary_api.Models;

namespace planetary_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase{
        private readonly PlanetContext _context;
        public PlanetController(PlanetContext context)
        {
            _context = context;
            if(_context.Planets.Count() == 0){
                _context.Planets.Add(new Planet {PlanetName="Mercury"});
                _context.SaveChanges();
            }
            
        }

        // GET: api/planet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planet>>> getPlanets(){
            return await _context.Planets.ToListAsync();
        }

        //GET: api/planet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Planet>> GetPlanet(long id){
            var planet = await _context.Planets.FindAsync(id);
            if(planet == null){
                return NotFound();
            }

            return planet;
        }

        //POST: api/planet
        [HttpPost]
        public async Task<ActionResult<Planet>> PostPlanet(Planet planet){
            _context.Planets.Add(planet);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Planet), new Planet{Id = planet.Id}, planet);
        }

        //PUT: api/planet/5
        [HttpPut]
        public async Task<IActionResult> PutTodoItem(long id, Planet planet){
            if(id != planet.Id){
                return BadRequest();
            }

            _context.Entry(planet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //DELETE: api/planet/5
        [HttpDelete]
        public async Task<IActionResult> DeletePlanet(long id){
            var planet = await _context.Planets.FindAsync(id);
            if(planet == null){
                return NotFound();
            }

            _context.Planets.Remove(planet);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }   

}
