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
    public class BadgeController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public BadgeController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Badge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BadgeDto>>> GetBadges()
        {
            return _mapper.Map<List<BadgeDto>>(
                await _context.Badges.ToListAsync()
            );
            // return await _context.Badges/* .Include(badge => badge.Resources) */.ToListAsync();
        }

        // GET: api/Badge/<id>
        [HttpGet("{id:long}")]
        public async Task<ActionResult<BadgeDto>> GetBadge(long id)
        {
            var badge = await _context.Badges.FindAsync(id);

            if (badge == null)
            {
                return NotFound();
            }

            return _mapper.Map<BadgeDto>(badge);
        }

        // // PUT: api/Badge/<id>
        // // To protect from over-posting attacks, enable the specific properties you want to bind to, for
        // // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // [HttpPut("{id:long}")]
        // public async Task<IActionResult> PutBadge(long id, Badge badge)
        // {
        //     if (id != badge.RequirementID)
        //     {
        //         return BadRequest();
        //     }
        //
        //     _context.Entry(badge).State = EntityState.Modified;
        //
        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!BadgeExists(id))
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
        // // POST: api/Badge
        // // To protect from over-posting attacks, enable the specific properties you want to bind to, for
        // // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // [HttpPost]
        // public async Task<ActionResult<Badge>> PostBadge(Badge badge)
        // {
        //     _context.Badges.Add(badge);
        //     await _context.SaveChangesAsync();
        //
        //     return CreatedAtAction("GetBadge", new { id = badge.RequirementID }, badge);
        // }
        //
        // // DELETE: api/Badge/<id>
        // [HttpDelete("{id:long}")]
        // public async Task<ActionResult<Badge>> DeleteBadge(long id)
        // {
        //     var badge = await _context.Badges.FindAsync(id);
        //     if (badge == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     _context.Badges.Remove(badge);
        //     await _context.SaveChangesAsync();
        //
        //     return badge;
        // }
        //
        // private bool BadgeExists(long id)
        // {
        //     return _context.Badges.Any(e => e.RequirementID == id);
        // }
    }
}
