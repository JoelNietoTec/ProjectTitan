using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Participants;

namespace TitanWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net", headers: "*", methods: "*")]
    public class ParticipantDocumentsController : ApiController
    {

        private ParticipantsModel db = new ParticipantsModel();

        // GET: api/ParticipantsDocuments
        public IQueryable<ParticipantDocument> GetParticipantsDocuments()
        {
            return db.ParticipantDocuments;
        }

        // GET: api/ParticipantsDocuments/5
        [ResponseType(typeof(ParticipantDocument))]
        public IHttpActionResult GetParticipantsDocument(int id)
        {
            ParticipantDocument participantsDocument = db.ParticipantDocuments.Find(id);
            if (participantsDocument == null)
            {
                return NotFound();
            }

            return Ok(participantsDocument);
        }

        // PUT: api/ParticipantsDocuments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParticipantsDocument(int id, ParticipantDocument participantsDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participantsDocument.ID)
            {
                return BadRequest();
            }

            db.Entry(participantsDocument).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantsDocumentExists(id))
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

        // POST: api/ParticipantsDocuments
        [ResponseType(typeof(ParticipantDocument))]
        public IHttpActionResult PostParticipantsDocument(ParticipantDocument participantsDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            participantsDocument.CountryID = participantsDocument.Country.ID;
            participantsDocument.DocumentTypeID = participantsDocument.DocumentType.ID;
            db.ParticipantDocuments.Add(participantsDocument);
            db.Entry(participantsDocument.Country).State = EntityState.Detached;
            db.Entry(participantsDocument.DocumentType).State = EntityState.Detached;
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = participantsDocument.ID }, participantsDocument);
        }

        // DELETE: api/ParticipantsDocuments/5
        [ResponseType(typeof(ParticipantDocument))]
        public IHttpActionResult DeleteParticipantsDocument(int id)
        {
            ParticipantDocument participantsDocument = db.ParticipantDocuments.Find(id);
            if (participantsDocument == null)
            {
                return NotFound();
            }

            db.ParticipantDocuments.Remove(participantsDocument);
            db.SaveChanges();

            return Ok(participantsDocument);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipantsDocumentExists(int id)
        {
            return db.ParticipantDocuments.Count(e => e.ID == id) > 0;
        }
    }
}