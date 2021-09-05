
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFSESION.
	/// </summary>
	public class BFSESION
	{
		private DLSESION _objDAL;
		private DLSESIONList _objDALList;
		
		public BFSESION()
		{
			_objDAL = new DLSESION();
			_objDALList = new DLSESIONList();
		}

		public ESESION GetSESION()
		{
			return new ESESION();
		}

		public ESESION GetSESION(long id)
		{
            return new ESESION(id);
		}

		public bool Save(ESESION objSESION)
		{
			try
			{
				objSESION.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ESESION> GetSESIONAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ESESION objSESION)
		{
			try
			{
                _objDAL.Delete(objSESION);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ESESION objSESION)
        {
            try
            {
                _objDAL.Update(objSESION);
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

