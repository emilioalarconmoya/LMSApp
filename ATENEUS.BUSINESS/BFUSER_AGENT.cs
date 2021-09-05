
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFUSERAGENT.
	/// </summary>
	public class BFUSERAGENT
	{
		private DLUSERAGENT _objDAL;
		private DLUSERAGENTList _objDALList;
		
		public BFUSERAGENT()
		{
			_objDAL = new DLUSERAGENT();
			_objDALList = new DLUSERAGENTList();
		}

		public EUSERAGENT GetUSERAGENT()
		{
			return new EUSERAGENT();
		}

		public EUSERAGENT GetUSERAGENT(long id)
		{
            return new EUSERAGENT(id);
		}

		public bool Save(EUSERAGENT objUSERAGENT)
		{
			try
			{
				objUSERAGENT.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EUSERAGENT> GetUSERAGENTAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EUSERAGENT objUSERAGENT)
		{
			try
			{
                _objDAL.Delete(objUSERAGENT);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EUSERAGENT objUSERAGENT)
        {
            try
            {
                _objDAL.Update(objUSERAGENT);
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

