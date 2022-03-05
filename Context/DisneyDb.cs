using Disney.Entities;
using Microsoft.EntityFrameworkCore;

namespace Disney.Context
{
    public class DisneyDb: DbContext 
    {
        public DisneyDb(DbContextOptions<DisneyDb> options) : base(options)
        {

        }
        public DbSet<Gender> Genders{ get; set; }
        public DbSet<MovieSerie> MovieSeries { get; set; }
        public DbSet<Character> Characters { get; set; }

    }
}
