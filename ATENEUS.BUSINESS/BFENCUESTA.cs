
using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFENCUESTA.
	/// </summary>
	public class BFENCUESTA
	{
		private DLENCUESTA _objDAL;
		private DLENCUESTAList _objDALList;
		
		public BFENCUESTA()
		{
			_objDAL = new DLENCUESTA();
			_objDALList = new DLENCUESTAList();
		}

		public EENCUESTA GetENCUESTA()
		{
			return new EENCUESTA();
		}

		public EENCUESTA GetENCUESTA(long id)
		{
            return new EENCUESTA(id);
		}

		public bool Save(EENCUESTA objENCUESTA)
		{
			try
			{
				objENCUESTA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }


        public bool GuardarEncuesta(List<EENCUESTA> objList)
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
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }
		public List<EENCUESTA> GetENCUESTAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EENCUESTA objENCUESTA)
		{
			try
			{
                _objDAL.Delete(objENCUESTA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EENCUESTA objENCUESTA)
        {
            try
            {
                _objDAL.Update(objENCUESTA);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<EENCUESTA> GetEncuestaRealizada(long CodActivUsr, Int32 CodUnidad)
        {
            return _objDALList.SelectEncuestaRealizada(CodActivUsr, CodUnidad);
        }

        public EENCUESTA GetPreguntaEncuesta(long CodActivUsr, Int32 CodUnidad, Int16 CodPregunta,Int64 CodEmpresa)
        {
            return _objDALList.SelectPreguntaEncuestadas(CodActivUsr, CodUnidad, CodPregunta,  CodEmpresa);
        }

        public Boolean SeEncuestoPregunta(Int16 CodPregunta)
        {
            return _objDALList.SelectSeEncuestoPregunta(CodPregunta);
        }

        public static DataTable GetReporteEncuesta(Int64 RutUsuario, Int32 CodActividad, Int32 CodUnidad, DateTime FechaInicio, DateTime FechaFin, Int64 CodEmpresa)
        {
            return DLENCUESTAList.GetReporteEncuesta(RutUsuario, CodActividad, CodUnidad, FechaInicio, FechaFin,CodEmpresa);
        }

    }
}

