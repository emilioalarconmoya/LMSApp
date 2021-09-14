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
    public class AlternativasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Alternativas
        public IQueryable<Alternativa> GetAlternativas(int codPregunta)
        {
            // return db.Alternativas;
            DLALTERNATIVAList dLALTERNATIVAList = new DLALTERNATIVAList();
            DataTable dataTable = dLALTERNATIVAList.AlternativasPreguntaApp(codPregunta);

            var importdata = from x in dataTable.AsEnumerable()
                             select new Alternativa()
                             {
                                 CodAlternativa = x.Field<int>("CodAlternativa"),
                                 CodPregunta = x.Field<int>("CodPregunta"),
                                 TextoAlternativa = x.Field<string>("TextoAlternativa"),
                                 EsCorrecta = x.Field<bool>("EsCorrecta"),
                                 TextoComentario = x.Field<string>("TextoComentario"),
                                 PuntajeMax = x.Field<int>("PuntajeMax"),
                             };

            return importdata.AsQueryable();


        }

        // GET: api/Alternativas/5
        [ResponseType(typeof(Alternativa))]
        public async Task<IHttpActionResult> GetAlternativa(int id)
        {
            Alternativa alternativa = await db.Alternativas.FindAsync(id);
            if (alternativa == null)
            {
                return NotFound();
            }

            return Ok(alternativa);
        }

        // PUT: api/Alternativas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlternativa(int id, Alternativa alternativa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alternativa.CodAlternativa)
            {
                return BadRequest();
            }

            db.Entry(alternativa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlternativaExists(id))
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

        // POST: api/Alternativas
        [ResponseType(typeof(Alternativa))]
        public async Task<IHttpActionResult> PostAlternativa(Alternativa alternativa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alternativas.Add(alternativa);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = alternativa.CodAlternativa }, alternativa);
        }

        // DELETE: api/Alternativas/5
        [ResponseType(typeof(Alternativa))]
        public async Task<IHttpActionResult> DeleteAlternativa(int id)
        {
            Alternativa alternativa = await db.Alternativas.FindAsync(id);
            if (alternativa == null)
            {
                return NotFound();
            }

            db.Alternativas.Remove(alternativa);
            await db.SaveChangesAsync();

            return Ok(alternativa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlternativaExists(int id)
        {
            return db.Alternativas.Count(e => e.CodAlternativa == id) > 0;
        }
    }
}