
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
	public class BFPREGUNTAUNIDAD
	{
		private DLPREGUNTAUNIDAD _objDAL;
		private DLPREGUNTAUNIDADList _objDALList;
		
		public BFPREGUNTAUNIDAD()
		{
			_objDAL = new DLPREGUNTAUNIDAD();
			_objDALList = new DLPREGUNTAUNIDADList();
		}

		public EPREGUNTAUNIDAD GetPREGUNTAUNIDAD()
		{
			return new EPREGUNTAUNIDAD();
		}

		public EPREGUNTAUNIDAD GetPREGUNTAUNIDAD(long id)
		{
            return new EPREGUNTAUNIDAD(id);
		}

		public bool Save(EPREGUNTAUNIDAD objPREGUNTAUNIDAD)
		{
			try
			{
				objPREGUNTAUNIDAD.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EPREGUNTAUNIDAD> GetPREGUNTAUNIDADAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPREGUNTAUNIDAD objPREGUNTAUNIDAD)
		{
			try
			{
                _objDAL.Delete(objPREGUNTAUNIDAD);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EPREGUNTAUNIDAD objPREGUNTAUNIDAD)
        {
            try
            {
                _objDAL.Update(objPREGUNTAUNIDAD);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<EPREGUNTAUNIDAD> PreguntasUnidad(Int16 CodUnidad)
        {
            return _objDALList.PreguntasUnidad(CodUnidad);
        }

        public List<EPREGUNTAUNIDAD> PreguntasEvaluadas(Int16 CodUnidad, Int64 CodActivUsr, Int64 CodEmpresa)
        {
            return _objDALList.PreguntasEvaluadas(CodUnidad, CodActivUsr,CodEmpresa);
        }

        public List<EPREGUNTAUNIDAD> PreguntasEncuestadas(Int16 CodUnidad, Int64 CodActivUsr, Int64 CodEmpresa)
        {
            return _objDALList.PreguntasEncuestadas(CodUnidad, CodActivUsr,CodEmpresa);
        }

        public List<EPREGUNTAUNIDAD> PreguntasEncuestadasDeSatisfaccion(Int16 CodUnidad, Int64 CodActivUsr, Int64 CodEmpresa)
        {
            return _objDALList.PreguntasEncuestadasDeSatisfaccion(CodUnidad, CodActivUsr, CodEmpresa);
        }

        public void SubirImagenes(string Archivo, string Path)
        {
            Utiles.Descomprimir(Archivo, Path);
        }

    }
}

