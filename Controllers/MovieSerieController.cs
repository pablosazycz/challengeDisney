using Disney.Context;
using Disney.Entities;
using Disney.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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

            //if (//!Datecreation ==0)
            //{
            //    movie = movie.Where(x => x.Datecreation == Datecreation).ToList();
            //}
            return Ok(_context.MovieSeries.ToList());
        }

        [HttpGet]
        [Route(template: "movies")]
        public IActionResult FiltroMovie([FromQuery] MovieSerieGetRequestViewModel model)
        {
            var movies = _context.MovieSeries.ToList();


            if (!string.IsNullOrEmpty(model.Image))
            {
                movies = movies.Where(x => x.Image == model.Image).ToList();

            }

            if (!string.IsNullOrEmpty(model.Title))
            {
                movies = movies.Where(x => x.Title == model.Title).ToList();
                movies = movies.Where(y => y.Datecreation == model.Datecreation).ToList();
            }


            if (!movies.Any())
                return NoContent();

            var responseViewModels = new List<MovieSerieGetResponseViewModel>();
            foreach (var movie in movies)
            {
                responseViewModels.Add(new MovieSerieGetResponseViewModel()
                {
                    Image = movie.Image,
                    Title = movie.Title
                });

            }

            return Ok(responseViewModels);

        }

        [HttpPost]
        public IActionResult Post( MovieSeriePostRequestViewModel model)
        {
            var gender = _context.Genders.Find(model.GenreId);
            if (gender==null)
            {
                return BadRequest("genero invalido");
            }

            var movie = new MovieSerie()
            {
                Description = model.Description,
                Image = model.Image,
                Datecreation = model.Datecreation,
                Qualification = model.Qualification,
                Gender = gender

            };

            _context.MovieSeries.Add(movie);
            _context.SaveChanges();

            return Ok(movie);
        }
        [HttpPut]
        public IActionResult Put(MovieSerie movie)
        {
            _context.MovieSeries.Update(movie);
            _context.SaveChanges();
            return Ok(movie);
        }
        [HttpDelete]
        public IActionResult Delete(MovieSerie movie)
        {
            _context.MovieSeries.Remove(movie);
            _context.SaveChanges();
            return Ok(movie);
        }
    }
}
