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
    public class DocumentTypesController : ControllerBase
    {
        private readonly SettingsContext _context;

        public DocumentTypesController(SettingsContext context)
        {
            _context = context;
        }

        // GET: api/DocumentTypes
        [HttpGet]
        public IEnumerable<DocumentType> GetDocumentTypes()
        {
            return _context.DocumentTypes;
        }

        [HttpGet("type/{id}")]
        public IEnumerable<DocumentType> GetDocumentByType([FromRoute] int id)
        {
            if (id == 1)
            {
                return _context.DocumentTypes.Where(x => x.RequiredIndividual == true);
            }
            else if (id == 2)
            {
                return _context.DocumentTypes.Where(x => x.RequiredEntity == true);
            } else
            {
                return _context.DocumentTypes;
            }

        }

        // GET: api/DocumentTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documentType = await _context.DocumentTypes.FindAsync(id);

            if (documentType == null)
            {
                return NotFound();
            }

            return Ok(documentType);
        }

        // PUT: api/DocumentTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentType([FromRoute] int id, [FromBody] DocumentType documentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(documentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentTypeExists(id))
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

        // POST: api/DocumentTypes
        [HttpPost]
        public async Task<IActionResult> PostDocumentType([FromBody] DocumentType documentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DocumentTypes.Add(documentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocumentType", new { id = documentType.Id }, documentType);
        }

        // DELETE: api/DocumentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documentType = await _context.DocumentTypes.FindAsync(id);
            if (documentType == null)
            {
                return NotFound();
            }

            _context.DocumentTypes.Remove(documentType);
            await _context.SaveChangesAsync();

            return Ok(documentType);
        }

        private bool DocumentTypeExists(int id)
        {
            return _context.DocumentTypes.Any(e => e.Id == id);
        }
    }
}