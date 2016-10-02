using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectIdea.Models;

namespace ProjectIdea.Controllers
{
    [Authorize]
    public class IncidentsController : ApiController
    {
        private ProjectIdeaContext db = new ProjectIdeaContext();

        // GET: api/Incidents
        public IQueryable<Incident> GetIncidents()
        {
            return db.Incidents;
        }

        // GET: api/Incidents/5
        [ResponseType(typeof(Incident))]
        public IHttpActionResult GetIncident(int id)
        {
            Incident incident = db.Incidents.Find(id);
            if (incident == null)
            {
                return NotFound();
            }

            return Ok(incident);
        }

        // PUT: api/Incidents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncident(int id, Incident incident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != incident.Id)
            {
                return BadRequest();
            }

            db.Entry(incident).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentExists(id))
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

        // POST: api/Incidents
        [ResponseType(typeof(Incident))]
        public IHttpActionResult PostIncident(Incident incident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Incidents.Add(incident);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = incident.Id }, incident);
        }

        // DELETE: api/Incidents/5
        [ResponseType(typeof(Incident))]
        public IHttpActionResult DeleteIncident(int id)
        {
            Incident incident = db.Incidents.Find(id);
            if (incident == null)
            {
                return NotFound();
            }

            db.Incidents.Remove(incident);
            db.SaveChanges();

            return Ok(incident);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IncidentExists(int id)
        {
            return db.Incidents.Count(e => e.Id == id) > 0;
        }
    }
}