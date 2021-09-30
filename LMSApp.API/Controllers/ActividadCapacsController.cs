using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LMSApp.Common.Models;
using LMSApp.Domain.Models;
using ATENEUS.CLASES.DAL;

namespace LMSApp.API.Controllers
{
    //[Authorize]
    public class ActividadCapacsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/ActividadCapacs
        public IQueryable<ActividadCapac> GetActividadCapacs(int codActividad)
        {
            //return db.ActividadCapacs;
            DLACTIVIDADCAPACList dLACTIVIDADCAPACList = new DLACTIVIDADCAPACList();
            DataTable dataTable = dLACTIVIDADCAPACList.SelectActividadApp(codActividad);
            var importdata = from x in dataTable.AsEnumerable()
                             select new ActividadCapac()
                             {
                                 CodActividad = x.Field<int>("CodActividad"),
                                 CodProveedor = x.Field<int>("CodProveedor"),
                                 CodTipo = x.Field<int>("CodTipo"),
                                 Nombre = x.Field<string>("Nombre"),
                                 Contenido = x.Field<string>("Contenido"),
                                 Horas = x.Field<decimal>("Horas"),
                                 Costo = x.Field<decimal>("Costo"),
                                 Duracion = x.Field<int>("Duracion"),
                                 CodigoSence = x.Field<string>("CodigoSence"),
                                 Objetivos = x.Field<string>("Objetivos"),
                                 DestacadoHome = x.Field<int>("DestacadoHome"),
                                 Imagen = x.Field<string>("Imagen"),
                                 OrdenDestacados = x.Field<int>("OrdenDestacados"),
                                 FlagVigente = x.Field<bool>("FlagVigente"),
                                 Mensaje = x.Field<string>("Mensaje"),
                                 NotaMinima = x.Field<decimal>("NotaMinima"),
                                 PorcentajeMinimo = x.Field<decimal>("PorcentajeMinimo"),
                                 FlagNotaEnPorcentaje = x.Field<bool>("FlagNotaEnPorcentaje"),
                                 NotaMaxima = x.Field<decimal>("NotaMaxima"),
                                 NotaAprobacion = x.Field<decimal>("NotaAprobacion"),
                                 Exigencia = x.Field<decimal>("Exigencia"),
                                 FlagPublica = x.Field<bool>("FlagPublica"),
                                 FlagAbierta = x.Field<bool>("FlagAbierta"),
                                 FlagParaInscripcion = x.Field<bool>("FlagParaInscripcion"),
                                 PuntajeCurso = x.Field<decimal>("PuntajeCurso"),
                                 PuntajeAprobacion = x.Field<decimal>("PuntajeAprobacion"),
                                 DiasExpiracionPuntos = x.Field<int>("DiasExpiracionPuntos"),
                                 DiasAutoInscripcion = x.Field<int>("DiasAutoInscripcion"),
                                 FlaNuevaConexion = x.Field<bool>("FlaNuevaConexion"),
                                 RutTutor = x.Field<int>("RutTutor"),
                                 FlagActivo = x.Field<bool>("FlagActivo"),
                                 CodCategoria = x.Field<int>("CodCategoria"),


                             };

            return importdata.AsQueryable();
        }

        // GET: api/ActividadCapacs/5
        [ResponseType(typeof(ActividadCapac))]
        public async Task<IHttpActionResult> GetActividadCapac(int id)
        {
            ActividadCapac actividadCapac = await db.ActividadCapacs.FindAsync(id);
            if (actividadCapac == null)
            {
                return NotFound();
            }

            return Ok(actividadCapac);
        }

        // PUT: api/ActividadCapacs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutActividadCapac(int id, ActividadCapac actividadCapac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actividadCapac.CodActividad)
            {
                return BadRequest();
            }

            db.Entry(actividadCapac).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadCapacExists(id))
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

        // POST: api/ActividadCapacs
        [ResponseType(typeof(ActividadCapac))]
        public async Task<IHttpActionResult> PostActividadCapac(ActividadCapac actividadCapac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActividadCapacs.Add(actividadCapac);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = actividadCapac.CodActividad }, actividadCapac);
        }

        // DELETE: api/ActividadCapacs/5
        [ResponseType(typeof(ActividadCapac))]
        public async Task<IHttpActionResult> DeleteActividadCapac(int id)
        {
            ActividadCapac actividadCapac = await db.ActividadCapacs.FindAsync(id);
            if (actividadCapac == null)
            {
                return NotFound();
            }

            db.ActividadCapacs.Remove(actividadCapac);
            await db.SaveChangesAsync();

            return Ok(actividadCapac);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActividadCapacExists(int id)
        {
            return db.ActividadCapacs.Count(e => e.CodActividad == id) > 0;
        }
    }
}