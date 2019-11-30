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
    public class UserInfoModelsController : ControllerBase
    {
        private readonly ServerAppContext _context;

        public UserInfoModelsController(ServerAppContext context)
        {
            _context = context;
        }

        // GET: api/UserInfoModels
        [HttpGet("all")]
        public IEnumerable<UserInfoModel> GetUserInfoModel()
        {
            return _context.UserInfoModel.Include(c => c.CharacterModels);
        }

        // GET: api/UserInfoModels/
        [HttpGet]
        public async Task<IActionResult> GetUserInfoModel([FromBody] UserInfoModel userInfoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userFromDb = await _context.UserInfoModel.FindAsync(userInfoModel.UserName);

            if (userFromDb == null)
            {
                return NotFound();
            }

            if (BCrypt.Net.BCrypt.EnhancedVerify(userInfoModel.Password, userFromDb.Password))
            {
                var query = _context.UserInfoModel.Include(c => c.CharacterModels)
                    .Where(u => u.UserName.Equals(userInfoModel.UserName));
                return Ok(query);
            }

            return Unauthorized();
        }

        // PUT: api/UserInfoModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfoModel([FromRoute] string id, [FromBody] UserInfoModel userInfoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userInfoModel.UserName)
            {
                return BadRequest();
            }

            var userFromDb = await _context.UserInfoModel.FindAsync(userInfoModel.UserName);

            if (BCrypt.Net.BCrypt.EnhancedVerify(userInfoModel.Password, userFromDb.Password))
            {
                _context.Entry(userInfoModel).State = EntityState.Modified;
            }
            else
            {
                return Unauthorized();
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoModelExists(id))
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

        // POST: api/UserInfoModels
        [HttpPost]
        public async Task<IActionResult> PostUserInfoModel([FromBody] UserInfoModel userInfoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userInfoModel.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(userInfoModel.Password);
            _context.UserInfoModel.Add(userInfoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfoModel", new { id = userInfoModel.UserName }, userInfoModel);
        }

        // DELETE: api/UserInfoModels/
        [HttpDelete]
        public async Task<IActionResult> DeleteUserInfoModel([FromBody] UserInfoModel userInfoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userFromDb = await _context.UserInfoModel.FindAsync(userInfoModel.UserName);
            if (userFromDb == null)
            {
                return NotFound();
            }

            if (BCrypt.Net.BCrypt.EnhancedVerify(userInfoModel.Password, userFromDb.Password))
            {
                _context.UserInfoModel.Remove(userFromDb);
                await _context.SaveChangesAsync();

                return Ok(userInfoModel);
            }

            return Unauthorized();
        }

        private bool UserInfoModelExists(string id)
        {
            return _context.UserInfoModel.Any(e => e.UserName == id);
        }
    }
}