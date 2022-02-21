using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeiderappAPI.Database;
using SpeiderappAPI.DataTransferObjects;

namespace SpeiderappAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ResourceController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Resource
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceDto>>> GetResource()
        {
            return await _context.Resources.ProjectTo<ResourceDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        // GET: api/Resource/<id>
        [HttpGet("{id:long}")]
        public async Task<ActionResult<ResourceDto>> GetResource(long id)
        {
            var resource = await _context.Resources.FindAsync(id);

            if (resource == null)
            {
                return NotFound();
            }

            return _mapper.Map<ResourceDto>(resource);
        }
    }
}
