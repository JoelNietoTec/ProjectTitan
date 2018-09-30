using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Permissions;

namespace WebAPI.Controllers.Permissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly PermissionsContext _context;
        public AccountsController(PermissionsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts
                .Include(x => x.Plan);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            _context.Entry(account).Reference(x => x.Users).Load();
            return Ok(account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAccount([FromRoute] int id, [FromBody] Account Account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Account.Id)
            {
                return BadRequest();
            }

            _context.Entry(Account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(Account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] Account Account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();

            return Ok(Account);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndutry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Account = await _context.Accounts.FindAsync(id);
            if (Account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(Account);
            await _context.SaveChangesAsync();

            return Ok(Account);
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }

    }
}