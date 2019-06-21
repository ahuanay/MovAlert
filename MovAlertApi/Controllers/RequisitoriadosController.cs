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
    public class RequisitoriadosController : ApiController
    {
        private MovAlertBDModel db = new MovAlertBDModel();

        // GET: api/Requisitoriados
        public IQueryable<Requisitoriados> GetRequisitoriados()
        {
            return db.Requisitoriados;
        }

        // GET: api/Requisitoriados/5
        [ResponseType(typeof(Requisitoriados))]
        public async Task<IHttpActionResult> GetRequisitoriados(int id)
        {
            Requisitoriados requisitoriados = await db.Requisitoriados.FindAsync(id);
            if (requisitoriados == null)
            {
                return NotFound();
            }

            return Ok(requisitoriados);
        }

        // PUT: api/Requisitoriados/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRequisitoriados(int id, Requisitoriados requisitoriados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requisitoriados.IdRequisitoriado)
            {
                return BadRequest();
            }

            db.Entry(requisitoriados).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequisitoriadosExists(id))
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

        // POST: api/Requisitoriados
        [ResponseType(typeof(Requisitoriados))]
        public async Task<IHttpActionResult> PostRequisitoriados(Requisitoriados requisitoriados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Requisitoriados.Add(requisitoriados);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RequisitoriadosExists(requisitoriados.IdRequisitoriado))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = requisitoriados.IdRequisitoriado }, requisitoriados);
        }

        // DELETE: api/Requisitoriados/5
        [ResponseType(typeof(Requisitoriados))]
        public async Task<IHttpActionResult> DeleteRequisitoriados(int id)
        {
            Requisitoriados requisitoriados = await db.Requisitoriados.FindAsync(id);
            if (requisitoriados == null)
            {
                return NotFound();
            }

            db.Requisitoriados.Remove(requisitoriados);
            await db.SaveChangesAsync();

            return Ok(requisitoriados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequisitoriadosExists(int id)
        {
            return db.Requisitoriados.Count(e => e.IdRequisitoriado == id) > 0;
        }
    }
}