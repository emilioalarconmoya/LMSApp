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
using ATENEUS.CLASES.DAL;

namespace LMSApp.API.Controllers
{
    public class PreguntasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Preguntas
        public IQueryable<Pregunta> GetPreguntas(int codPregunta)
        {
            //return db.Preguntas;
            DLPREGUNTA dLPREGUNTA = new DLPREGUNTA();
            DataTable dataTable = dLPREGUNTA.PreguntaUnidadApp(codPregunta);

            var importdata = from x in dataTable.AsEnumerable()
                             select new Pregunta()
                             {
                                 CodPregunta = x.Field<int>("CodPregunta"),
                                 CodTipoPregunta = x.Field<int>("CodTipoPregunta"),
                                 Texto = x.Field<string>("Texto"),
                                 CodCorrecta = x.Field<int>("CodCorrecta"),
                             };

            return importdata.AsQueryable();
        }

        // GET: api/Preguntas/5
        [ResponseType(typeof(Pregunta))]
        public async Task<IHttpActionResult> GetPregunta(int id)
        {
            Pregunta pregunta = await db.Preguntas.FindAsync(id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return Ok(pregunta);
        }

        // PUT: api/Preguntas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPregunta(int id, Pregunta pregunta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pregunta.CodPregunta)
            {
                return BadRequest();
            }

            db.Entry(pregunta).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntaExists(id))
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

        // POST: api/Preguntas
        [ResponseType(typeof(Pregunta))]
        public async Task<IHttpActionResult> PostPregunta(Pregunta pregunta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Preguntas.Add(pregunta);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pregunta.CodPregunta }, pregunta);
        }

        // DELETE: api/Preguntas/5
        [ResponseType(typeof(Pregunta))]
        public async Task<IHttpActionResult> DeletePregunta(int id)
        {
            Pregunta pregunta = await db.Preguntas.FindAsync(id);
            if (pregunta == null)
            {
                return NotFound();
            }

            db.Preguntas.Remove(pregunta);
            await db.SaveChangesAsync();

            return Ok(pregunta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PreguntaExists(int id)
        {
            return db.Preguntas.Count(e => e.CodPregunta == id) > 0;
        }
    }
}