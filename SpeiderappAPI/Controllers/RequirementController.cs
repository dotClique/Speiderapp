﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeiderappAPI.Database;
using SpeiderappAPI.DataTransferObjects;
using SpeiderappAPI.Models;

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
            return await _context.Requirements.Where(requirement => requirement.RequirementType == nameof(Requirement))
                .ProjectTo<RequirementDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        // GET: api/Requirement/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RequirementDto>>> GetRequirementsAll()
        {
            return await _context.Requirements.ProjectTo<RequirementDto>(_mapper.ConfigurationProvider).ToListAsync();
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
