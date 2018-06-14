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
    public class PhasesController : Controller
    {
        private readonly RoadmapContext _context;

        public PhasesController(RoadmapContext context)
        {
            _context = context;
        }

        // GET: api/Phases
        [HttpGet]
        public IEnumerable<Phase> GetPhases()
        {
            return _context.Phases;
        }

        // GET: api/Phases/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var phase = await _context.Phases.FindAsync(id);

            if (phase == null)
            {
                return NotFound();
            }

            return Ok(phase);
        }

        // PUT: api/Phases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhase([FromRoute] int id, [FromBody] Phase phase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phase.Id)
            {
                return BadRequest();
            }

            _context.Entry(phase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhaseExists(id))
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

        // POST: api/Phases
        [HttpPost]
        public async Task<IActionResult> PostPhase([FromBody] Phase phase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Phases.Add(phase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhase", new { id = phase.Id }, phase);
        }

        // DELETE: api/Phases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var phase = await _context.Phases.FindAsync(id);
            if (phase == null)
            {
                return NotFound();
            }

            _context.Phases.Remove(phase);
            await _context.SaveChangesAsync();

            return Ok(phase);
        }

        private bool PhaseExists(int id)
        {
            return _context.Phases.Any(e => e.Id == id);
        }
    }
}