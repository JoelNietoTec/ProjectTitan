using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Financial;

namespace WebAPI.Controllers.Financial
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileProductsController : ControllerBase
    {
        private readonly FinancialContext _context;

        public ProfileProductsController(FinancialContext context)
        {
            _context = context;
        }

        // GET: api/ProfileProducts
        [HttpGet]
        public IEnumerable<ProfileProduct> GetProfileProducts()
        {
            return _context.ProfileProducts;
        }

        // GET: api/ProfileProducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profileProduct = await _context.ProfileProducts.FindAsync(id);

            if (profileProduct == null)
            {
                return NotFound();
            }

            return Ok(profileProduct);
        }

        // PUT: api/ProfileProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfileProduct([FromRoute] int id, [FromBody] ProfileProduct profileProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profileProduct.ID)
            {
                return BadRequest();
            }

            _context.Entry(profileProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileProductExists(id))
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

        // POST: api/ProfileProducts
        [HttpPost]
        public async Task<IActionResult> PostProfileProduct([FromBody] ProfileProduct profileProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProfileProducts.Add(profileProduct);
            _context.Entry(profileProduct.FinancialProduct).State = EntityState.Unchanged;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfileProduct", new { id = profileProduct.ID }, profileProduct);
        }

        // DELETE: api/ProfileProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfileProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profileProduct = await _context.ProfileProducts.FindAsync(id);
            if (profileProduct == null)
            {
                return NotFound();
            }

            _context.ProfileProducts.Remove(profileProduct);
            await _context.SaveChangesAsync();

            return Ok(profileProduct);
        }

        private bool ProfileProductExists(int id)
        {
            return _context.ProfileProducts.Any(e => e.ID == id);
        }
    }
}