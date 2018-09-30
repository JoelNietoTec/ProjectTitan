using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Permissions;

namespace WebAPI.Controllers.Permissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustriesController : ControllerBase
    {
        private readonly PermissionsContext _context;
        public IndustriesController(PermissionsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Industry> GetIndustries()
        {
            return _context.Industries;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditIndustry([FromRoute] int id, [FromBody] Industry industry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != industry.Id)
            {
                return BadRequest();
            }

            _context.Entry(industry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndustryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(industry);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIndustry([FromBody] Industry industry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Industries.Add(industry);
            await _context.SaveChangesAsync();

            return Ok(industry);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndutry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var industry = await _context.Industries.FindAsync(id);
            if (industry == null)
            {
                return NotFound();
            }

            _context.Industries.Remove(industry);
            await _context.SaveChangesAsync();

            return Ok(industry);
        }
        
        private bool IndustryExists(int id)
        {
            return _context.Industries.Any(e => e.Id == id);
        }

    }
}