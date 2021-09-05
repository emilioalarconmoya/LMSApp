
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFBITACORAADMINISTRACION.
	/// </summary>
	public class BFBITACORAADMINISTRACION
	{
		private DLBITACORAADMINISTRACION _objDAL;
		private DLBITACORAADMINISTRACIONList _objDALList;
		
		public BFBITACORAADMINISTRACION()
		{
			_objDAL = new DLBITACORAADMINISTRACION();
			_objDALList = new DLBITACORAADMINISTRACIONList();
		}

		public EBITACORAADMINISTRACION GetBITACORAADMINISTRACION()
		{
			return new EBITACORAADMINISTRACION();
		}

		public EBITACORAADMINISTRACION GetBITACORAADMINISTRACION(long id)
		{
            return new EBITACORAADMINISTRACION(id);
		}

		public bool Save(EBITACORAADMINISTRACION objBITACORAADMINISTRACION)
		{
			try
			{
				objBITACORAADMINISTRACION.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EBITACORAADMINISTRACION> GetBITACORAADMINISTRACIONAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EBITACORAADMINISTRACION objBITACORAADMINISTRACION)
		{
			try
			{
                _objDAL.Delete(objBITACORAADMINISTRACION);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EBITACORAADMINISTRACION objBITACORAADMINISTRACION)
        {
            try
            {
                _objDAL.Update(objBITACORAADMINISTRACION);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

	}
}

