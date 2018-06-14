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
    public class AlertSourcesController : ControllerBase
    {
        private readonly ParticipantsContext _context;

        public AlertSourcesController(ParticipantsContext context)
        {
            _context = context;
        }

        // GET: api/AlertSources
        [HttpGet]
        public IEnumerable<AlertSource> GetAlertSources()
        {
            return _context.AlertSources;
        }

        // GET: api/AlertSources/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlertSource([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alertSource = await _context.AlertSources.FindAsync(id);

            if (alertSource == null)
            {
                return NotFound();
            }

            return Ok(alertSource);
        }

        // PUT: api/AlertSources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlertSource([FromRoute] int id, [FromBody] AlertSource alertSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alertSource.Id)
            {
                return BadRequest();
            }

            _context.Entry(alertSource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertSourceExists(id))
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

        // POST: api/AlertSources
        [HttpPost]
        public async Task<IActionResult> PostAlertSource([FromBody] AlertSource alertSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AlertSources.Add(alertSource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlertSource", new { id = alertSource.Id }, alertSource);
        }

        // DELETE: api/AlertSources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlertSource([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alertSource = await _context.AlertSources.FindAsync(id);
            if (alertSource == null)
            {
                return NotFound();
            }

            _context.AlertSources.Remove(alertSource);
            await _context.SaveChangesAsync();

            return Ok(alertSource);
        }

        private bool AlertSourceExists(int id)
        {
            return _context.AlertSources.Any(e => e.Id == id);
        }
    }
}