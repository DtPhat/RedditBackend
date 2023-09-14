using Azure.Core;
using Blueddit.Data;
using Blueddit.DTOs;
using Blueddit.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blueddit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAlUsers()
        {
            var UserList = await _context.Users.ToListAsync();
            return Ok(UserList);
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Post>>> GetUser(int userId)
        {
            var User = await _context.Users.FindAsync(userId);
            if (User == null) return NotFound(new { Message = "User not found!" });
            return Ok(User);
        }
        [HttpPost()]
        public async Task<ActionResult<List<User>>> CreateUser(UserCreateDto request)
        {
            var NewUser = new User
            {

                Email = request.Email,
                FullName = request.FullName, 
                ProfileImage = request.ProfileImage,    
            };
            _context.Users.Add(NewUser);
            await _context.SaveChangesAsync();
            return Ok("User added");
        }
    }
}
