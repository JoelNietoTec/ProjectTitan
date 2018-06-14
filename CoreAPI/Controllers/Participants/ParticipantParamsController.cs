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
    [EnableCors("AllowOrigin")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ParticipantParamsController : Controller
    {
        private readonly ParticipantsContext _context;

        public ParticipantParamsController(ParticipantsContext context)
        {
            _context = context;
        }

        // GET: api/ParticipantParams
        [HttpGet]
        public IEnumerable<ParticipantParam> GetParticipantParams()
        {
            return _context.ParticipantParams;
        }

        // GET: api/ParticipantParams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantParam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participantParam = await _context.ParticipantParams.FindAsync(id);

            if (participantParam == null)
            {
                return NotFound();
            }

            return Ok(participantParam);
        }

        // PUT: api/ParticipantParams/5
        [EnableCors("AllowOrigin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantParam([FromRoute] int id, [FromBody] ParticipantParam participantParam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participantParam.Id)
            {
                return BadRequest();
            }

            _context.Entry(participantParam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantParamExists(id))
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

        // POST: api/ParticipantParams
        [HttpPost]
        public async Task<IActionResult> PostParticipantParam([FromBody] ParticipantParam participantParam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ParticipantParams.Add(participantParam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipantParam", new { id = participantParam.Id }, participantParam);
        }

        // DELETE: api/ParticipantParams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantParam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participantParam = await _context.ParticipantParams.FindAsync(id);
            if (participantParam == null)
            {
                return NotFound();
            }

            _context.ParticipantParams.Remove(participantParam);
            await _context.SaveChangesAsync();

            return Ok(participantParam);
        }

        private bool ParticipantParamExists(int id)
        {
            return _context.ParticipantParams.Any(e => e.Id == id);
        }
    }
}