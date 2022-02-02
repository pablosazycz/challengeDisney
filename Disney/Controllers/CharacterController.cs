using Disney.Context;
using Disney.Entities;
using Disney.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.OpenApi.Writers;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Disney.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly DisneyDb _context;

        public CharacterController(DisneyDb context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(string name, int age)
        {
            var characters = _context.Characters.ToList();

            if (!string.IsNullOrEmpty(name))
            {
                characters = characters.Where(x => x.Name == name).ToList();
            }

            if (age >= 0)
            {
                characters = characters.Where(x => x.Age == age).ToList();
            }

            if (!characters.Any()) return NoContent();
            return Ok(characters);
        }
        [HttpGet]
        [Route(template: "characters")]
        public async Task<IActionResult> FiltroCharacter([FromQuery] CharactersGetRequestViewModel model)
        {
            var characters = _context.Characters.ToList();


            if (!string.IsNullOrEmpty(model.Image))
            {
                characters = characters.Where(x => x.Image == model.Image).ToList();

            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                characters = characters.Where(x => x.Name == model.Name).ToList();

            }

            if (!characters.Any())
                return NoContent();

            var responseViewModels = new List<CharactersGetResponseViewModel>();
            foreach (var character in characters)
            {
                responseViewModels.Add(new CharactersGetResponseViewModel()
                {
                    Image = character.Image,
                    Name = character.Name
                });

            }

            return Ok(responseViewModels);

        }



        [HttpPost]
        public IActionResult Post(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();

            return Ok(character);
        }
        [HttpPut]
        public IActionResult Put(Character character)
        {
            _context.Characters.Update(character);
            _context.SaveChanges();
            return Ok(character);
        }
        [HttpDelete]
        public IActionResult Delete(Character character)
        {
            _context.Characters.Remove(character);
            _context.SaveChanges();
            return Ok(character);
        }
    }
}