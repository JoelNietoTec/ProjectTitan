using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Participants;

namespace TitanWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net", headers: "*", methods: "*")]
    public class DocumentTypesController : ApiController
    {
        private ParticipantsModel db = new ParticipantsModel();

        // GET: api/DocumentTypes
        public IQueryable<DocumentType> GetDocumentTypes()
        {
            return db.DocumentTypes;
        }

        // GET: api/DocumentTypes/5
        [ResponseType(typeof(DocumentType))]
        public IHttpActionResult GetDocumentType(int id)
        {
            DocumentType documentType = db.DocumentTypes.Find(id);
            if (documentType == null)
            {
                return NotFound();
            }

            return Ok(documentType);
        }

        // PUT: api/DocumentTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDocumentType(int id, DocumentType documentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentType.ID)
            {
                return BadRequest();
            }

            db.Entry(documentType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DocumentTypes
        [ResponseType(typeof(DocumentType))]
        public IHttpActionResult PostDocumentType(DocumentType documentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DocumentTypes.Add(documentType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = documentType.ID }, documentType);
        }

        // DELETE: api/DocumentTypes/5
        [ResponseType(typeof(DocumentType))]
        public IHttpActionResult DeleteDocumentType(int id)
        {
            DocumentType documentType = db.DocumentTypes.Find(id);
            if (documentType == null)
            {
                return NotFound();
            }

            db.DocumentTypes.Remove(documentType);
            db.SaveChanges();

            return Ok(documentType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentTypeExists(int id)
        {
            return db.DocumentTypes.Count(e => e.ID == id) > 0;
        }
    }
}