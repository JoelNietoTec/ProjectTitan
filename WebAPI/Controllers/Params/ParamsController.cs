using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Params;

namespace WebAPI.Controllers.Params
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParamsController : ControllerBase
    {
        private readonly ParamsContext _context;

        public ParamsController(ParamsContext context)
        {
            _context = context;
        }

        // GET: api/Params
        [HttpGet]
        public IEnumerable<Param> GetParams()
        {
            return _context.Params;
        }
        // GET: api/Params/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @param = await _context.Params.FindAsync(id);

            if (@param == null)
            {
                return NotFound();
            }

            return Ok(@param);
        }

        // PUT: api/Params/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParam([FromRoute] int id, [FromBody] Param @param)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @param.Id)
            {
                return BadRequest();
            }

            _context.Entry(@param).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamExists(id))
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

        // POST: api/Params
        [HttpPost]
        public async Task<IActionResult> PostParam([FromBody] Param @param)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Params.Add(@param);
            _context.Entry(@param.Table).State = EntityState.Unchanged;
            _context.Entry(@param.Table.Type).State = EntityState.Unchanged;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParam", new { id = @param.Id }, @param);
        }

        // DELETE: api/Params/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @param = await _context.Params.FindAsync(id);
            if (@param == null)
            {
                return NotFound();
            }

            _context.Params.Remove(@param);
            await _context.SaveChangesAsync();

            return Ok(@param);
        }

        private bool ParamExists(int id)
        {
            return _context.Params.Any(e => e.Id == id);
        }
    }
}