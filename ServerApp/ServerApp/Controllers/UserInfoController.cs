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
    public class UserInfoController : ControllerBase
    {
        private readonly ServerAppContext _context;

        public UserInfoController(ServerAppContext context)
        {
            _context = context;
        }

        // GET: api/UserInfo
        [HttpGet("all")]
        public IEnumerable<UserInfoModel> GetUserInfoModel()
        {
            return _context.UserInfoModel;
        }

        // GET: api/UserInfo
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
                return Ok(userInfoModel);
            }

            return Unauthorized();
        }

        // PUT: api/UserInfo/Glenn
        [HttpPut("{username}")]
        public async Task<IActionResult> PutUserInfoModel([FromRoute] string username, [FromBody] UserInfoModel userInfoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (username != userInfoModel.UserName)
            {
                return BadRequest();
            }

            _context.Entry(userInfoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoModelExists(username))
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

        // POST: api/UserInfo
        [HttpPost]
        public async Task<IActionResult> PostUserInfoModel([FromBody] UserInfoModel userInfoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (UserInfoModelExists(userInfoModel.UserName))
            {
                return BadRequest(ModelState);
            }
            userInfoModel.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(userInfoModel.Password);
            _context.UserInfoModel.Add(userInfoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfoModel", new { id = userInfoModel.Id }, userInfoModel);
        }

        // DELETE: api/UserInfo/Glenn
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUserInfoModel([FromRoute] string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInfoModel = await _context.UserInfoModel.FindAsync(username);
            if (userInfoModel == null)
            {
                return NotFound();
            }

            _context.UserInfoModel.Remove(userInfoModel);
            await _context.SaveChangesAsync();

            return Ok(userInfoModel);
        }

        private bool UserInfoModelExists(string username)
        {
            return _context.UserInfoModel.Any(e => e.UserName == username);
        }
    }
}