using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAPI.Models.Roadmaps;

namespace CoreAPI.Controllers.Roadmaps
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RecurrencesController : Controller
    {
        private readonly RoadmapContext _context;

        public RecurrencesController(RoadmapContext context)
        {
            _context = context;
        }

        // GET: api/Recurrences
        [HttpGet]
        public IEnumerable<Recurrence> GetRecurrences()
        {
            return _context.Recurrences;
        }

        // GET: api/Recurrences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecurrence([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recurrence = await _context.Recurrences.FindAsync(id);

            if (recurrence == null)
            {
                return NotFound();
            }

            return Ok(recurrence);
        }

        // PUT: api/Recurrences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecurrence([FromRoute] int id, [FromBody] Recurrence recurrence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recurrence.Id)
            {
                return BadRequest();
            }

            _context.Entry(recurrence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecurrenceExists(id))
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

        // POST: api/Recurrences
        [HttpPost]
        public async Task<IActionResult> PostRecurrence([FromBody] Recurrence recurrence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Recurrences.Add(recurrence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecurrence", new { id = recurrence.Id }, recurrence);
        }

        // DELETE: api/Recurrences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecurrence([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recurrence = await _context.Recurrences.FindAsync(id);
            if (recurrence == null)
            {
                return NotFound();
            }

            _context.Recurrences.Remove(recurrence);
            await _context.SaveChangesAsync();

            return Ok(recurrence);
        }

        private bool RecurrenceExists(int id)
        {
            return _context.Recurrences.Any(e => e.Id == id);
        }
    }
}