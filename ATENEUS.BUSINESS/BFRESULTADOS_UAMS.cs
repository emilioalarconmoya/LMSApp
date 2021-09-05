
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFRESULTADOSUAMS.
	/// </summary>
	public class BFRESULTADOSUAMS
	{
		private DLRESULTADOSUAMS _objDAL;
		private DLRESULTADOSUAMSList _objDALList;
		
		public BFRESULTADOSUAMS()
		{
			_objDAL = new DLRESULTADOSUAMS();
			_objDALList = new DLRESULTADOSUAMSList();
		}

		public ERESULTADOSUAMS GetRESULTADOSUAMS()
		{
			return new ERESULTADOSUAMS();
		}

		public ERESULTADOSUAMS GetRESULTADOSUAMS(long id)
		{
            return new ERESULTADOSUAMS(id);
		}

		public bool Save(ERESULTADOSUAMS objRESULTADOSUAMS)
		{
			try
			{
				objRESULTADOSUAMS.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ERESULTADOSUAMS> GetRESULTADOSUAMSAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ERESULTADOSUAMS objRESULTADOSUAMS)
		{
			try
			{
                _objDAL.Delete(objRESULTADOSUAMS);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ERESULTADOSUAMS objRESULTADOSUAMS)
        {
            try
            {
                _objDAL.Update(objRESULTADOSUAMS);
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

