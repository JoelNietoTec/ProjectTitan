using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAPI.Models.Params;

namespace CoreAPI.Controllers.Params
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ParamSubValuesController : ControllerBase
    {
        private readonly ParamContext _context;

        public ParamSubValuesController(ParamContext context)
        {
            _context = context;
        }

        // GET: api/ParamSubValues
        [HttpGet]
        public IEnumerable<ParamSubValue> GetParamSubValues()
        {
            return _context.ParamSubValues;
        }

        // GET: api/ParamSubValues/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParamSubValue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paramSubValue = await _context.ParamSubValues.FindAsync(id);

            if (paramSubValue == null)
            {
                return NotFound();
            }

            return Ok(paramSubValue);
        }

        // PUT: api/ParamSubValues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParamSubValue([FromRoute] int id, [FromBody] ParamSubValue paramSubValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paramSubValue.Id)
            {
                return BadRequest();
            }

            _context.Entry(paramSubValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamSubValueExists(id))
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

        // POST: api/ParamSubValues
        [HttpPost]
        public async Task<IActionResult> PostParamSubValue([FromBody] ParamSubValue paramSubValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ParamSubValues.Add(paramSubValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParamSubValue", new { id = paramSubValue.Id }, paramSubValue);
        }

        // DELETE: api/ParamSubValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParamSubValue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paramSubValue = await _context.ParamSubValues.FindAsync(id);
            if (paramSubValue == null)
            {
                return NotFound();
            }

            _context.ParamSubValues.Remove(paramSubValue);
            await _context.SaveChangesAsync();

            return Ok(paramSubValue);
        }

        private bool ParamSubValueExists(int id)
        {
            return _context.ParamSubValues.Any(e => e.Id == id);
        }
    }
}