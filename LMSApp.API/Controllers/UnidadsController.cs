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
    public class UnidadsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Unidads
        public IQueryable<Unidad> GetUnidads(int codUnidad)
        {
            //return db.Unidads;
            DLUNIDADList dLUNIDADList = new DLUNIDADList();
            DataTable dataTable = dLUNIDADList.SelectUnidadApp(codUnidad);

            var importdata = from x in dataTable.AsEnumerable()
                             select new Unidad()
                             {
                                 CodUnidad = x.Field<int>("CodUnidad"),
                                 CodTipoUnidad = x.Field<int>("CodTipoUnidad"),
                                 CodTemaUnidad = x.Field<int>("CodTemaUnidad"),
                                 Nombre = x.Field<string>("Nombre"),
                                 Archivo = x.Field<string>("Archivo"),
                                 FlagAvisaTermino = x.Field<bool>("FlagAvisaTermino"),
                                 Contenido = x.Field<string>("Contenido"),
                                 Criterios = x.Field<string>("Criterios"),
                                 NumeroPreguntaAleatoria = x.Field<int>("NumeroPreguntaAleatoria"),
                                 TiempoSegundos = x.Field<int>("TiempoSegundos"),
                                 FlagMostrarResultados = x.Field<bool>("FlagMostrarResultados"),
                                 FlagMostrarRespuestaCorrecta = x.Field<bool>("FlagMostrarRespuestaCorrecta"),
                                 Descripcion = x.Field<string>("Descripcion"),
                                 NombreTipoUnidad = x.Field<string>("NombreTipoUnidad"),
                                 NombreTemaUnidad = x.Field<string>("NombreTemaUnidad"),
                                 RutTutor = x.Field<int>("RutTutor"),
                                 FlagActivo = x.Field<bool>("FlagActivo"),
                                 PreguntaPorPagina = x.Field<int>("PreguntaPorPagina"),
                                 UsuarioSalaVirtual = x.Field<string>("UsuarioSalaVirtual"),
                                 PassSalaVirtual = x.Field<string>("PassSalaVirtual"),
                                 UrlSalaVirtual = x.Field<string>("UrlSalaVirtual"),
                                 CodtipoSalaVirtual = x.Field<int>("CodtipoSalaVirtual"),
                                 CodTipoEncuesta = x.Field<int>("CodTipoEncuesta"),


                             };

            return importdata.AsQueryable();
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