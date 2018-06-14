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
    public class RoadmapsController : Controller
    {
        private readonly RoadmapContext _context;

        public RoadmapsController(RoadmapContext context)
        {
            _context = context;
        }

        // GET: api/Roadmaps
        [HttpGet]
        public IEnumerable<Roadmap> GetRoadmaps()
        {
            return _context.Roadmaps;
        }

        // GET: api/Roadmaps/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoadmap([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roadmap = await _context.Roadmaps.FindAsync(id);

            if (roadmap == null)
            {
                return NotFound();
            }

            return Ok(roadmap);
        }

        // PUT: api/Roadmaps/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoadmap([FromRoute] int id, [FromBody] Roadmap roadmap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roadmap.Id)
            {
                return BadRequest();
            }

            _context.Entry(roadmap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoadmapExists(id))
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

        // POST: api/Roadmaps
        [HttpPost]
        public async Task<IActionResult> PostRoadmap([FromBody] Roadmap roadmap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Roadmaps.Add(roadmap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoadmap", new { id = roadmap.Id }, roadmap);
        }

        // DELETE: api/Roadmaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoadmap([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roadmap = await _context.Roadmaps.FindAsync(id);
            if (roadmap == null)
            {
                return NotFound();
            }

            _context.Roadmaps.Remove(roadmap);
            await _context.SaveChangesAsync();

            return Ok(roadmap);
        }

        private bool RoadmapExists(int id)
        {
            return _context.Roadmaps.Any(e => e.Id == id);
        }
    }
}