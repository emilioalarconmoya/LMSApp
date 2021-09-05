
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFEVALUACION.
	/// </summary>
	public class BFEVALUACION
	{
		private DLEVALUACION _objDAL;
		private DLEVALUACIONList _objDALList;
		
		public BFEVALUACION()
		{
			_objDAL = new DLEVALUACION();
			_objDALList = new DLEVALUACIONList();
		}

		public EEVALUACION GetEVALUACION()
		{
			return new EEVALUACION();
		}

		public EEVALUACION GetEVALUACION(long id)
		{
            return new EEVALUACION(id);
		}

		public bool Save(EEVALUACION objEVALUACION)
		{
			try
			{
				objEVALUACION.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }


        public bool GuardarEvaluacion(List<EEVALUACION> objList)
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

		public List<EEVALUACION> GetEVALUACIONAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EEVALUACION objEVALUACION)
		{
			try
			{
                _objDAL.Delete(objEVALUACION);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EEVALUACION objEVALUACION)
        {
            try
            {
                _objDAL.Update(objEVALUACION);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<EEVALUACION> GetEvaluacionRealizada(long CodActivUsr, Int32 CodUnidad)
        {
            return _objDALList.SelectEvaluacionRealizada(CodActivUsr, CodUnidad);
        }

        public EEVALUACION GetPreguntaEvaluacion(long CodActivUsr, Int32 CodUnidad, Int16 CodPregunta, Int64 CodEmpresa)
        {
            return _objDALList.SelectPreguntaEvaluacion(CodActivUsr, CodUnidad, CodPregunta,CodEmpresa);
        }

        public Boolean SeEvaluoPregunta(Int16 CodPregunta)
        {
            return _objDALList.SelectSeEvaluoPregunta(CodPregunta);
        }


	}
}

