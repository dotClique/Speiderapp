using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeiderappAPI.Models;


namespace SpeiderappAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgeController : ControllerBase
    {
        private readonly BadgeContext _context;

        public BadgeController(BadgeContext context)
        {
            _context = context;
        }

        // GET: api/Badge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BadgeDTO>>> GetBadges()
        {
            return await _context.BadgeList
                .Select(x => x.toDTO())
                .ToListAsync();
        }

        // GET: api/Badge/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BadgeDTO>> GetBadge(long id)
        {
            var badge = await _context.BadgeList.FindAsync(id);

            if (badge == null)
            {
                return NotFound();
            }

            return badge.toDTO();
        }

        // PUT: api/Badge/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBadge(long id, BadgeDTO badgeDTO)
        {
            if (id != badgeDTO.Id)
            {
                return BadRequest();
            }

            var badge = await _context.BadgeList.FindAsync(id);
            if (badge == null)
            {
                return NotFound();
            }

            badge.Name = badgeDTO.Name;
            badge.IsComplete = badgeDTO.IsComplete;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!BadgeExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Badge
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Badge>> PostBadge(BadgeDTO badgeDTO)
        {
            var badge = new Badge
            {
                IsComplete = badgeDTO.IsComplete,
                Name = badgeDTO.Name
            };

            _context.BadgeList.Add(badge);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetBadge),
                new { id = badge.Id },
                badge.toDTO());
        }

        // DELETE: api/Badge/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Badge>> DeleteBadge(long id)
        {
            var badge = await _context.BadgeList.FindAsync(id);

            if (badge == null)
            {
                return NotFound();
            }

            _context.BadgeList.Remove(badge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BadgeExists(long id) =>
            _context.BadgeList.Any(e => e.Id == id);
    }
}
