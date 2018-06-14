using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAPI.Models.Participants;

namespace CoreAPI.Controllers.Participants
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ParticipantRelationshipsController : Controller
    {
        private readonly ParticipantsContext _context;

        public ParticipantRelationshipsController(ParticipantsContext context)
        {
            _context = context;
        }

        // GET: api/ParticipantRelationships
        [HttpGet]
        public IEnumerable<ParticipantRelationship> GetParticipantRelationships()
        {
            return _context.ParticipantRelationships;
        }

        // GET: api/ParticipantRelationships/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantRelationship([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participantRelationship = await _context.ParticipantRelationships.FindAsync(id);

            if (participantRelationship == null)
            {
                return NotFound();
            }

            return Ok(participantRelationship);
        }

        // PUT: api/ParticipantRelationships/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantRelationship([FromRoute] int id, [FromBody] ParticipantRelationship participantRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participantRelationship.Id)
            {
                return BadRequest();
            }

            _context.Entry(participantRelationship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantRelationshipExists(id))
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

        // POST: api/ParticipantRelationships
        [HttpPost]
        public async Task<IActionResult> PostParticipantRelationship([FromBody] ParticipantRelationship participantRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ParticipantRelationships.Add(participantRelationship);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipantRelationship", new { id = participantRelationship.Id }, participantRelationship);
        }

        // DELETE: api/ParticipantRelationships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantRelationship([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participantRelationship = await _context.ParticipantRelationships.FindAsync(id);
            if (participantRelationship == null)
            {
                return NotFound();
            }

            _context.ParticipantRelationships.Remove(participantRelationship);
            await _context.SaveChangesAsync();

            return Ok(participantRelationship);
        }

        private bool ParticipantRelationshipExists(int id)
        {
            return _context.ParticipantRelationships.Any(e => e.Id == id);
        }
    }
}