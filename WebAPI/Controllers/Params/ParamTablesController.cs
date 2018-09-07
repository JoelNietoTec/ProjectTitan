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
    public class ParamTablesController : ControllerBase
    {
        private readonly ParamsContext _context;

        public ParamTablesController(ParamsContext context)
        {
            _context = context;
        }

        // GET: api/ParamTables
        [HttpGet]
        public IEnumerable<ParamTable> GetParamTables()
        {
            return _context.ParamTables;
        }

        [HttpGet("{id}/values")]
        public IEnumerable<ParamValue> GetValues([FromRoute] int id)
        {
            return _context.ParamValues.Where(x => x.ParamTableId.Equals(id));
        }

        // GET: api/ParamTables/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParamTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paramTable = await _context.ParamTables.FindAsync(id);

            if (paramTable == null)
            {
                return NotFound();
            }

            return Ok(paramTable);
        }

        // PUT: api/ParamTables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParamTable([FromRoute] int id, [FromBody] ParamTable paramTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paramTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(paramTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamTableExists(id))
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

        // POST: api/ParamTables
        [HttpPost]
        public async Task<IActionResult> PostParamTable([FromBody] ParamTable paramTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            paramTable.CreateDate = DateTime.Now;

            _context.ParamTables.Add(paramTable);
            _context.Entry(paramTable.Type).State = EntityState.Unchanged;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParamTable", new { id = paramTable.Id }, paramTable);
        }

        // DELETE: api/ParamTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParamTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paramTable = await _context.ParamTables.FindAsync(id);
            if (paramTable == null)
            {
                return NotFound();
            }

            _context.ParamTables.Remove(paramTable);
            await _context.SaveChangesAsync();

            return Ok(paramTable);
        }

        private bool ParamTableExists(int id)
        {
            return _context.ParamTables.Any(e => e.Id == id);
        }
    }
}