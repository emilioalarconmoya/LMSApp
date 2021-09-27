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
    public class UnidadsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Unidads
        public IQueryable<Unidad> GetUnidads()
        {
            return db.Unidads;
        }

        // GET: api/Unidads/5
        [ResponseType(typeof(Unidad))]
        public async Task<IHttpActionResult> GetUnidad(int id)
        {
            Unidad unidad = await db.Unidads.FindAsync(id);
            if (unidad == null)
            {
                return NotFound();
            }

            return Ok(unidad);
        }

        // PUT: api/Unidads/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnidad(int id, Unidad unidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unidad.CodUnidad)
            {
                return BadRequest();
            }

            db.Entry(unidad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadExists(id))
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

        // POST: api/Unidads
        [ResponseType(typeof(Unidad))]
        public async Task<IHttpActionResult> PostUnidad(Unidad unidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Unidads.Add(unidad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = unidad.CodUnidad }, unidad);
        }

        // DELETE: api/Unidads/5
        [ResponseType(typeof(Unidad))]
        public async Task<IHttpActionResult> DeleteUnidad(int id)
        {
            Unidad unidad = await db.Unidads.FindAsync(id);
            if (unidad == null)
            {
                return NotFound();
            }

            db.Unidads.Remove(unidad);
            await db.SaveChangesAsync();

            return Ok(unidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnidadExists(int id)
        {
            return db.Unidads.Count(e => e.CodUnidad == id) > 0;
        }
    }
}