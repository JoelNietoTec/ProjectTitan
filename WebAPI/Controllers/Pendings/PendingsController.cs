using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Pendings;

namespace WebAPI.Controllers.Pendings
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendingsController : ControllerBase
    {
        private readonly PendingsContext _context;

        public PendingsController(PendingsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Pending> GetPendings()
        {
            return _context.Pendings
                .Include(p => p.Stage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPending([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pending = await _context.Pendings.FindAsync(id);

            if (pending == null)
            {
                return NotFound();
            }

            _context.Entry(pending).Reference(x => x.Stage).Load();

            return Ok(pending);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPending([FromRoute] int id, [FromBody] Pending pending)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pending.Id)
            {
                return BadRequest();
            }

            _context.Entry(pending).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PendingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(pending);
        }

        [HttpPost]
        public async Task<IActionResult> PostPending([FromBody] Pending pending)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            pending.CreateDate = DateTime.Now;

            _context.Pendings.Add(pending);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPending", new { id = pending.Id }, pending);
        }

        public async Task<IActionResult> DeletePending([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pending = await _context.Pendings.FindAsync(id);
            if (pending == null)
            {
                return NotFound();
            }

            _context.Pendings.Remove(pending);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool PendingExists(int id)
        {
            return _context.Pendings.Any(e => e.Id == id);
        }
    }
}