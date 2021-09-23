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
using ATENEUS.CLASES.DAO;
using LMSApp.Common.Models;
using LMSApp.Domain.Models;

namespace LMSApp.API.Controllers
{
    public class EvaluacionsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Evaluacions
        public IQueryable<Evaluacion> GetEvaluacions(int codActividadUsaurio, int codUnidad, int codPregunta, int codEmpresa)
        {
            //return db.Evaluacions;
            DLEVALUACIONList dLEVALUACIONList = new DLEVALUACIONList();
            DataTable dataTable = dLEVALUACIONList.SelectPreguntaEvaluacionApp(codActividadUsaurio, codUnidad, codPregunta, codEmpresa);
            //DLPREGUNTA dLPREGUNTA = new DLPREGUNTA();

            var importdata = from x in dataTable.AsEnumerable()
                             select new Evaluacion()
                             {
                                 CodActividadUsuario = x.Field<int>("CodActividadUsuario"),
                                 Codunidad = x.Field<int>("CodUnidad"),
                                 CodPregunta = x.Field<int>("CodPregunta"),
                                 FechaHora = x.Field<DateTime>("FechaHora"),
                                 TextoRespuesta = x.Field<string>("TextoRespuesta"),
                                 Puntaje = x.Field<int>("Puntaje"),
                                 Comentarios = x.Field<string>("Comentarios"),
                                 EstaIncluida = x.Field<bool>("EstaIncluida"),
                                 NumeroIntentos = x.Field<int>("NumeroIntentos"),
                                 CodEmpresa = x.Field<int>("CodEmpresa"),
                             };

            return importdata.AsQueryable();
        }

        // GET: api/Evaluacions/5
        [ResponseType(typeof(Evaluacion))]
        public async Task<IHttpActionResult> GetEvaluacion(int id)
        {
            Evaluacion evaluacion = await db.Evaluacions.FindAsync(id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            return Ok(evaluacion);
        }

        // PUT: api/Evaluacions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEvaluacion(int id, Evaluacion evaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evaluacion.Codunidad)
            {
                return BadRequest();
            }

            db.Entry(evaluacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluacionExists(id))
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

        // POST: api/Evaluacions
        [ResponseType(typeof(Evaluacion))]
        public async Task<IHttpActionResult> PostEvaluacion(Evaluacion evaluacion)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.Evaluacions.Add(evaluacion);
            //await db.SaveChangesAsync();

            //return CreatedAtRoute("DefaultApi", new { id = evaluacion.Codunidad }, evaluacion);
            List<EEVALUACION> objListEvaluacion = new List<EEVALUACION>();
            EEVALUACION objEvaluacion = new EEVALUACION();
            objEvaluacion.CodActivUsr = evaluacion.CodActividadUsuario;
            objEvaluacion.CodPregunta = Convert.ToInt16(evaluacion.CodPregunta);
            objEvaluacion.CodUnidad = Convert.ToInt16(evaluacion.Codunidad);
            objEvaluacion.Comentarios = evaluacion.Comentarios;
            objEvaluacion.EstaIncluida = evaluacion.EstaIncluida;
            objEvaluacion.FechaHora = evaluacion.FechaHora;
            objEvaluacion.NroIntentos = evaluacion.NumeroIntentos;
            objEvaluacion.CodEmpresa = evaluacion.CodEmpresa;
            objEvaluacion.AvisaTremino = evaluacion.AvisaTermino;
            objEvaluacion.Puntaje = evaluacion.Puntaje;
            objEvaluacion.TextoRespuesta = evaluacion.TextoRespuesta;
            objListEvaluacion.Add(objEvaluacion);

            GuardarEvaluacion(objListEvaluacion);

            return Ok(evaluacion);
        }
        private bool GuardarEvaluacion(List<EEVALUACION> objList)
        {
            try
            {
                for (int i = 0; i <= objList.Count - 1; i++)
                {
                    objList[i].Save();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // DELETE: api/Evaluacions/5
        [ResponseType(typeof(Evaluacion))]
        public async Task<IHttpActionResult> DeleteEvaluacion(int id)
        {
            Evaluacion evaluacion = await db.Evaluacions.FindAsync(id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            db.Evaluacions.Remove(evaluacion);
            await db.SaveChangesAsync();

            return Ok(evaluacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EvaluacionExists(int id)
        {
            return db.Evaluacions.Count(e => e.Codunidad == id) > 0;
        }
    }
}