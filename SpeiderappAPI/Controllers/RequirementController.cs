using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeiderappAPI.Database;
using SpeiderappAPI.Models;

namespace SpeiderappAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequirementController : ControllerBase
    {
        private readonly ApiContext _context;

        public RequirementController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Requirement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requirement>>> GetRequirements()
        {
            return await _context.Requirements
                .Where(requirement => requirement.Discriminator == "Requirement")
                .ToListAsync();
        }

        // GET: api/Requirement/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Requirement>>> GetRequirementsAll()
        {
            return await _context.Requirements.ToListAsync();
        }

        // Get: api/Requirement/<id>
        [HttpGet("{id:long}")]
        public async Task<ActionResult<Requirement>> GetRequirement(long id)
        {
            var requirement = await _context.Requirements.FindAsync(id);

            if (requirement == null)
            {
                return NotFound();
            }

            return requirement;
        }
    }
}
