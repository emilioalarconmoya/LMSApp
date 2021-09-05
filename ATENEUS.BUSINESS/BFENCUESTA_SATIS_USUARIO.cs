
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
	public class BFENCUESTASATISUSUARIO
	{
		private DLENCUESTASATISUSUARIO _objDAL;
		private DLENCUESTASATISUSUARIOList _objDALList;
		
		public BFENCUESTASATISUSUARIO()
		{
			_objDAL = new DLENCUESTASATISUSUARIO();
			_objDALList = new DLENCUESTASATISUSUARIOList();
		}

		public EENCUESTASATISUSUARIO GetENCUESTA()
		{
			return new EENCUESTASATISUSUARIO();
		}

		public EENCUESTASATISUSUARIO GetENCUESTA(long id)
		{
            return new EENCUESTASATISUSUARIO(id);
		}

		public bool Save(EENCUESTASATISUSUARIO objENCUESTA)
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


        public bool GuardarEncuesta(List<EENCUESTASATISUSUARIO> objList)
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
		public List<EENCUESTASATISUSUARIO> GetENCUESTAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EENCUESTASATISUSUARIO objENCUESTA)
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

        public bool Update(EENCUESTASATISUSUARIO objENCUESTA)
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

        public List<EENCUESTASATISUSUARIO> GetEncuestaRealizada(long CodActivUsr, Int32 CodUnidad)
        {
            return _objDALList.SelectEncuestaRealizada(CodActivUsr, CodUnidad);
        }

        public EENCUESTASATISUSUARIO GetPreguntaEncuesta(long CodActivUsr, Int32 CodUnidad, Int16 CodPregunta,Int64 CodEmpresa)
        {
            return _objDALList.SelectPreguntaEncuestadas(CodActivUsr, CodUnidad, CodPregunta,  CodEmpresa);
        }

        public Boolean SeEncuestoPregunta(Int16 CodPregunta)
        {
            return _objDALList.SelectSeEncuestoPregunta(CodPregunta);
        }

        public static DataTable GetReporteEncuesta(Int64 RutUsuario, Int32 codEncuesta, DateTime FechaInicio, DateTime FechaFin, Int32 codActividad, Int64 CodEmpresa)
        {
            return DLENCUESTASATISUSUARIOList.GetReporteEncuesta(RutUsuario, codEncuesta, FechaInicio, FechaFin, codActividad, CodEmpresa);
        }

        public static DataTable GetReporteEncuestaPromedio(Int64 RutUsuario, Int32 codEncuesta, DateTime FechaInicio, DateTime FechaFin, Int32 codActividad, Int64 CodEmpresa)
        {
            return DLENCUESTASATISUSUARIOList.GetReporteEncuestaPromedio(RutUsuario, codEncuesta, FechaInicio, FechaFin, codActividad, CodEmpresa);
        }

    }
}

