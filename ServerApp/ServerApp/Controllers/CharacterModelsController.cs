using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.Database.Models;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterModelsController : ControllerBase
    {
        private readonly ServerAppContext _context;

        public CharacterModelsController(ServerAppContext context)
        {
            _context = context;
        }

        // GET: api/CharacterModels
        [HttpGet]
        public IEnumerable<CharacterModel> GetCharacterModel()
        {
            return _context.CharacterModel;
        }

        // GET: api/CharacterModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var characterModel = await _context.CharacterModel.FindAsync(id);

            if (characterModel == null)
            {
                return NotFound();
            }

            return Ok(characterModel);
        }

        // PUT: api/CharacterModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterModel([FromRoute] int id, [FromBody] CharacterModel characterModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != characterModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(characterModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CharacterModels
        [HttpPost]
        public async Task<IActionResult> PostCharacterModel([FromBody] CharacterModel characterModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CharacterModel.Add(characterModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacterModel", new { id = characterModel.Id }, characterModel);
        }

        // DELETE: api/CharacterModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var characterModel = await _context.CharacterModel.FindAsync(id);
            if (characterModel == null)
            {
                return NotFound();
            }

            _context.CharacterModel.Remove(characterModel);
            await _context.SaveChangesAsync();

            return Ok(characterModel);
        }

        private bool CharacterModelExists(int id)
        {
            return _context.CharacterModel.Any(e => e.Id == id);
        }
    }
}