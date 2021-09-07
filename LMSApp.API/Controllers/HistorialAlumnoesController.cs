using ATENEUS.CLASES.DAL;
using LMSApp.Common.Models;
using LMSApp.Domain.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LMSApp.API.Controllers
{
    public class HistorialAlumnoesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/HistorialAlumnoes
        public IQueryable<HistorialAlumno> GetHistorialAlumnoes(int rutUsuario)
        {
            //return db.HistorialAlumnoes;
            DLACTIVIDADUSUARIOList dLUSUARIO = new DLACTIVIDADUSUARIOList();
            DataTable dataTable = dLUSUARIO.SelectHistorialUsuarioApp(rutUsuario);

            var importdata = from x in dataTable.AsEnumerable()
                             select new HistorialAlumno()
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
                                 


                             };

            return importdata.AsQueryable();
        }

        // GET: api/HistorialAlumnoes/5
        [ResponseType(typeof(HistorialAlumno))]
        public async Task<IHttpActionResult> GetHistorialAlumno(int id)
        {
            HistorialAlumno historialAlumno = await db.HistorialAlumnoes.FindAsync(id);
            if (historialAlumno == null)
            {
                return NotFound();
            }

            return Ok(historialAlumno);
        }

        // PUT: api/HistorialAlumnoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHistorialAlumno(int id, HistorialAlumno historialAlumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historialAlumno.CodActividadUsuario)
            {
                return BadRequest();
            }

            db.Entry(historialAlumno).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialAlumnoExists(id))
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

        // POST: api/HistorialAlumnoes
        [ResponseType(typeof(HistorialAlumno))]
        public async Task<IHttpActionResult> PostHistorialAlumno(HistorialAlumno historialAlumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HistorialAlumnoes.Add(historialAlumno);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = historialAlumno.CodActividadUsuario }, historialAlumno);
        }

        // DELETE: api/HistorialAlumnoes/5
        [ResponseType(typeof(HistorialAlumno))]
        public async Task<IHttpActionResult> DeleteHistorialAlumno(int id)
        {
            HistorialAlumno historialAlumno = await db.HistorialAlumnoes.FindAsync(id);
            if (historialAlumno == null)
            {
                return NotFound();
            }

            db.HistorialAlumnoes.Remove(historialAlumno);
            await db.SaveChangesAsync();

            return Ok(historialAlumno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistorialAlumnoExists(int id)
        {
            return db.HistorialAlumnoes.Count(e => e.CodActividadUsuario == id) > 0;
        }
    }
}