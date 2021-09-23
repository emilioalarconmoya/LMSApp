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
    public class RespuestaCorrectasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/RespuestaCorrectas
        public IQueryable<RespuestaCorrecta> GetRespuestaCorrectas(int codPregunta)
        {
            //return db.RespuestaCorrectas;
            DLPREGUNTA dLPREGUNTA = new DLPREGUNTA();
            DataTable dataTable = dLPREGUNTA.RespuestaCorrectaDataTable(codPregunta);

            var importdata = from x in dataTable.AsEnumerable()
                             select new RespuestaCorrecta()
                             {
                                 CodCorrecta = x.Field<int>("cod_correcta"),
                             };

            return importdata.AsQueryable();
        }
    

        // GET: api/RespuestaCorrectas/5
        [ResponseType(typeof(RespuestaCorrecta))]
        public async Task<IHttpActionResult> GetRespuestaCorrecta(int id)
        {
            RespuestaCorrecta respuestaCorrecta = await db.RespuestaCorrectas.FindAsync(id);
            if (respuestaCorrecta == null)
            {
                return NotFound();
            }

            return Ok(respuestaCorrecta);
        }

        // PUT: api/RespuestaCorrectas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRespuestaCorrecta(int id, RespuestaCorrecta respuestaCorrecta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != respuestaCorrecta.CodCorrecta)
            {
                return BadRequest();
            }

            db.Entry(respuestaCorrecta).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RespuestaCorrectaExists(id))
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

        // POST: api/RespuestaCorrectas
        [ResponseType(typeof(RespuestaCorrecta))]
        public async Task<IHttpActionResult> PostRespuestaCorrecta(RespuestaCorrecta respuestaCorrecta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RespuestaCorrectas.Add(respuestaCorrecta);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = respuestaCorrecta.CodCorrecta }, respuestaCorrecta);
        }

        // DELETE: api/RespuestaCorrectas/5
        [ResponseType(typeof(RespuestaCorrecta))]
        public async Task<IHttpActionResult> DeleteRespuestaCorrecta(int id)
        {
            RespuestaCorrecta respuestaCorrecta = await db.RespuestaCorrectas.FindAsync(id);
            if (respuestaCorrecta == null)
            {
                return NotFound();
            }

            db.RespuestaCorrectas.Remove(respuestaCorrecta);
            await db.SaveChangesAsync();

            return Ok(respuestaCorrecta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RespuestaCorrectaExists(int id)
        {
            return db.RespuestaCorrectas.Count(e => e.CodCorrecta == id) > 0;
        }
    }
}