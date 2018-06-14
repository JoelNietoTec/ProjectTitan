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
    public class ParamValuesController : ControllerBase
    {
        private readonly ParamContext _context;

        public ParamValuesController(ParamContext context)
        {
            _context = context;
        }

        // GET: api/ParamValues
        [HttpGet]
        public IEnumerable<ParamValue> GetParamValues()
        {
            return _context.ParamValues;
        }

        // GET: api/ParamValues/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParamValue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paramValue = await _context.ParamValues.FindAsync(id);

            if (paramValue == null)
            {
                return NotFound();
            }

            return Ok(paramValue);
        }

        // PUT: api/ParamValues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParamValue([FromRoute] int id, [FromBody] ParamValue paramValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paramValue.Id)
            {
                return BadRequest();
            }

            _context.Entry(paramValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamValueExists(id))
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

        // POST: api/ParamValues
        [HttpPost]
        public async Task<IActionResult> PostParamValue([FromBody] ParamValue paramValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ParamValues.Add(paramValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParamValue", new { id = paramValue.Id }, paramValue);
        }

        // DELETE: api/ParamValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParamValue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paramValue = await _context.ParamValues.FindAsync(id);
            if (paramValue == null)
            {
                return NotFound();
            }

            _context.ParamValues.Remove(paramValue);
            await _context.SaveChangesAsync();

            return Ok(paramValue);
        }

        private bool ParamValueExists(int id)
        {
            return _context.ParamValues.Any(e => e.Id == id);
        }
    }
}