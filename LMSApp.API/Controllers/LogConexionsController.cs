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
    public class LogConexionsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/LogConexions
        public IQueryable<LogConexion> GetLogConexions()
        {
            return db.LogConexions;
        }

        // GET: api/LogConexions/5
        [ResponseType(typeof(LogConexion))]
        public async Task<IHttpActionResult> GetLogConexion(int id)
        {
            LogConexion logConexion = await db.LogConexions.FindAsync(id);
            if (logConexion == null)
            {
                return NotFound();
            }

            return Ok(logConexion);
        }

        // PUT: api/LogConexions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLogConexion(int id, LogConexion logConexion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logConexion.CodActividadUsuario)
            {
                return BadRequest();
            }

            db.Entry(logConexion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogConexionExists(id))
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

        // POST: api/LogConexions
        [ResponseType(typeof(LogConexion))]
        public async Task<IHttpActionResult> PostLogConexion(LogConexion logConexion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LogConexions.Add(logConexion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = logConexion.CodActividadUsuario }, logConexion);
        }

        // DELETE: api/LogConexions/5
        [ResponseType(typeof(LogConexion))]
        public async Task<IHttpActionResult> DeleteLogConexion(int id)
        {
            LogConexion logConexion = await db.LogConexions.FindAsync(id);
            if (logConexion == null)
            {
                return NotFound();
            }

            db.LogConexions.Remove(logConexion);
            await db.SaveChangesAsync();

            return Ok(logConexion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LogConexionExists(int id)
        {
            return db.LogConexions.Count(e => e.CodActividadUsuario == id) > 0;
        }
    }
}