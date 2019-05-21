using Microsoft.EntityFrameworkCore;
using planetary_api.Models;

namespace planetary_api{
    public class PlanetContext : DbContext{
        public PlanetContext(DbContextOptions<PlanetContext> options)
        : base (options){

        }

        public DbSet<Planet> Planets {get; set;}
    }
}