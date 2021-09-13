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
using LMSApp.Common.Models;
using LMSApp.Domain.Models;

namespace LMSApp.API.Controllers
{
    public class PreguntaUnidadsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/PreguntaUnidads
        public IQueryable<PreguntaUnidad> GetPreguntaUnidads()
        {
            return db.PreguntaUnidads;
        }

        // GET: api/PreguntaUnidads/5
        [ResponseType(typeof(PreguntaUnidad))]
        public async Task<IHttpActionResult> GetPreguntaUnidad(int id)
        {
            PreguntaUnidad preguntaUnidad = await db.PreguntaUnidads.FindAsync(id);
            if (preguntaUnidad == null)
            {
                return NotFound();
            }

            return Ok(preguntaUnidad);
        }

        // PUT: api/PreguntaUnidads/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPreguntaUnidad(int id, PreguntaUnidad preguntaUnidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preguntaUnidad.CodPregunta)
            {
                return BadRequest();
            }

            db.Entry(preguntaUnidad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntaUnidadExists(id))
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

        // POST: api/PreguntaUnidads
        [ResponseType(typeof(PreguntaUnidad))]
        public async Task<IHttpActionResult> PostPreguntaUnidad(PreguntaUnidad preguntaUnidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PreguntaUnidads.Add(preguntaUnidad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = preguntaUnidad.CodPregunta }, preguntaUnidad);
        }

        // DELETE: api/PreguntaUnidads/5
        [ResponseType(typeof(PreguntaUnidad))]
        public async Task<IHttpActionResult> DeletePreguntaUnidad(int id)
        {
            PreguntaUnidad preguntaUnidad = await db.PreguntaUnidads.FindAsync(id);
            if (preguntaUnidad == null)
            {
                return NotFound();
            }

            db.PreguntaUnidads.Remove(preguntaUnidad);
            await db.SaveChangesAsync();

            return Ok(preguntaUnidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PreguntaUnidadExists(int id)
        {
            return db.PreguntaUnidads.Count(e => e.CodPregunta == id) > 0;
        }
    }
}