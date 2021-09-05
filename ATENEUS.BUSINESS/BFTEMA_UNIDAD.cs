
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFTEMAUNIDAD.
	/// </summary>
	public class BFTEMAUNIDAD
	{
		private DLTEMAUNIDAD _objDAL;
		private DLTEMAUNIDADList _objDALList;
		
		public BFTEMAUNIDAD()
		{
			_objDAL = new DLTEMAUNIDAD();
			_objDALList = new DLTEMAUNIDADList();
		}

		public ETEMAUNIDAD GetTEMAUNIDAD()
		{
			return new ETEMAUNIDAD();
		}

		public ETEMAUNIDAD GetTEMAUNIDAD(long id)
		{
            return new ETEMAUNIDAD(id);
		}

		public bool Save(ETEMAUNIDAD objTEMAUNIDAD)
		{
			try
			{
				objTEMAUNIDAD.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ETEMAUNIDAD> GetTEMAUNIDADAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ETEMAUNIDAD objTEMAUNIDAD)
		{
			try
			{
                _objDAL.Delete(objTEMAUNIDAD);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ETEMAUNIDAD objTEMAUNIDAD)
        {
            try
            {
                _objDAL.Update(objTEMAUNIDAD);
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

