
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFUNIDADFORO.
	/// </summary>
	public class BFUNIDADFORO
	{
		private DLUNIDADFORO _objDAL;
		private DLUNIDADFOROList _objDALList;
		
		public BFUNIDADFORO()
		{
			_objDAL = new DLUNIDADFORO();
			_objDALList = new DLUNIDADFOROList();
		}

		public EUNIDADFORO GetUNIDADFORO()
		{
			return new EUNIDADFORO();
		}

		public EUNIDADFORO GetUNIDADFORO(long id)
		{
            return new EUNIDADFORO(id);
		}

		public bool Save(EUNIDADFORO objUNIDADFORO)
		{
			try
			{
				objUNIDADFORO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EUNIDADFORO> GetUNIDADFOROAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EUNIDADFORO objUNIDADFORO)
		{
			try
			{
                _objDAL.Delete(objUNIDADFORO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EUNIDADFORO objUNIDADFORO)
        {
            try
            {
                _objDAL.Update(objUNIDADFORO);
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

