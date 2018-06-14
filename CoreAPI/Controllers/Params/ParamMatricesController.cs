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
    public class ParamMatricesController : ControllerBase
    {
        private readonly ParamContext _context;

        public ParamMatricesController(ParamContext context)
        {
            _context = context;
        }

        // GET: api/ParamMatrices
        [HttpGet]
        public IEnumerable<ParamMatrix> GetParamMatrices()
        {
            return _context.ParamMatrices;
        }

        [HttpGet("{id}/categories")]
        public IEnumerable<ParamCategory> GetParamCategories([FromRoute] int id)
        {
            return _context.ParamCategories.Where(x => x.ParamMatrixId == id);
        }

        // GET: api/ParamMatrices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParamMatrix([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paramMatrix = await _context.ParamMatrices.FindAsync(id);

            if (paramMatrix == null)
            {
                return NotFound();
            }

            return Ok(paramMatrix);
        }

        // PUT: api/ParamMatrices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParamMatrix([FromRoute] int id, [FromBody] ParamMatrix paramMatrix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paramMatrix.Id)
            {
                return BadRequest();
            }

            _context.Entry(paramMatrix).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamMatrixExists(id))
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

        // POST: api/ParamMatrices
        [HttpPost]
        public async Task<IActionResult> PostParamMatrix([FromBody] ParamMatrix paramMatrix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ParamMatrices.Add(paramMatrix);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParamMatrix", new { id = paramMatrix.Id }, paramMatrix);
        }

        // DELETE: api/ParamMatrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParamMatrix([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paramMatrix = await _context.ParamMatrices.FindAsync(id);
            if (paramMatrix == null)
            {
                return NotFound();
            }

            _context.ParamMatrices.Remove(paramMatrix);
            await _context.SaveChangesAsync();

            return Ok(paramMatrix);
        }

        private bool ParamMatrixExists(int id)
        {
            return _context.ParamMatrices.Any(e => e.Id == id);
        }
    }
}