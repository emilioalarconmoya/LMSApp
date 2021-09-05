
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFBITACORANAVEGACION.
	/// </summary>
	public class BFBITACORANAVEGACION
	{
		private DLBITACORANAVEGACION _objDAL;
		private DLBITACORANAVEGACIONList _objDALList;
		
		public BFBITACORANAVEGACION()
		{
			_objDAL = new DLBITACORANAVEGACION();
			_objDALList = new DLBITACORANAVEGACIONList();
		}

		public EBITACORANAVEGACION GetBITACORANAVEGACION()
		{
			return new EBITACORANAVEGACION();
		}

		public EBITACORANAVEGACION GetBITACORANAVEGACION(long id)
		{
            return new EBITACORANAVEGACION(id);
		}

		public bool Save(EBITACORANAVEGACION objBITACORANAVEGACION)
		{
			try
			{
				objBITACORANAVEGACION.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EBITACORANAVEGACION> GetBITACORANAVEGACIONAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EBITACORANAVEGACION objBITACORANAVEGACION)
		{
			try
			{
                _objDAL.Delete(objBITACORANAVEGACION);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EBITACORANAVEGACION objBITACORANAVEGACION)
        {
            try
            {
                _objDAL.Update(objBITACORANAVEGACION);
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

