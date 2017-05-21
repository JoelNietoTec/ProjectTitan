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
using TitanWebAPI.Models.Individuals;

namespace TitanWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class IndividualsController : ApiController
    {
        private IndividualsModel db = new IndividualsModel();

        // GET: api/Individuals
        public IQueryable<Individual> GetIndividuals()
        {
            return db.Individuals;
        }

        // GET: api/Individuals/5
        [ResponseType(typeof(Individual))]
        public IHttpActionResult GetIndividual(int id)
        {
            Individual individual = db.Individuals.Find(id);
            if (individual == null)
            {
                return NotFound();
            }

            return Ok(individual);
        }

        // PUT: api/Individuals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIndividual(int id, Individual individual)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != individual.ID)
            {
                return BadRequest();
            }

            db.Entry(individual).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndividualExists(id))
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

        // POST: api/Individuals
        [ResponseType(typeof(Individual))]
        public IHttpActionResult PostIndividual(Individual individual)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Individuals.Add(individual);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = individual.ID }, individual);
        }

        // DELETE: api/Individuals/5
        [ResponseType(typeof(Individual))]
        public IHttpActionResult DeleteIndividual(int id)
        {
            Individual individual = db.Individuals.Find(id);
            if (individual == null)
            {
                return NotFound();
            }

            db.Individuals.Remove(individual);
            db.SaveChanges();

            return Ok(individual);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IndividualExists(int id)
        {
            return db.Individuals.Count(e => e.ID == id) > 0;
        }
    }
}