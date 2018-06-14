using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Financial;

namespace WebAPI.Controllers.Financial
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantProfilesController : ControllerBase
    {
        private readonly FinancialContext _context;

        public ParticipantProfilesController(FinancialContext context)
        {
            _context = context;
        }

        // GET: api/ParticipantProfiles
        [HttpGet]
        public IEnumerable<FinancialProfile> GetParticipantProfiles()
        {
            return _context.FinancialProfiles;
        }

        // GET: api/ParticipantProfiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participantProfile = await _context.FinancialProfiles.Where(x => x.ParticipantID.Equals(id)).FirstOrDefaultAsync();

            if (participantProfile == null)
            {
                return NotFound();
            }

            return Ok(participantProfile);
        }

        [HttpGet("{id}/products")]
        public IEnumerable<ProfileProduct> GetProfileProducts([FromRoute] int id)
        {
            return _context.ProfileProducts.Where(x => x.ParticipantProfileID.Equals(id));
        }

        [HttpGet("{id}/transactions")]
        public IEnumerable<Transaction> GetTransactions([FromRoute] int id)
        {
            return _context.Transactions.Where(x => x.ParticipantProfileId.Equals(id));
        }

        // PUT: api/ParticipantProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantProfile([FromRoute] int id, [FromBody] ParticipantProfile participantProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participantProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(participantProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantProfileExists(id))
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

        // POST: api/ParticipantProfiles
        [HttpPost]
        public async Task<IActionResult> PostParticipantProfile([FromBody] ParticipantProfile participantProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ParticipantProfiles.Add(participantProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipantProfile", new { id = participantProfile.Id }, participantProfile);
        }

        // DELETE: api/ParticipantProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participantProfile = await _context.ParticipantProfiles.FindAsync(id);
            if (participantProfile == null)
            {
                return NotFound();
            }

            _context.ParticipantProfiles.Remove(participantProfile);
            await _context.SaveChangesAsync();

            return Ok(participantProfile);
        }

        private bool ParticipantProfileExists(int id)
        {
            return _context.ParticipantProfiles.Any(e => e.Id == id);
        }
    }
}