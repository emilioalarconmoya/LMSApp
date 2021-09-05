
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFESTADOACTIVIDAD.
	/// </summary>
	public class BFESTADOACTIVIDAD
	{
		private DLESTADOACTIVIDAD _objDAL;
		private DLESTADOACTIVIDADList _objDALList;
		
		public BFESTADOACTIVIDAD()
		{
			_objDAL = new DLESTADOACTIVIDAD();
			_objDALList = new DLESTADOACTIVIDADList();
		}

		public EESTADOACTIVIDAD GetESTADOACTIVIDAD()
		{
			return new EESTADOACTIVIDAD();
		}

		public EESTADOACTIVIDAD GetESTADOACTIVIDAD(long id)
		{
            return new EESTADOACTIVIDAD(id);
		}

		public bool Save(EESTADOACTIVIDAD objESTADOACTIVIDAD)
		{
			try
			{
				objESTADOACTIVIDAD.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EESTADOACTIVIDAD> GetESTADOACTIVIDADAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EESTADOACTIVIDAD objESTADOACTIVIDAD)
		{
			try
			{
                _objDAL.Delete(objESTADOACTIVIDAD);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EESTADOACTIVIDAD objESTADOACTIVIDAD)
        {
            try
            {
                _objDAL.Update(objESTADOACTIVIDAD);
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

