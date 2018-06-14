using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAPI.Models.Participants;
using Microsoft.AspNetCore.Cors;

namespace CoreAPI.Controllers.Participants
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class ParticipantsController : ControllerBase
    {
        private readonly ParticipantsContext _context;

        public ParticipantsController(ParticipantsContext context)
        {
            _context = context;
        }

        // GET: api/Participants
        [HttpGet]
        public IEnumerable<Participant> GetParticipants()
        {
            return _context.Participants;
        }

        // GET: api/Participants/last
        [HttpGet("last")]
        public IEnumerable<Participant> GetLastParticipants()
        {
            return _context.Participants.OrderByDescending(x => x.CreateDate).Take(10);
        }

        // GET: api/Participants/individuals
        [HttpGet("individuals")]
        public IEnumerable<Participant> GetIndividuals()
        {
            return _context.Participants.Where(x => x.ParticipantTypeId == 1);
        }

        // GET: api/Participants/entities
        [HttpGet("entities")]
        public IEnumerable<Participant> GetEntities()
        {
            return _context.Participants.Where(x => x.ParticipantTypeId == 2);
        }

        // GET: api/Participants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participant = await _context.Participants.FindAsync(id);

            if (participant == null)
            {
                return NotFound();
            }

            return Ok(participant);
        }

        [HttpGet("{id}/pending")]
        public IEnumerable<PendingDocument> PendingDocuments([FromRoute] int id)
        {
            return _context.PendingDocuments.Where(x => x.ParticipantID == id);
        }

        [HttpGet("byrisk")]
        public IEnumerable<ParticipantsByRisk> ParticipantsByRisks()
        {
            return _context.ParticipantsByRisk.FromSql("SELECT * FROM ParticipantsByRisk");
        }

        [HttpGet("bycountry")]
        public IEnumerable<ParticipantsByCountry> GetParticipantsByCountries()
        {
            return _context.ParticipantsByCountry.FromSql("SELECT * FROM ParticipantsByCountry");
        }

        [HttpGet("{id}/params")]
        public IEnumerable<ParticipantParam> GetParamsByParticipant([FromRoute] int id)
        {
            return _context.ParticipantParams.Where(x => x.ParticipantId.Equals(id));
        }

        [HttpGet("{participantId}/params/{paramID}")]
        public async Task<IActionResult> GetParam([FromRoute] int participantId, [FromRoute] int paramId)
        {
            var param = await _context.ParticipantParams.Where(x => x.ParticipantId.Equals(participantId) && x.ParamId.Equals(paramId)).FirstOrDefaultAsync();

            if (param == null)
            {
                return NotFound();
            }

            return Ok(param);
        }

        [HttpGet("{id}/relationships")]
        public IEnumerable<ParticipantRelationship> GetRelationships([FromRoute] int id)
        {
            return _context.ParticipantRelationships.Where(x => x.ParticipantId == id);
        }

        [HttpGet("{id}/documents")]
        public IEnumerable<ParticipantDocument> GetDocuments([FromRoute] int id)
        {
            return _context.ParticipantDocuments.Where(x => x.ParticipantId == id);
        }

        // PUT: api/Participants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipant([FromRoute] int id, [FromBody] Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participant.Id)
            {
                return BadRequest();
            }

            _context.Entry(participant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
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

        // POST: api/Participants
        [HttpPost]
        public async Task<IActionResult> PostParticipant([FromBody] Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipant", new { id = participant.Id }, participant);
        }

        // DELETE: api/Participants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            return Ok(participant);
        }

        private bool ParticipantExists(int id)
        {
            return _context.Participants.Any(e => e.Id == id);
        }
    }
}