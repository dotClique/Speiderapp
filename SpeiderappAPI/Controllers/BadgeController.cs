using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SpeiderappAPI.Models;
using SpeiderappAPI.Database;

namespace SpeiderappAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgeController : ControllerBase
    {
        private readonly ApiContext _context;

        public BadgeController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Badge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Badge>>> GetBadges()
        {
            return await _context.Badges/* .Include(badge => badge.Resources) */.ToListAsync();
        }

        // GET: api/Badge/5
        [HttpGet("{id:long}")]
        public async Task<ActionResult<Badge>> GetBadge(long id)
        {
            var badge = await _context.Badges.FindAsync(id);

            if (badge == null)
            {
                return NotFound();
            }

            return badge;
        }

        // PUT: api/Badge/5
        // To protect from over-posting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutBadge(long id, Badge badge)
        {
            if (id != badge.RequirementID)
            {
                return BadRequest();
            }

            _context.Entry(badge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BadgeExists(id))
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

        // POST: api/Badge
        // To protect from over-posting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Badge>> PostBadge(Badge badge)
        {
            _context.Badges.Add(badge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBadge", new { id = badge.RequirementID }, badge);
        }

        // DELETE: api/Badge/5
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<Badge>> DeleteBadge(long id)
        {
            var badge = await _context.Badges.FindAsync(id);
            if (badge == null)
            {
                return NotFound();
            }

            _context.Badges.Remove(badge);
            await _context.SaveChangesAsync();

            return badge;
        }

        private bool BadgeExists(long id)
        {
            return _context.Badges.Any(e => e.RequirementID == id);
        }
    }
}
