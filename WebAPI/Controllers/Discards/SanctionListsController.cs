using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Filters;
using WebAPI.Models.Discards;

namespace WebAPI.Controllers.Discards
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanctionListsController : ControllerBase
    {
        private readonly DiscardsContext _context;

        public SanctionListsController(DiscardsContext context)
        {
            _context = context;
        }
        [HttpGet("{id}/items")]
        public IEnumerable<SanctionedItem> GetItems([FromRoute] int id)
        {
            return _context.SanctionedItems.Where(x => x.ListId.Equals(id));
        }

        [HttpPost("load")]
        public async Task<IActionResult> UpdateList([FromBody] SanctionList list)
        {
            XmlDocument xdoc = new XmlDocument();
            int count = 0;

            xdoc.Load(list.Url);
            var param = new SqlParameter("@ListId", list.Id);
            _context.Database.ExecuteSqlCommand("dbo.DeleteSanctions @ListId", param);
            string[] elements = list.ElementIds.Split(',');

            foreach (string element in elements)
            {
                var nsmgr = new XmlNamespaceManager(xdoc.NameTable);
                nsmgr.AddNamespace("a", list.NameSpace);
                XmlNodeList nodeList = xdoc.SelectNodes(element, nsmgr);

                foreach (XmlNode node in nodeList)
                {
                    SanctionedItem item = new SanctionedItem();
                    item.ListId = list.Id;

                    string[] terms = list.TermField.Split(',');

                    if (0 < terms.Length && node.SelectSingleNode(terms[0], nsmgr) != null )
                    {
                        item.Term1 = node.SelectSingleNode(terms[0], nsmgr).InnerText;
                    }
                    if (1 < terms.Length && node.SelectSingleNode(terms[1], nsmgr) != null)
                    {
                        item.Term2 = node.SelectSingleNode(terms[1], nsmgr).InnerText;
                    }
                    if (2 < terms.Length && node.SelectSingleNode(terms[2], nsmgr) != null)
                    {
                        item.Term3 = node.SelectSingleNode(terms[2], nsmgr).InnerText;
                    }

                    if (3 < terms.Length && node.SelectSingleNode(terms[3], nsmgr) != null)
                    {
                        item.Term4 = node.SelectSingleNode(terms[3], nsmgr).InnerText;
                    }

                    if (node.SelectSingleNode(list.CommentsField, nsmgr) != null)
                    {
                        item.Comments = node.SelectSingleNode(list.CommentsField, nsmgr).InnerText;
                    }

                    if (node.SelectSingleNode(list.CountryField, nsmgr) != null)
                    {
                        item.Country = node.SelectSingleNode(list.CountryField, nsmgr).InnerText;
                    }
                    item.Date = DateTime.Now;
                    _context.SanctionedItems.Add(item);
                    _context.SaveChanges();
                    count++;
                }
            }
            list.LoadDate = DateTime.Now;
            _context.Entry(list).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(count);       
        }
        
        // GET: api/SanctionLists]
        [AlertActionFilter]
        [HttpGet]
        public IEnumerable<SanctionList> GetSanctionLists()
        {
            return _context.SanctionLists;
        }

        // GET: api/SanctionLists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSanctionLists([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sanctionLists = await _context.SanctionLists.FindAsync(id);

            if (sanctionLists == null)
            {
                return NotFound();
            }

            return Ok(sanctionLists);
        }

        // PUT: api/SanctionLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanctionLists([FromRoute] int id, [FromBody] SanctionList sanctionLists)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanctionLists.Id)
            {
                return BadRequest();
            }

            _context.Entry(sanctionLists).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanctionListsExists(id))
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

        // POST: api/SanctionLists
        [HttpPost]
        public async Task<IActionResult> PostSanctionLists([FromBody] SanctionList sanctionLists)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SanctionLists.Add(sanctionLists);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSanctionLists", new { id = sanctionLists.Id }, sanctionLists);
        }

        // DELETE: api/SanctionLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanctionLists([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sanctionLists = await _context.SanctionLists.FindAsync(id);
            if (sanctionLists == null)
            {
                return NotFound();
            }

            _context.SanctionLists.Remove(sanctionLists);
            await _context.SaveChangesAsync();

            return Ok(sanctionLists);
        }

        private bool SanctionListsExists(int id)
        {
            return _context.SanctionLists.Any(e => e.Id == id);
        }
    }
}