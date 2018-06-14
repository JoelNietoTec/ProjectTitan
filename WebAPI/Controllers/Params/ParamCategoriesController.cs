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
    public class ParamCategoriesController : ControllerBase
    {
        private readonly ParamsContext _context;

        public ParamCategoriesController(ParamsContext context)
        {
            _context = context;
        }

        // GET: api/ParamCategories
        [HttpGet]
        public IEnumerable<ParamCategory> GetParamCategories()
        {
            return _context.ParamCategories;
        }

        // GET: api/ParamCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParamCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paramCategory = await _context.ParamCategories.FindAsync(id);

            if (paramCategory == null)
            {
                return NotFound();
            }

            return Ok(paramCategory);
        }

        // PUT: api/ParamCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParamCategory([FromRoute] int id, [FromBody] ParamCategory paramCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paramCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(paramCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamCategoryExists(id))
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

        // POST: api/ParamCategories
        [HttpPost]
        public async Task<IActionResult> PostParamCategory([FromBody] ParamCategory paramCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ParamCategories.Add(paramCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParamCategory", new { id = paramCategory.Id }, paramCategory);
        }

        // DELETE: api/ParamCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParamCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paramCategory = await _context.ParamCategories.FindAsync(id);
            if (paramCategory == null)
            {
                return NotFound();
            }

            _context.ParamCategories.Remove(paramCategory);
            await _context.SaveChangesAsync();

            return Ok(paramCategory);
        }

        private bool ParamCategoryExists(int id)
        {
            return _context.ParamCategories.Any(e => e.Id == id);
        }
    }
}