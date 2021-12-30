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
            return _mapper.Map<List<ResourceDto>>(await _context.Resources.ToListAsync());
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

        // // PUT: api/Resource/<id>
        // // To protect from over-posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id:long}")]
        // public async Task<IActionResult> PutResource(long id, Resource resource)
        // {
        //     if (id != resource.ResourceID)
        //     {
        //         return BadRequest();
        //     }
        //
        //     _context.Entry(resource).State = EntityState.Modified;
        //
        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!ResourceExists(id))
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
        // // POST: api/Resource
        // // To protect from over-posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Resource>> PostResource(Resource resource)
        // {
        //     _context.Resources.Add(resource);
        //     await _context.SaveChangesAsync();
        //
        //     return CreatedAtAction("GetResource", new { id = resource.ResourceID }, resource);
        // }
        //
        // // DELETE: api/Resource/<id>
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteResource(long id)
        // {
        //     var resource = await _context.Resources.FindAsync(id);
        //     if (resource == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     _context.Resources.Remove(resource);
        //     await _context.SaveChangesAsync();
        //
        //     return NoContent();
        // }
        //
        // private bool ResourceExists(long id)
        // {
        //     return _context.Resources.Any(e => e.ResourceID == id);
        // }
    }
}
