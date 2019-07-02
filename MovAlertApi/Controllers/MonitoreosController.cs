using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MovAlertApi.Models;

namespace MovAlertApi.Controllers
{
    public class MonitoreosController : ApiController
    {
        private MovAlertBDModel db = new MovAlertBDModel();

        // GET: api/Monitoreos
        public IQueryable<Monitoreos> GetMonitoreos()
        {
            return db.Monitoreos;
        }

        // GET: api/Monitoreos/5
        [ResponseType(typeof(Monitoreos))]
        public async Task<IHttpActionResult> GetMonitoreos(int id)
        {
            Monitoreos monitoreos = await db.Monitoreos.FindAsync(id);
            if (monitoreos == null)
            {
                return NotFound();
            }

            return Ok(monitoreos);
        }

        // PUT: api/Monitoreos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMonitoreos(int id, Monitoreos monitoreos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monitoreos.IdMonitoreo)
            {
                return BadRequest();
            }

            db.Entry(monitoreos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitoreosExists(id))
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

        // POST: api/Monitoreos
        [ResponseType(typeof(Monitoreos))]
        public async Task<IHttpActionResult> PostMonitoreos(Monitoreos monitoreos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Monitoreos.Add(monitoreos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = monitoreos.IdMonitoreo }, monitoreos);
        }

        // DELETE: api/Monitoreos/5
        [ResponseType(typeof(Monitoreos))]
        public async Task<IHttpActionResult> DeleteMonitoreos(int id)
        {
            Monitoreos monitoreos = await db.Monitoreos.FindAsync(id);
            if (monitoreos == null)
            {
                return NotFound();
            }

            db.Monitoreos.Remove(monitoreos);
            await db.SaveChangesAsync();

            return Ok(monitoreos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonitoreosExists(int id)
        {
            return db.Monitoreos.Count(e => e.IdMonitoreo == id) > 0;
        }
    }
}