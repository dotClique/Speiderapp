using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using SpeiderappAPI.Database;
using SpeiderappAPI.DataTransferObjects;
using SpeiderappAPI.Models;
using SpeiderappAPI.Models.Interfaces;

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
            return await _context.Badges
                .ExcludeDeleted().ExcludeArchived()
                .ProjectTo<BadgeDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        // GET: api/Badge/<id>
        [HttpGet("{id:long}")]
        public async Task<ActionResult<BadgeDto>> GetBadge(long id)
        {
            var badge = await _context.Badges
                .ExcludeDeleted().ExcludeArchived()
                .Where(e => e.RequirementID == id).FirstOrDefaultAsync();

            if (badge == null)
            {
                return NotFound();
            }

            return _mapper.Map<BadgeDto>(badge);
        }
    }
}
