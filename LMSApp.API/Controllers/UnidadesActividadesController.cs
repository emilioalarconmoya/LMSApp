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
using LMSApp.Common;
using LMSApp.Domain.Models;

namespace LMSApp.API.Controllers
{
    public class UnidadesActividadesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/UnidadesActividades
        public IQueryable<UnidadesActividad> GetUnidadesActividads(int codActividadUsuario)
        {
            //return db.UnidadesActividads;
            DLUNIDADList dLUNIDADList = new DLUNIDADList();
            DataTable dataTable = dLUNIDADList.SelectAvanceUnidadesApp(codActividadUsuario);

            var importdata = from x in dataTable.AsEnumerable()
                             select new UnidadesActividad()
                             {
                                 CodActividadUsuario = x.Field<int>("CodActividadUsuario"),
                                 CodUnidad = x.Field<int>("CodUnidad"),
                                 Nombre = x.Field<string>("Nombre"),
                                 OrdenRelativo = x.Field<int>("OrdenRelativo"),
                                 NivelPrerequisito = x.Field<int>("NivelPrerequisito"),
                                 AvisaTermino = x.Field<bool>("AvisaTermino"),
                                 CodTipoUnidad = x.Field<int>("CodTipoUnidad"),
                                 Archivo = x.Field<string>("Archivo"),
                                 NumeroVisitas = x.Field<int>("NumeroVisitas"),
                                 TiempoConexion = x.Field<string>("TiempoConexion"),
                                 UltimaVisita = x.Field<DateTime>("UltimaVisita"),
                                 Terminada = x.Field<bool>("Terminada"),
                                 IdForo = x.Field<int>("IdForo"),
                                 TemasForos = x.Field<int>("TemasForos"),
                                 Descripcion = x.Field<string>("Descripcion"),
                                 NombreActividad = x.Field<string>("NombreActividad"),
                                 FechaInicio = x.Field<DateTime>("FechaInicio"),
                                 FechaFin = x.Field<DateTime>("FechaFin"),
                                 NotaAprobacion = x.Field<decimal>("NotaAprobacion"),
                                 Asistencia = x.Field<decimal>("Asistencia"),
                                 FlagNuevaConexion = x.Field<bool>("FlagNuevaConexion"),
                                 RutOtec = x.Field<string>("RutOtec"),
                                 Token = x.Field<string>("Token"),
                                 RutUsuario = x.Field<string>("RutUsuario"),
                                 IdRegistroSence = x.Field<int>("IdRegistroSence"),
                                 FlagActivo = x.Field<bool>("FlagActivo"),
                                 FechaHora = x.Field<DateTime>("FechaHora"),
                                 CodActividad = x.Field<int>("CodActividad"),
                                 RutTutor = x.Field<int>("RutTutor"),
                                 CodActividadTutor = x.Field<int>("CodActividadTutor"),
                                 NotaFinal = x.Field<decimal>("NotaFinal"),
                                 FlagEstadoAprobacion = x.Field<bool>("FlagEstadoAprobacion"),
                                 Mensaje = x.Field<string>("Mensaje"),
                                 Nivel = x.Field<int>("Nivel"),
                                 MinutosEvaluacion = x.Field<int>("MinutosEvaluacion"),



                             };

            return importdata.AsQueryable();
        }

        public DataTable SelectUnidadesActividadApp(int codActividad)
        {
            DLUNIDADList dLUNIDAD = new DLUNIDADList();

            DataTable dt= dLUNIDAD.SelectUnidadesActividadApp(codActividad);
            dt.TableName = "UnidadesActividad";

            return dt;
        }
        // GET: api/UnidadesActividades/5
        [ResponseType(typeof(UnidadesActividad))]
        public async Task<IHttpActionResult> GetUnidadesActividad(int id)
        {
            UnidadesActividad unidadesActividad = await db.UnidadesActividads.FindAsync(id);
            if (unidadesActividad == null)
            {
                return NotFound();
            }

            return Ok(unidadesActividad);
        }

        // PUT: api/UnidadesActividades/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnidadesActividad(int id, UnidadesActividad unidadesActividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unidadesActividad.CodActividadUsuario)
            {
                return BadRequest();
            }

            db.Entry(unidadesActividad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadesActividadExists(id))
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

        // POST: api/UnidadesActividades
        [ResponseType(typeof(UnidadesActividad))]
        public async Task<IHttpActionResult> PostUnidadesActividad(UnidadesActividad unidadesActividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UnidadesActividads.Add(unidadesActividad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = unidadesActividad.CodActividadUsuario }, unidadesActividad);
        }

        // DELETE: api/UnidadesActividades/5
        [ResponseType(typeof(UnidadesActividad))]
        public async Task<IHttpActionResult> DeleteUnidadesActividad(int id)
        {
            UnidadesActividad unidadesActividad = await db.UnidadesActividads.FindAsync(id);
            if (unidadesActividad == null)
            {
                return NotFound();
            }

            db.UnidadesActividads.Remove(unidadesActividad);
            await db.SaveChangesAsync();

            return Ok(unidadesActividad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnidadesActividadExists(int id)
        {
            return db.UnidadesActividads.Count(e => e.CodActividadUsuario == id) > 0;
        }
    }
}