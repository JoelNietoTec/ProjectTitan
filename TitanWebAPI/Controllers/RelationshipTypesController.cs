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
    public class RelationshipTypesController : ApiController
    {
        private ParticipantsModel db = new ParticipantsModel();

        // GET: api/RelationshipTypes
        public IQueryable<RelationshipType> GetRelationshipTypes()
        {
            return db.RelationshipTypes;
        }

        // GET: api/RelationshipTypes/5
        [ResponseType(typeof(RelationshipType))]
        public IHttpActionResult GetRelationshipType(int id)
        {
            RelationshipType relationshipType = db.RelationshipTypes.Find(id);
            if (relationshipType == null)
            {
                return NotFound();
            }

            return Ok(relationshipType);
        }

        // PUT: api/RelationshipTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRelationshipType(int id, RelationshipType relationshipType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != relationshipType.ID)
            {
                return BadRequest();
            }

            db.Entry(relationshipType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelationshipTypeExists(id))
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

        // POST: api/RelationshipTypes
        [ResponseType(typeof(RelationshipType))]
        public IHttpActionResult PostRelationshipType(RelationshipType relationshipType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RelationshipTypes.Add(relationshipType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = relationshipType.ID }, relationshipType);
        }

        // DELETE: api/RelationshipTypes/5
        [ResponseType(typeof(RelationshipType))]
        public IHttpActionResult DeleteRelationshipType(int id)
        {
            RelationshipType relationshipType = db.RelationshipTypes.Find(id);
            if (relationshipType == null)
            {
                return NotFound();
            }

            db.RelationshipTypes.Remove(relationshipType);
            db.SaveChanges();

            return Ok(relationshipType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RelationshipTypeExists(int id)
        {
            return db.RelationshipTypes.Count(e => e.ID == id) > 0;
        }
    }
}