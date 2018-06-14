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
    public class FinancialProductsController : ControllerBase
    {
        private readonly SettingsContext _context;

        public FinancialProductsController(SettingsContext context)
        {
            _context = context;
        }

        // GET: api/FinancialProducts
        [HttpGet]
        public IEnumerable<FinancialProduct> GetFinancialProducts()
        {
            return _context.FinancialProducts;
        }

        // GET: api/FinancialProducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFinancialProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var financialProduct = await _context.FinancialProducts.FindAsync(id);

            if (financialProduct == null)
            {
                return NotFound();
            }

            return Ok(financialProduct);
        }

        // PUT: api/FinancialProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialProduct([FromRoute] int id, [FromBody] FinancialProduct financialProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != financialProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(financialProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialProductExists(id))
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

        // POST: api/FinancialProducts
        [HttpPost]
        public async Task<IActionResult> PostFinancialProduct([FromBody] FinancialProduct financialProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FinancialProducts.Add(financialProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinancialProduct", new { id = financialProduct.Id }, financialProduct);
        }

        // DELETE: api/FinancialProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var financialProduct = await _context.FinancialProducts.FindAsync(id);
            if (financialProduct == null)
            {
                return NotFound();
            }

            _context.FinancialProducts.Remove(financialProduct);
            await _context.SaveChangesAsync();

            return Ok(financialProduct);
        }

        private bool FinancialProductExists(int id)
        {
            return _context.FinancialProducts.Any(e => e.Id == id);
        }
    }
}