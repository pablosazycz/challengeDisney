using Disney.Context;
using Disney.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Disney.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class MovieSerieController : ControllerBase
    {

        private readonly DisneyDb _context;

        public MovieSerieController(DisneyDb context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(string title, string gender, DateTime Datecreation )
        {
            var movie = _context.MovieSeries.ToList();

            if (!string.IsNullOrEmpty(title))
            {
                movie = movie.Where(x => x.Title == title).ToList();
            }

            if (!string.IsNullOrEmpty(gender))
            {
                movie = movie.Where(x => x.Gender.Name == gender).ToList();
            }

            if (!Datecreation ==0)
            {
                movie = movie.Where(x => x.Datecreation == Datecreation).ToList();
            }
            return Ok(_context.Characters.ToList());
        }
        [HttpPost]
        public IActionResult Post(MovieSerie movieserie)
        {
            _context.MovieSeries.Add(movieserie);
            _context.SaveChanges();

            return Ok(movieserie);
        }
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete()
        {

            return Ok();
        }
    }
}