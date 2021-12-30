using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeiderappAPI.Database;
using SpeiderappAPI.DataTransferObjects;

namespace SpeiderappAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public UserController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            return _mapper.Map<List<UserDto>>(await _context.Users.ToListAsync());
        }

        // GET: api/User/<id>
        [HttpGet("{id:long}")]
        public async Task<ActionResult<UserDto>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserDto>(user);
        }

        // // PUT: api/User/<id>
        // // To protect from over-posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id:long}")]
        // public async Task<IActionResult> PutUser(long id, User user)
        // {
        //     if (id != user.UserID)
        //     {
        //         return BadRequest();
        //     }
        //
        //     _context.Entry(user).State = EntityState.Modified;
        //
        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!UserExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }
        //
        //     return NoContent();
        // }
        //
        // // POST: api/User
        // // To protect from over-posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<User>> PostUser(User user)
        // {
        //     _context.Users.Add(user);
        //     await _context.SaveChangesAsync();
        //
        //     return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        // }
        //
        // // DELETE: api/User/<id>
        // [HttpDelete("{id:long}")]
        // public async Task<IActionResult> DeleteUser(long id)
        // {
        //     var user = await _context.Users.FindAsync(id);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     _context.Users.Remove(user);
        //     await _context.SaveChangesAsync();
        //
        //     return NoContent();
        // }
        //
        // private bool UserExists(long id)
        // {
        //     return _context.Users.Any(e => e.UserID == id);
        // }
    }
}
