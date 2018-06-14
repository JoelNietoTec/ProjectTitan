using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAPI.Models.Settings;

namespace CoreAPI.Controllers.Settings
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TransactionSourcesController : Controller
    {
        private readonly SettingsContext _context;

        public TransactionSourcesController(SettingsContext context)
        {
            _context = context;
        }

        // GET: api/TransactionSources
        [HttpGet]
        public IEnumerable<TransactionSource> GetTransactionSources()
        {
            return _context.TransactionSources;
        }

        // GET: api/TransactionSources/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionSource([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transactionSource = await _context.TransactionSources.FindAsync(id);

            if (transactionSource == null)
            {
                return NotFound();
            }

            return Ok(transactionSource);
        }

        // PUT: api/TransactionSources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionSource([FromRoute] int id, [FromBody] TransactionSource transactionSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transactionSource.Id)
            {
                return BadRequest();
            }

            _context.Entry(transactionSource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionSourceExists(id))
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

        // POST: api/TransactionSources
        [HttpPost]
        public async Task<IActionResult> PostTransactionSource([FromBody] TransactionSource transactionSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TransactionSources.Add(transactionSource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionSource", new { id = transactionSource.Id }, transactionSource);
        }

        // DELETE: api/TransactionSources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionSource([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transactionSource = await _context.TransactionSources.FindAsync(id);
            if (transactionSource == null)
            {
                return NotFound();
            }

            _context.TransactionSources.Remove(transactionSource);
            await _context.SaveChangesAsync();

            return Ok(transactionSource);
        }

        private bool TransactionSourceExists(int id)
        {
            return _context.TransactionSources.Any(e => e.Id == id);
        }
    }
}