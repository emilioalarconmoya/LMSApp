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
using ATENEUS.CLASES.DAL;
using LMSApp.Common.Models;
using LMSApp.Domain.Models;

namespace LMSApp.API.Controllers
{
    public class PreguntaUnidadsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/PreguntaUnidads
        public IQueryable<PreguntaUnidad> GetPreguntaUnidads(int codUnidad)
        {
            //return db.PreguntaUnidads;
            DLPREGUNTAUNIDADList dLPREGUNTAUNIDAD = new DLPREGUNTAUNIDADList();
            DataTable dataTable = dLPREGUNTAUNIDAD.PreguntasUnidadApp(codUnidad);
            //DLPREGUNTA dLPREGUNTA = new DLPREGUNTA();

            var importdata = from x in dataTable.AsEnumerable()
                             select new PreguntaUnidad()
                             {
                                 CodPregunta = x.Field<int>("CodPregunta"),
                                 CodUnidad = x.Field<int>("CodUnidad"),
                                 PuntajeMax = x.Field<int>("PuntajeMax"),
                                 Imagen = x.Field<string>("Imagen"),
                                 Ancho = x.Field<string>("Ancho"),
                                 Alto = x.Field<string>("Alto"),
                                 Link = x.Field<string>("Link"),
                                 UrlVideo = x.Field<string>("UrlVideo"),
                             };

            return importdata.AsQueryable();
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