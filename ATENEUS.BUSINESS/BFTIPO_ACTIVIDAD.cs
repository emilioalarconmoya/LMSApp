
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFTIPOACTIVIDAD.
	/// </summary>
	public class BFTIPOACTIVIDAD
	{
		private DLTIPOACTIVIDAD _objDAL;
		private DLTIPOACTIVIDADList _objDALList;
		
		public BFTIPOACTIVIDAD()
		{
			_objDAL = new DLTIPOACTIVIDAD();
			_objDALList = new DLTIPOACTIVIDADList();
		}

		public ETIPOACTIVIDAD GetTIPOACTIVIDAD()
		{
			return new ETIPOACTIVIDAD();
		}

		public ETIPOACTIVIDAD GetTIPOACTIVIDAD(long id)
		{
            return new ETIPOACTIVIDAD(id);
		}

		public bool Save(ETIPOACTIVIDAD objTIPOACTIVIDAD)
		{
			try
			{
				objTIPOACTIVIDAD.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ETIPOACTIVIDAD> GetTIPOACTIVIDADAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ETIPOACTIVIDAD objTIPOACTIVIDAD)
		{
			try
			{
                _objDAL.Delete(objTIPOACTIVIDAD);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ETIPOACTIVIDAD objTIPOACTIVIDAD)
        {
            try
            {
                _objDAL.Update(objTIPOACTIVIDAD);
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

