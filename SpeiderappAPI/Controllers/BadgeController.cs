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
    }
}
