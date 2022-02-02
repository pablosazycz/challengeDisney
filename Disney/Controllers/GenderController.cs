using Disney.Context;
using Disney.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Disney.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class GenderController : ControllerBase
    {
      
        private readonly DisneyDb _context; 

        public GenderController(DisneyDb context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IActionResult Get(int Id)
        //{

        //    return Ok(_context.Genders.ToList());
        //}
        //[HttpPost]
        //public IActionResult Post(Gender gender)
        //{
        //    _context.Genders.Add(gender);
        //    _context.SaveChanges();

        //    return Ok();
        //}
        //[HttpPut]
        //public IActionResult Put()
        //{
        //    return Ok();
        //}
        //[HttpDelete]
        //public IActionResult Delete(Gender gender)
        //{

        //    return Ok();
        //}
    }
}