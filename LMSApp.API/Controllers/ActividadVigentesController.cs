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
    public class ActividadVigentesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/ActividadVigentes
        public IQueryable<ActividadVigente> GetActividadVigentes(long RutUsuario, Int16 DiasEspera, Int64 CodEmpresa, Int32 horaZona)
        {
            //return db.ActividadVigentes;
            DLACTIVIDADUSUARIOList dLUSUARIO = new DLACTIVIDADUSUARIOList();
            DataTable dataTable = dLUSUARIO.SelectActividadesVigentesApp(RutUsuario, DiasEspera, CodEmpresa, horaZona);

            var importdata = from x in dataTable.AsEnumerable()
                             select new ActividadVigente()
                             {
                                 CodActividadUsuario = x.Field<int>("CodActividadUsuario"),
                                 CodActividad = x.Field<int>("CodActividad"),
                                 Nombre = x.Field<string>("Nombre"),
                                 Objetivos = x.Field<string>("Objetivos"),
                                 Imagen = x.Field<string>("Imagen"),
                                 FechaFin = x.Field<DateTime>("FechaFin"),
                                 FechaInicio = x.Field<DateTime>("FechaInicio"),
                                 CodTipo = x.Field<int>("CodTipo"),
                                 CodEstado = x.Field<int>("CodEstado"),
                                 Asistencia = x.Field<int>("Asistencia"),
                                 Estado = x.Field<string>("Estado"),
                                 Vigente = x.Field<bool>("Vigente"),
                                 NotaFinal = x.Field<decimal>("NotaFinal"),
                                 MostrarCertificado = x.Field<bool>("MostrarCertificado"),
                                 ComunicaSence = x.Field<bool>("ComunicaSence"),
                                 FlagNuevaConexion = x.Field<bool>("FlagNuevaConexion"),
                                 RutTutor = x.Field<int>("RutTutor"),
                                 CodActividadTutor = x.Field<int>("CodActividadTutor"),


                             };

            return importdata.AsQueryable();
        }

        // GET: api/ActividadVigentes/5
        [ResponseType(typeof(ActividadVigente))]
        public async Task<IHttpActionResult> GetActividadVigente(int id)
        {
            ActividadVigente actividadVigente = await db.ActividadVigentes.FindAsync(id);
            if (actividadVigente == null)
            {
                return NotFound();
            }

            return Ok(actividadVigente);
        }

        // PUT: api/ActividadVigentes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutActividadVigente(int id, ActividadVigente actividadVigente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actividadVigente.CodActividadUsuario)
            {
                return BadRequest();
            }

            db.Entry(actividadVigente).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadVigenteExists(id))
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

        // POST: api/ActividadVigentes
        [ResponseType(typeof(ActividadVigente))]
        public async Task<IHttpActionResult> PostActividadVigente(ActividadVigente actividadVigente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActividadVigentes.Add(actividadVigente);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = actividadVigente.CodActividadUsuario }, actividadVigente);
        }

        // DELETE: api/ActividadVigentes/5
        [ResponseType(typeof(ActividadVigente))]
        public async Task<IHttpActionResult> DeleteActividadVigente(int id)
        {
            ActividadVigente actividadVigente = await db.ActividadVigentes.FindAsync(id);
            if (actividadVigente == null)
            {
                return NotFound();
            }

            db.ActividadVigentes.Remove(actividadVigente);
            await db.SaveChangesAsync();

            return Ok(actividadVigente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActividadVigenteExists(int id)
        {
            return db.ActividadVigentes.Count(e => e.CodActividadUsuario == id) > 0;
        }
    }
}