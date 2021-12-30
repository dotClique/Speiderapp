using System.Collections.Generic;
using System.Linq;
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
    public class RequirementController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public RequirementController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Requirement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequirementDto>>> GetRequirements()
        {
            return _mapper.Map<List<RequirementDto>>(
                await _context.Requirements
                    .Where(requirement => requirement.Discriminator == "Requirement")
                    .ToListAsync()
            );
        }

        // GET: api/Requirement/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RequirementDto>>> GetRequirementsAll()
        {
            return _mapper.Map<List<RequirementDto>>(await _context.Requirements.ToListAsync());
        }

        // Get: api/Requirement/<id>
        [HttpGet("{id:long}")]
        public async Task<ActionResult<RequirementDto>> GetRequirement(long id)
        {
            var requirement = await _context.Requirements.FindAsync(id);

            if (requirement == null)
            {
                return NotFound();
            }

            return _mapper.Map<RequirementDto>(requirement);
        }
    }
}
