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
    public class PreguntaEvaluadasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/PreguntaEvaluadas
        public IQueryable<PreguntaEvaluada> GetPreguntaEvaluadas(int codUnidad, int codActividadUsaurio, int codEmpresa)
        {
            //return db.PreguntaEvaluadas;
            DLPREGUNTAUNIDADList dLPREGUNTAUNIDAD = new DLPREGUNTAUNIDADList();
            DataTable dataTable = dLPREGUNTAUNIDAD.PreguntasEvaluadasApp(codUnidad, codActividadUsaurio, codEmpresa);
            //DLPREGUNTA dLPREGUNTA = new DLPREGUNTA();

            var importdata = from x in dataTable.AsEnumerable()
                             select new PreguntaEvaluada()
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

        // GET: api/PreguntaEvaluadas/5
        [ResponseType(typeof(PreguntaEvaluada))]
        public async Task<IHttpActionResult> GetPreguntaEvaluada(int id)
        {
            PreguntaEvaluada preguntaEvaluada = await db.PreguntaEvaluadas.FindAsync(id);
            if (preguntaEvaluada == null)
            {
                return NotFound();
            }

            return Ok(preguntaEvaluada);
        }

        // PUT: api/PreguntaEvaluadas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPreguntaEvaluada(int id, PreguntaEvaluada preguntaEvaluada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preguntaEvaluada.CodPregunta)
            {
                return BadRequest();
            }

            db.Entry(preguntaEvaluada).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntaEvaluadaExists(id))
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

        // POST: api/PreguntaEvaluadas
        [ResponseType(typeof(PreguntaEvaluada))]
        public async Task<IHttpActionResult> PostPreguntaEvaluada(PreguntaEvaluada preguntaEvaluada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PreguntaEvaluadas.Add(preguntaEvaluada);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = preguntaEvaluada.CodPregunta }, preguntaEvaluada);
        }

        // DELETE: api/PreguntaEvaluadas/5
        [ResponseType(typeof(PreguntaEvaluada))]
        public async Task<IHttpActionResult> DeletePreguntaEvaluada(int id)
        {
            PreguntaEvaluada preguntaEvaluada = await db.PreguntaEvaluadas.FindAsync(id);
            if (preguntaEvaluada == null)
            {
                return NotFound();
            }

            db.PreguntaEvaluadas.Remove(preguntaEvaluada);
            await db.SaveChangesAsync();

            return Ok(preguntaEvaluada);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PreguntaEvaluadaExists(int id)
        {
            return db.PreguntaEvaluadas.Count(e => e.CodPregunta == id) > 0;
        }
    }
}