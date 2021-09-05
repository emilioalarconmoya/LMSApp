
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFPREGUNTAUNIDAD.
	/// </summary>
	public class BFPREGUNTAENCUESTASATIS
	{
		private DLPREGUNTAENCUESTASATIS _objDAL;
		private DLPREGUNTAENCUESTASATISList _objDALList;
		
		public BFPREGUNTAENCUESTASATIS()
		{
			_objDAL = new DLPREGUNTAENCUESTASATIS();
			_objDALList = new DLPREGUNTAENCUESTASATISList();
		}

		public EPREGUNTAENCUESTASATIS GetPREGUNTAUNIDAD()
		{
			return new EPREGUNTAENCUESTASATIS();
		}

		public EPREGUNTAENCUESTASATIS GetPREGUNTAUNIDAD(long id)
		{
            return new EPREGUNTAENCUESTASATIS(id);
		}

		public bool Save(EPREGUNTAENCUESTASATIS objPREGUNTAENCUESTA)
		{
			try
			{
				objPREGUNTAENCUESTA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EPREGUNTAENCUESTASATIS> GetPREGUNTAUNIDADAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPREGUNTAENCUESTASATIS objPREGUNTAENCUESTA)
		{
			try
			{
                _objDAL.Delete(objPREGUNTAENCUESTA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EPREGUNTAENCUESTASATIS objPREGUNTAENCUESTA)
        {
            try
            {
                _objDAL.Update(objPREGUNTAENCUESTA);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<EPREGUNTAENCUESTASATIS> PreguntasEncuesta(Int16 Codencuesta)
        {
            return _objDALList.PreguntasEncuesta(Codencuesta);
        }

        public List<EPREGUNTAENCUESTASATIS> PreguntasEvaluadas(Int16 CodUnidad, Int64 CodActivUsr, Int64 CodEmpresa)
        {
            return _objDALList.PreguntasEvaluadas(CodUnidad, CodActivUsr,CodEmpresa);
        }

        public List<EPREGUNTAENCUESTASATIS> PreguntasEncuestadas(Int16 Codencuesta, Int64 CodActivUsr, Int64 CodEmpresa)
        {
            return _objDALList.PreguntasEncuestadas(Codencuesta, CodActivUsr,CodEmpresa);
        }

        //public List<EPREGUNTAENCUESTASATIS> PreguntasEncuestadasDeSatisfaccion(Int16 CodUnidad, Int64 CodActivUsr, Int64 CodEmpresa)
        //{
        //    return _objDALList.PreguntasEncuestadasDeSatisfaccion(CodUnidad, CodActivUsr, CodEmpresa);
        //}

        

    }
}

