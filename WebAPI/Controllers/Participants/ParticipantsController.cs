using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Participants;

namespace WebAPI.Controllers.Participants
{
    [Route("api/[controller]")]
    [ApiController]
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
            return _context.Participants
                .Include(p => p.Country)
                .Include(p => p.Type);
        }

        // GET: api/Participants/last
        [HttpGet("last")]
        public IEnumerable<Participant> GetLastParticipants()
        {
            return _context.Participants.OrderByDescending(x => x.CreateDate).Take(10);
        }

        [HttpGet("segments/{paramId}")]
        public IEnumerable<Segment> GetSegments([FromRoute] int paramId)
        {
            var query = @"SELECT ROW_NUMBER() OVER (ORDER BY ValueName) Id, ValueName, EnglishValueName, ValueId, SubValueId, Count 
            FROM [dbo].GetParticipantSegments({0})";

            var param = _context.Params.Find(paramId);
            _context.Entry(param).Reference(x => x.Table).Load();

            var segments = _context.Segments
                .FromSql(query, paramId)
                .ToList();
            return segments;
        }

        [HttpGet("byparam/{paramId}/value/{valueId}")]
        public IEnumerable<Participant> GetParticipantsByParam([FromRoute] int paramId, [FromRoute] int valueId)
        {
            var param = _context.Params.Find(paramId);
            _context.Entry(param).Reference(x => x.Table).Load();

            if (param.Table.TableTypeId == 1) {
                var segments = _context.ParticipantParams.Where(x => x.ParamId == paramId && x.ParamValueId == valueId);
                var ids = segments.Select(x => x.ParticipantId).ToList();
                return _context.Participants.Where(x => ids.Contains(x.Id));
            } else {
                var segments = _context.ParticipantParams.Where(x => x.ParamId == paramId && x.ParamSubValueId == valueId);
                var ids = segments.Select(x => x.ParticipantId).ToList();
                return _context.Participants.Where(x => ids.Contains(x.Id));
            }
        }

        // GET: api/participants/individuals
        [HttpGet("individuals")]
        public IEnumerable<Participant> GetIndividuals()
        {
            return _context.Participants.Where(x => x.ParticipantTypeId.Equals(1));
        }

        // GET: api/Participants/entities
        [HttpGet("entities")]
        public IEnumerable<Participant> GetEntities()
        {
            return _context.Participants.Where(x => x.ParticipantTypeId.Equals(2));
        }

        // GET: api/Participants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipants([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participant = await _context.Participants.FindAsync(id);

            _context.Entry(participant).Reference(x => x.Gender).Load();
            _context.Entry(participant).Reference(x => x.Country).Load();
            _context.Entry(participant).Reference(x => x.CreatedUser).Load();

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
            return _context.ParticipantsByRisk;
        }

        [HttpGet("bycountry")]
        public IEnumerable<ParticipantsByCountry> ParticipantsByCountries()
        {
            return _context.ParticipantsByCountry;
        }

        [HttpGet("{id}/params")]
        public IEnumerable<ParticipantParam> GetParticipantParams([FromRoute] int id)
        {
            return _context.ParticipantParams.Where(x => x.ParticipantId.Equals(id));
        }

        [HttpGet("{participantId}/params/{paramId}")]
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
            return _context.ParticipantRelationships
                .Where(x => x.ParticipantId.Equals(id) || x.RelatedParticipantId.Equals(id))
                .Include(x => x.Type)
                .Include(x => x.Participant)
                .Include(x => x.RelatedParticipant);
        }

        [HttpGet("{id}/documents")]
        public IEnumerable<ParticipantDocument> GetDocuments([FromRoute] int id)
        {
            return _context.ParticipantDocuments.Where(x => x.ParticipantId.Equals(id));
        }

        [HttpGet("{id}/profile")]
        public async Task<IActionResult> GetProfile([FromRoute] int id)
        {
            var profile =  await _context.ParticipantProfiles.Where(x => x.ParticipantId.Equals(id)).FirstOrDefaultAsync();
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }


        // PUT: api/Participants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipants([FromRoute] int id, [FromBody] Participant participants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participants.Id)
            {
                return BadRequest();
            }

            _context.Entry(participants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(participants);
        }

        // POST: api/Participants
        [HttpPost]
        public async Task<IActionResult> PostParticipants([FromBody] Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            participant.CreateDate = DateTime.Now;

            _context.Participants.Add(participant);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipants", new { id = participant.Id }, participant);
        }

        // DELETE: api/Participants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipants([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participants = await _context.Participants.FindAsync(id);
            if (participants == null)
            {
                return NotFound();
            }

            _context.Participants.Remove(participants);
            await _context.SaveChangesAsync();

            return Ok(participants);
        }

        private bool ParticipantsExists(int id)
        {
            return _context.Participants.Any(e => e.Id == id);
        }
    }
}