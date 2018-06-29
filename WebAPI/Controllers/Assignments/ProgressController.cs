using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Assignments;

namespace WebAPI.Controllers.Assignments
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly AssignmentsContext _context;

        public ProgressController(AssignmentsContext context)
        {
            _context = context;
        }

        // GET: api/Progresses
        [HttpGet]
        public IEnumerable<Progress> GetProgress()
        {
            return _context.Progress;
        }

        // GET: api/Progresses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var progress = await _context.Progress.FindAsync(id);

            if (progress == null)
            {
                return NotFound();
            }

            return Ok(progress);
        }

        // PUT: api/Progresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgress([FromRoute] int id, [FromBody] Progress progress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != progress.Id)
            {
                return BadRequest();
            }

            _context.Entry(progress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Progresses
        [HttpPost]
        public async Task<IActionResult> PostProgress([FromBody] Progress progress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Progress.Add(progress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgress", new { id = progress.Id }, progress);
        }

        // DELETE: api/Progresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var progress = await _context.Progress.FindAsync(id);
            if (progress == null)
            {
                return NotFound();
            }

            _context.Progress.Remove(progress);
            await _context.SaveChangesAsync();

            return Ok(progress);
        }

        private bool ProgressExists(int id)
        {
            return _context.Progress.Any(e => e.Id == id);
        }
    }
}