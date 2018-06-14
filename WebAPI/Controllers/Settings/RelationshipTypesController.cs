using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Settings;

namespace WebAPI.Controllers.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipTypesController : ControllerBase
    {
        private readonly SettingsContext _context;

        public RelationshipTypesController(SettingsContext context)
        {
            _context = context;
        }

        // GET: api/RelationshipTypes
        [HttpGet]
        public IEnumerable<RelationshipTypes> GetRelationshipTypes()
        {
            return _context.RelationshipTypes;
        }

        // GET: api/RelationshipTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRelationshipTypes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var relationshipTypes = await _context.RelationshipTypes.FindAsync(id);

            if (relationshipTypes == null)
            {
                return NotFound();
            }

            return Ok(relationshipTypes);
        }

        // PUT: api/RelationshipTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelationshipTypes([FromRoute] int id, [FromBody] RelationshipTypes relationshipTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != relationshipTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(relationshipTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelationshipTypesExists(id))
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

        // POST: api/RelationshipTypes
        [HttpPost]
        public async Task<IActionResult> PostRelationshipTypes([FromBody] RelationshipTypes relationshipTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RelationshipTypes.Add(relationshipTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRelationshipTypes", new { id = relationshipTypes.Id }, relationshipTypes);
        }

        // DELETE: api/RelationshipTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelationshipTypes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var relationshipTypes = await _context.RelationshipTypes.FindAsync(id);
            if (relationshipTypes == null)
            {
                return NotFound();
            }

            _context.RelationshipTypes.Remove(relationshipTypes);
            await _context.SaveChangesAsync();

            return Ok(relationshipTypes);
        }

        private bool RelationshipTypesExists(int id)
        {
            return _context.RelationshipTypes.Any(e => e.Id == id);
        }
    }
}