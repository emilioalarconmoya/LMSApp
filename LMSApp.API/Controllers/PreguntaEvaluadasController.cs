namespace LMSApp.API.Controllers
{
    using ATENEUS.CLASES.DAL;
    using LMSApp.Common.Models;
    using LMSApp.Domain.Models;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Http;
    public class PreguntaEvaluadasController : ApiController
    {
        private DataContext db = new DataContext();
        // GET: api/PreguntaEvaluadas
        public IEnumerable<PreguntaEvaluada> Get(int codUnidad, int codActividadUsaurio, int codEmpresa)
        {
            DLPREGUNTAUNIDADList dLPREGUNTAUNIDAD = new DLPREGUNTAUNIDADList();
            DataTable dataTable = dLPREGUNTAUNIDAD.PreguntasEvaluadasApp(codUnidad, codActividadUsaurio, codEmpresa);
            //DLPREGUNTA dLPREGUNTA = new DLPREGUNTA();

            var importdata = from x in dataTable.AsEnumerable()
                             select new PreguntaEvaluada()
                             {
                                 CodPregunta = x.Field<int>("CodPregunta"),
                                 CodUnidad = x.Field<int>("CodUnidad"),
                                 PuntajeMax = x.Field<int>("PuntajeMax"),
                                 Imagen = x.Field<string>("Imagen"),
                                 Ancho = x.Field<string>("Ancho"),
                                 Alto = x.Field<string>("Alto"),
                                 Link = x.Field<string>("Link"),
                                 UrlVideo = x.Field<string>("UrlVideo"),
                             };

            return importdata.AsQueryable();
        }

        // GET: api/PreguntaEvaluadas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PreguntaEvaluadas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PreguntaEvaluadas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PreguntaEvaluadas/5
        public void Delete(int id)
        {
        }
    }
}
