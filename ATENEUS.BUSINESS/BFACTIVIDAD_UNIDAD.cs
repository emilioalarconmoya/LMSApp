
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFACTIVIDADUNIDAD.
	/// </summary>
	public class BFACTIVIDADUNIDAD
	{
		private DLACTIVIDADUNIDAD _objDAL;
		private DLACTIVIDADUNIDADList _objDALList;
		
		public BFACTIVIDADUNIDAD()
		{
			_objDAL = new DLACTIVIDADUNIDAD();
			_objDALList = new DLACTIVIDADUNIDADList();
		}

		public EACTIVIDADUNIDAD GetACTIVIDADUNIDAD()
		{
			return new EACTIVIDADUNIDAD();
		}

		public EACTIVIDADUNIDAD GetACTIVIDADUNIDAD(long id)
		{
            return new EACTIVIDADUNIDAD(id);
		}

		public bool Save(EACTIVIDADUNIDAD objACTIVIDADUNIDAD)
		{
			try
			{
				objACTIVIDADUNIDAD.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EACTIVIDADUNIDAD> GetACTIVIDADUNIDADAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EACTIVIDADUNIDAD objACTIVIDADUNIDAD)
		{
			try
			{
                _objDAL.Delete(objACTIVIDADUNIDAD);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EACTIVIDADUNIDAD objACTIVIDADUNIDAD)
        {
            try
            {
                _objDAL.Update(objACTIVIDADUNIDAD);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DataTable GetUnidadesActividad(long CodActividad)
        {
            return _objDALList.SelectUnidadesActividad(CodActividad);
        }

        public Boolean GetTerminoUnidad(long CodActivUsr, long CodUnidad, Int64 CodEmpresa)
        {
            return _objDALList.GetTerminoUnidad(CodActivUsr, CodUnidad,CodEmpresa);
        }

        public void ActializaUnidadActivo(long CodActividad, long CodUnidad, Boolean flag_activo, Int64 CodEmpresa)
        {
            _objDAL.ActualizaFlagActivo(CodActividad, CodUnidad, flag_activo,CodEmpresa);
        }

    }
}

