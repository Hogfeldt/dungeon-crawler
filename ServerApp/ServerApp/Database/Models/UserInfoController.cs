using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;

namespace ServerApp.Database.Models
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
        [HttpGet]
        public IEnumerable<UserInfoModel> GetUserInfoModel()
        {
            return _context.UserInfoModel;
        }

        // GET: api/UserInfo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserInfoModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInfoModel = await _context.UserInfoModel.FindAsync(id);

            if (userInfoModel == null)
            {
                return NotFound();
            }

            return Ok(userInfoModel);
        }

        // PUT: api/UserInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfoModel([FromRoute] long id, [FromBody] UserInfoModel userInfoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userInfoModel.Id)
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

        // POST: api/UserInfo
        [HttpPost]
        public async Task<IActionResult> PostUserInfoModel([FromBody] UserInfoModel userInfoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserInfoModel.Add(userInfoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfoModel", new { id = userInfoModel.Id }, userInfoModel);
        }

        // DELETE: api/UserInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfoModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInfoModel = await _context.UserInfoModel.FindAsync(id);
            if (userInfoModel == null)
            {
                return NotFound();
            }

            _context.UserInfoModel.Remove(userInfoModel);
            await _context.SaveChangesAsync();

            return Ok(userInfoModel);
        }

        private bool UserInfoModelExists(long id)
        {
            return _context.UserInfoModel.Any(e => e.Id == id);
        }
    }
}