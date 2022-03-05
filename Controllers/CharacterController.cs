using Disney.Context;
using Disney.Entities;
using Disney.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.OpenApi.Writers;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

using Disney.Repositories;

namespace Disney.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository _characterRespository;
        private readonly DisneyDb _context;

   

        public CharacterController(ICharacterRepository repositories, DisneyDb context)
        {
            _context = context;
            _characterRespository = repositories;
        }

        [HttpGet]
        [Route ("Character")]
        public IActionResult GetCharacter([FromQuery] CharactersGetRequestViewModel model)
        {
            var characters = _context.Characters.ToList();

            if (!string.IsNullOrEmpty(model.Name))
            {
                characters = characters.Where(x => x.Name == model.Name).ToList();
            }

            if (!string.IsNullOrEmpty(model.Age.ToString()))
            {
                characters = characters.Where(x => x.Age == model.Age).ToList();
            }

            if (model.movieSerieID.Any())
            {
                characters = characters.Where(x=>x.MovieSerie.Any(y=>model.movieSerieID.Contains(y.Id))).ToList();  
            }
            if (!characters.Any()) return NoContent();

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
        [HttpGet]
        [Route(template: "Filtrocharacters")]
        public async Task<IActionResult> FiltroCharacter()
        {
            var characters = _context.Characters.ToList();
                      
            if (!characters.Any())
                return NoContent();

            var responseViewModels = new List<CharactersdetailsResponseviewmodel>();
            foreach (var character in characters)
            {
                responseViewModels.Add(new CharactersdetailsResponseviewmodel()
                {
                    Image = character.Image,
                    Name = character.Name,
                    Weight = character.Weight,
                    Age= character.Age,
                    Id=character.Id,
                    //MovieSerie = character.MovieSerie.Select(x => Title).Tolist()
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