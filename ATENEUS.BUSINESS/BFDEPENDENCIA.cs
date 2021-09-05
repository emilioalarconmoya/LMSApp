
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFDEPENDENCIA.
	/// </summary>
	public class BFDEPENDENCIA
	{
		private DLDEPENDENCIA _objDAL;
		private DLDEPENDENCIAList _objDALList;
		
		public BFDEPENDENCIA()
		{
			_objDAL = new DLDEPENDENCIA();
			_objDALList = new DLDEPENDENCIAList();
		}

		public EDEPENDENCIA GetDEPENDENCIA()
		{
			return new EDEPENDENCIA();
		}

		public EDEPENDENCIA GetDEPENDENCIA(long id)
		{
            return new EDEPENDENCIA(id);
		}

		public bool Save(EDEPENDENCIA objDEPENDENCIA)
		{
			try
			{
				objDEPENDENCIA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EDEPENDENCIA> GetDEPENDENCIAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EDEPENDENCIA objDEPENDENCIA)
		{
			try
			{
                _objDAL.Delete(objDEPENDENCIA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EDEPENDENCIA objDEPENDENCIA)
        {
            try
            {
                _objDAL.Update(objDEPENDENCIA);
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

