 using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Xml;
using TitanWebAPI.Models.Sanctions;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class SanctionListsController : ApiController
    {
        private SanctionsModel db = new SanctionsModel();

        // GET: api/SanctionLists
        public IQueryable<SanctionList> GetSanctionLists()
        {
            return db.SanctionLists;
        }

        [HttpPost]
        [Route("api/sanctionlists/load")]
        public IHttpActionResult UpdateList(SanctionList list)
        {
            XmlDocument xdoc = new XmlDocument();
            int count = 0;
            
            xdoc.Load(list.URL);
            var param = new SqlParameter("@ListID", list.ID);

            db.Database.ExecuteSqlCommand("dbo.DeleteSanctions @ListID", param);

            string[] elements = list.ElementIDs.Split(',');

            foreach (string element in elements)
            {
                var nsmgr = new XmlNamespaceManager(xdoc.NameTable);
                nsmgr.AddNamespace("a", list.NameSpace);
                XmlNodeList xnodeLst = xdoc.SelectNodes(element, nsmgr);

                foreach (XmlNode node in xnodeLst)
                {
                    SanctionedItem sanction = new SanctionedItem();
                    sanction.ListID = list.ID;

                    string[] terms = list.TermField.Split(',');

                    if (0 < terms.Length && node.SelectSingleNode(terms[0], nsmgr) != null)
                    {
                        sanction.Term1 = node.SelectSingleNode(terms[0], nsmgr).InnerText;
                    }
                    if (1 < terms.Length && node.SelectSingleNode(terms[1], nsmgr) != null)
                    {
                        sanction.Term2 = node.SelectSingleNode(terms[1], nsmgr).InnerText;
                    }
                    if (2 < terms.Length && node.SelectSingleNode(terms[2], nsmgr) != null)
                    {
                        sanction.Term3 = node.SelectSingleNode(terms[2], nsmgr).InnerText;
                    }

                    if (3 < terms.Length && node.SelectSingleNode(terms[3], nsmgr) != null)
                    {
                        sanction.Term4 = node.SelectSingleNode(terms[3], nsmgr).InnerText;
                    }

                    if (node.SelectSingleNode(list.CommentsField, nsmgr) != null)
                    {
                        sanction.Comments = node.SelectSingleNode(list.CommentsField, nsmgr).InnerText;
                    }

                    if (node.SelectSingleNode(list.CountryField, nsmgr) != null)
                    {
                        sanction.Country = node.SelectSingleNode(list.CountryField, nsmgr).InnerText;
                    }

                    sanction.Date = DateTime.Now;
                    db.SanctionedItems.Add(sanction);
                    db.SaveChanges();
                    count++;
                }
            }
            list.LoadDate = DateTime.Now;
            db.Entry(list).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(count);
        }

        // GET: api/SanctionLists/5
        [ResponseType(typeof(SanctionList))]
        public IHttpActionResult GetSanctionList(int id)
        {
            SanctionList sanctionList = db.SanctionLists.Find(id);
            if (sanctionList == null)
            {
                return NotFound();
            }

            return Ok(sanctionList);
        }

        // PUT: api/SanctionLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSanctionList(int id, SanctionList sanctionList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanctionList.ID)
            {
                return BadRequest();
            }

            db.Entry(sanctionList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanctionListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SanctionLists
        [ResponseType(typeof(SanctionList))]
        public IHttpActionResult PostSanctionList(SanctionList sanctionList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SanctionLists.Add(sanctionList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sanctionList.ID }, sanctionList);
        }

        // DELETE: api/SanctionLists/5
        [ResponseType(typeof(SanctionList))]
        public IHttpActionResult DeleteSanctionList(int id)
        {
            SanctionList sanctionList = db.SanctionLists.Find(id);
            if (sanctionList == null)
            {
                return NotFound();
            }

            db.SanctionLists.Remove(sanctionList);
            db.SaveChanges();

            return Ok(sanctionList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SanctionListExists(int id)
        {
            return db.SanctionLists.Count(e => e.ID == id) > 0;
        }
    }
}