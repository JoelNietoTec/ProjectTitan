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
    public class AlertReasonsController : ControllerBase
    {
        private readonly ParticipantsContext _context;

        public AlertReasonsController(ParticipantsContext context)
        {
            _context = context;
        }

        // GET: api/AlertReasons
        [HttpGet]
        public IEnumerable<AlertReason> GetAlertReasons()
        {
            return _context.AlertReasons;
        }

        // GET: api/AlertReasons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlertReason([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alertReason = await _context.AlertReasons.FindAsync(id);

            if (alertReason == null)
            {
                return NotFound();
            }

            return Ok(alertReason);
        }

        // PUT: api/AlertReasons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlertReason([FromRoute] int id, [FromBody] AlertReason alertReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alertReason.Id)
            {
                return BadRequest();
            }

            _context.Entry(alertReason).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertReasonExists(id))
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

        // POST: api/AlertReasons
        [HttpPost]
        public async Task<IActionResult> PostAlertReason([FromBody] AlertReason alertReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AlertReasons.Add(alertReason);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlertReason", new { id = alertReason.Id }, alertReason);
        }

        // DELETE: api/AlertReasons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlertReason([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alertReason = await _context.AlertReasons.FindAsync(id);
            if (alertReason == null)
            {
                return NotFound();
            }

            _context.AlertReasons.Remove(alertReason);
            await _context.SaveChangesAsync();

            return Ok(alertReason);
        }

        private bool AlertReasonExists(int id)
        {
            return _context.AlertReasons.Any(e => e.Id == id);
        }
    }
}