﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Participants;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
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

        [HttpGet]
        [Route("api/participantdocuments/expired")]
        public IQueryable<ParticipantDocument> GetExpiredDocuments()
        {
            return db.ParticipantDocuments.Where(x => x.ExpirationDate <= DateTime.Today);
        }

        [HttpGet]
        [Route("api/participants/{id}/documents")]
        public IQueryable<ParticipantDocument> GetDocumentsByParticipant(int id)
        {
            return db.ParticipantDocuments.Where(x => x.ParticipantID == id);
        }

        [HttpPost]
        [Route("api/documents")]
        public HttpResponseMessage UploadFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/Files/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                }
            }
            return response;
        }


        // PUT: api/ParticipantsDocuments/5
        [ResponseType(typeof(ParticipantDocument))]
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

            participantsDocument.DocumentType = null;
            participantsDocument.Country = null;

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

            db.Entry(participantsDocument).Reference(c => c.Country).Load();
            db.Entry(participantsDocument).Reference(t => t.DocumentType).Load();

            return Ok(participantsDocument);
        }

        // POST: api/ParticipantsDocuments
        [ResponseType(typeof(ParticipantDocument))]
        public IHttpActionResult PostParticipantsDocument(ParticipantDocument participantsDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            participantsDocument.DocumentType = null;
            participantsDocument.Country = null;
            db.ParticipantDocuments.Add(participantsDocument);
            db.SaveChanges();

            db.Entry(participantsDocument).Reference(c => c.Country).Load();
            db.Entry(participantsDocument).Reference(t => t.DocumentType).Load();

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