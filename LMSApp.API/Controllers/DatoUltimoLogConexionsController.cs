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
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using LMSApp.Common.Models;
using LMSApp.Domain.Models;

namespace LMSApp.API.Controllers
{
    public class DatoUltimoLogConexionsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/DatoUltimoLogConexions
        public IQueryable<DatoUltimoLogConexion> GetDatoUltimoLogConexions(int codActividadUsuario, int codUnidad, int codEmpresa)
        {
            //return db.DatoUltimoLogConexions;
            DLLOGCONEXIONList dLLOGCONEXIONList = new DLLOGCONEXIONList();
            DataTable dataTable = dLLOGCONEXIONList.SelectDatosUltimoLogApp(codActividadUsuario, codUnidad, codEmpresa);
            var importdata = from x in dataTable.AsEnumerable()
                             select new DatoUltimoLogConexion()
                             {
                                 Inicio = x.Field<DateTime>("Inicio"),
                                 FlagTerminada = x.Field<bool>("FlagTerminada"),
                                 TiempoRestanteSegundo = x.Field<int>("TiempoRestanteSegundo"),
                                 PasoUltimaVisita = x.Field<int>("PasoUltimaVisita"),
                                 Cerrada = x.Field<bool>("Cerrada"),
                             };

            return importdata.AsQueryable();
        }

        // GET: api/DatoUltimoLogConexions/5
        [ResponseType(typeof(DatoUltimoLogConexion))]
        public async Task<IHttpActionResult> GetDatoUltimoLogConexion(int id)
        {
            DatoUltimoLogConexion datoUltimoLogConexion = await db.DatoUltimoLogConexions.FindAsync(id);
            if (datoUltimoLogConexion == null)
            {
                return NotFound();
            }

            return Ok(datoUltimoLogConexion);
        }

        // PUT: api/DatoUltimoLogConexions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDatoUltimoLogConexion(int id, DatoUltimoLogConexion datoUltimoLogConexion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != datoUltimoLogConexion.TiempoRestanteSegundo)
            {
                return BadRequest();
            }

            db.Entry(datoUltimoLogConexion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatoUltimoLogConexionExists(id))
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

        // POST: api/DatoUltimoLogConexions
        [ResponseType(typeof(DatoUltimoLogConexion))]
        public async Task<IHttpActionResult> PostDatoUltimoLogConexion(List<DatoUltimoLogConexion> datoUltimoLogConexion, int codActivUsr, int codUnidad, int codEmpresa)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.DatoUltimoLogConexions.Add(datoUltimoLogConexion);
            //await db.SaveChangesAsync();

            //return CreatedAtRoute("DefaultApi", new { id = datoUltimoLogConexion.TiempoRestanteSegundo }, datoUltimoLogConexion);
            //BFLOGCONEXION objBFLogConexion = new BFLOGCONEXION();
            ELOGCONEXION objLogConexion = new ELOGCONEXION();
            //objLogConexion.CodActivUsr = codActivUsr;
            //objLogConexion.CodUnidad = Convert.ToInt16(codUnidad);
            //objLogConexion.Inicio = datoUltimoLogConexion[0].Inicio;
            //objLogConexion.Fin = DateTime.Now;
            //objLogConexion.Terminada = datoUltimoLogConexion[0].FlagTerminada;
            //objLogConexion.TiempoRestanteSeg = datoUltimoLogConexion[0].TiempoRestanteSegundo;
            //objLogConexion.PasoUltimaVisita = datoUltimoLogConexion[0].PasoUltimaVisita;
            //objLogConexion.Cerrada = true;
            //objLogConexion.CodEmpresa = Convert.ToInt64(codEmpresa);
            //objBFLogConexion.Update(objLogConexion);

            return Ok(objLogConexion);
        }

        // DELETE: api/DatoUltimoLogConexions/5
        [ResponseType(typeof(DatoUltimoLogConexion))]
        public async Task<IHttpActionResult> DeleteDatoUltimoLogConexion(int id)
        {
            DatoUltimoLogConexion datoUltimoLogConexion = await db.DatoUltimoLogConexions.FindAsync(id);
            if (datoUltimoLogConexion == null)
            {
                return NotFound();
            }

            db.DatoUltimoLogConexions.Remove(datoUltimoLogConexion);
            await db.SaveChangesAsync();

            return Ok(datoUltimoLogConexion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DatoUltimoLogConexionExists(int id)
        {
            return db.DatoUltimoLogConexions.Count(e => e.TiempoRestanteSegundo == id) > 0;
        }
    }
}