using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAPI.Models.Assignments;

namespace CoreAPI.Controllers.Assignments
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AssignmentTypesController : ControllerBase
    {
        private readonly AssignmentsContext _context;

        public AssignmentTypesController(AssignmentsContext context)
        {
            _context = context;
        }

        // GET: api/AssignmentTypes
        [HttpGet]
        public IEnumerable<AssignmentType> GetAssignmentTypes()
        {
            return _context.AssignmentTypes;
        }

        // GET: api/AssignmentTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignmentType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignmentType = await _context.AssignmentTypes.FindAsync(id);

            if (assignmentType == null)
            {
                return NotFound();
            }

            return Ok(assignmentType);
        }

        // PUT: api/AssignmentTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignmentType([FromRoute] int id, [FromBody] AssignmentType assignmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignmentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(assignmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentTypeExists(id))
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

        // POST: api/AssignmentTypes
        [HttpPost]
        public async Task<IActionResult> PostAssignmentType([FromBody] AssignmentType assignmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AssignmentTypes.Add(assignmentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignmentType", new { id = assignmentType.Id }, assignmentType);
        }

        // DELETE: api/AssignmentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignmentType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignmentType = await _context.AssignmentTypes.FindAsync(id);
            if (assignmentType == null)
            {
                return NotFound();
            }

            _context.AssignmentTypes.Remove(assignmentType);
            await _context.SaveChangesAsync();

            return Ok(assignmentType);
        }

        private bool AssignmentTypeExists(int id)
        {
            return _context.AssignmentTypes.Any(e => e.Id == id);
        }
    }
}