using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members =await context.Users.ToListAsync();
            return members;
        }
        [HttpGet("{Id}")]

        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var member =await context.Users.FindAsync(id);
            if (member == null) return NotFound();
            return member;
        }
    }
}