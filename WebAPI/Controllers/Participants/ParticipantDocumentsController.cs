using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Participants;

namespace WebAPI.Controllers.Participants
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantDocumentsController : ControllerBase
    {
        private readonly ParticipantsContext _context;

        public ParticipantDocumentsController(ParticipantsContext context)
        {
            _context = context;
        }

        // GET: api/ParticipantDocuments
        [HttpGet]
        public IEnumerable<ParticipantDocument> GetParticipantDocuments()
        {
            return _context.ParticipantDocuments;
        }
        
        [HttpGet("expired")]
        public IEnumerable<ParticipantDocument> GetExpired()
        {
            return _context.ParticipantDocuments.Where(x => x.ExpirationDate <= DateTime.Today);
        }

        // GET: api/ParticipantDocuments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantDocument([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participantDocument = await _context.ParticipantDocuments.FindAsync(id);

            if (participantDocument == null)
            {
                return NotFound();
            }

            return Ok(participantDocument);
        }

        // PUT: api/ParticipantDocuments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantDocument([FromRoute] int id, [FromBody] ParticipantDocument participantDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participantDocument.Id)
            {
                return BadRequest();
            }

            _context.Entry(participantDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantDocumentExists(id))
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

        // POST: api/ParticipantDocuments
        [HttpPost]
        public async Task<IActionResult> PostParticipantDocument([FromBody] ParticipantDocument participantDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ParticipantDocuments.Add(participantDocument);

            _context.Entry(participantDocument.Country).State = EntityState.Unchanged;
            _context.Entry(participantDocument.Document).State = EntityState.Unchanged;
            _context.Entry(participantDocument.Type).State = EntityState.Unchanged;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipantDocument", new { id = participantDocument.Id }, participantDocument);
        }

        // DELETE: api/ParticipantDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantDocument([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participantDocument = await _context.ParticipantDocuments.FindAsync(id);
            if (participantDocument == null)
            {
                return NotFound();
            }

            _context.ParticipantDocuments.Remove(participantDocument);
            await _context.SaveChangesAsync();

            return Ok(participantDocument);
        }

        private bool ParticipantDocumentExists(int id)
        {
            return _context.ParticipantDocuments.Any(e => e.Id == id);
        }
    }
}