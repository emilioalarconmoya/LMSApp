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
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAO;

namespace LMSApp.API.Controllers
{
    public class ActividadUsuariosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/ActividadUsuarios
        public IQueryable<ActividadUsuario> GetActividadUsuarios(int codActividadUsuario)
        {
            //return db.ActividadUsuarios;

            DLACTIVIDADUSUARIOList dLACTIVIDADUSUARIOList = new DLACTIVIDADUSUARIOList();
            DataTable dataTable = dLACTIVIDADUSUARIOList.SelectActividadUsuarioApp(codActividadUsuario);

            var importdata = from x in dataTable.AsEnumerable()
                             select new ActividadUsuario()
                             {
                                 CodActividadUsuario = x.Field<int>("CodActividadUsuario"),
                                 RutUsuario = x.Field<int>("RutUsuario"),
                                 CodActividad = x.Field<int>("CodActividad"),
                                 CodEstado = x.Field<int>("CodEstado"),
                                 CodUltimaUnidad = x.Field<int>("CodUltimaUnidad"),
                                 FechaInicio = x.Field<DateTime>("FechaInicio"),
                                 FechaFin = x.Field<DateTime>("FechaFin"),
                                 InicioReal = x.Field<DateTime>("InicioReal"),
                                 FinReal = x.Field<DateTime>("FinReal"),
                                 Asistencia = x.Field<int>("Asistencia"),
                                 NotaFinal = x.Field<decimal>("NotaFinal"),
                                 Comentarios = x.Field<string>("Comentarios"),
                                 EvaluacionCurso = x.Field<decimal>("EvaluacionCurso"),
                                 CostoSence = x.Field<int>("CostoSence"),
                                 GastoEmpresa = x.Field<int>("GastoEmpresa"),
                                 FlagComunicaSence = x.Field<bool>("FlagComunicaSence"),
                                 FechaCertificacion = x.Field<DateTime>("FechaCertificacion"),
                                 FlagMostrarCertificado = x.Field<bool>("FlagMostrarCertificado"),
                                 NotaMinima = x.Field<decimal>("NotaMinima"),
                                 FlagEstadoAprobacion = x.Field<bool>("FlagEstadoAprobacion"),
                                 HoraInicio = x.Field<DateTime>("HoraInicio"),
                                 HoraFin = x.Field<DateTime>("HoraFin"),
                                 HoraInicioReal = x.Field<DateTime>("HoraInicioReal"),
                                 HoraFinReal = x.Field<DateTime>("HoraFinReal"),
                                 FlagEvalConHora = x.Field<bool>("FlagEvalConHora"),
                                 PorcentajeMinimo = x.Field<decimal>("PorcentajeMinimo"),
                                 OrdenCompra = x.Field<int>("OrdenCompra"),
                                 IdRegistroSence = x.Field<int>("IdRegistroSence"),
                                 CodActividadTutor = x.Field<int>("CodActividadTutor"),
                                 Dni = x.Field<string>("Dni"),
                                 MinutosEvaluacion = x.Field<int>("MinutosEvaluacion"),
                                 FlagEnviarEncuesta = x.Field<bool>("FlagEnviarEncuesta"),
                                 CodEncuestaSatisfaccion = x.Field<int>("CodEncuestaSatisfaccion"),
                                 PuntajeMaximo = x.Field<int>("PuntajeMaximo"),
                                 PuntajeObtenido = x.Field<int>("PuntajeObtenido"),
                                 TotalUnidades = x.Field<int>("TotalUnidades"),
                                 UnidadesTerminadas = x.Field<int>("UnidadesTerminadas"),
                                 CodEmpresa = x.Field<int>("CodEmpresa"),


                             };

            return importdata.AsQueryable();
        }

        // GET: api/ActividadUsuarios/5
        [ResponseType(typeof(ActividadUsuario))]
        public async Task<IHttpActionResult> GetActividadUsuario(int id)
        {
            ActividadUsuario actividadUsuario = await db.ActividadUsuarios.FindAsync(id);
            if (actividadUsuario == null)
            {
                return NotFound();
            }

            return Ok(actividadUsuario);
        }

        // PUT: api/ActividadUsuarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutActividadUsuario(ActividadUsuario actividadUsuario)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != actividadUsuario.CodActividadUsuario)
            //{
            //    return BadRequest();
            //}

            //db.Entry(actividadUsuario).State = EntityState.Modified;

            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ActividadUsuarioExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            BFACTIVIDADUSUARIO objBFActivUsr = new BFACTIVIDADUSUARIO();
            EACTIVIDADUSUARIO objActivUsr = new EACTIVIDADUSUARIO();
            objActivUsr = objBFActivUsr.GetACTIVIDADUSUARIO(actividadUsuario.CodActividadUsuario);
            objActivUsr.CodEmpresa = actividadUsuario.CodEmpresa;
            objActivUsr.NotaFinal = Convert.ToDouble(actividadUsuario.NotaFinal);
            objActivUsr.Asistencia = Convert.ToDouble(actividadUsuario.Asistencia);
            objActivUsr.CodEstado = Convert.ToInt16(actividadUsuario.CodEstado);
            objActivUsr.FinReal = actividadUsuario.FinReal;
            objActivUsr.HoraFinReal = actividadUsuario.HoraFinReal;
            objActivUsr.FlagEstadoAprobacion = actividadUsuario.FlagEstadoAprobacion;
            objActivUsr.IsPersisted = true;
            objBFActivUsr.Save(objActivUsr);


            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ActividadUsuarios
        [ResponseType(typeof(ActividadUsuario))]
        public async Task<IHttpActionResult> PostActividadUsuario(ActividadUsuario actividadUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActividadUsuarios.Add(actividadUsuario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = actividadUsuario.CodActividadUsuario }, actividadUsuario);
        }

        // DELETE: api/ActividadUsuarios/5
        [ResponseType(typeof(ActividadUsuario))]
        public async Task<IHttpActionResult> DeleteActividadUsuario(int id)
        {
            ActividadUsuario actividadUsuario = await db.ActividadUsuarios.FindAsync(id);
            if (actividadUsuario == null)
            {
                return NotFound();
            }

            db.ActividadUsuarios.Remove(actividadUsuario);
            await db.SaveChangesAsync();

            return Ok(actividadUsuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActividadUsuarioExists(int id)
        {
            return db.ActividadUsuarios.Count(e => e.CodActividadUsuario == id) > 0;
        }
    }
}