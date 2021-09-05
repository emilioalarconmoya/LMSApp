
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFIDIOMA.
	/// </summary>
	public class BFIDIOMA
	{
		private DLIDIOMA _objDAL;
		private DLIDIOMAList _objDALList;
		
		public BFIDIOMA()
		{
			_objDAL = new DLIDIOMA();
			_objDALList = new DLIDIOMAList();
		}

		public EIDIOMA GetIDIOMA()
		{
			return new EIDIOMA();
		}

		public EIDIOMA GetIDIOMA(long id)
		{
            return new EIDIOMA(id);
		}

		public bool Save(EIDIOMA objIDIOMA)
		{
			try
			{
				objIDIOMA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EIDIOMA> GetIDIOMAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EIDIOMA objIDIOMA)
		{
			try
			{
                _objDAL.Delete(objIDIOMA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EIDIOMA objIDIOMA)
        {
            try
            {
                _objDAL.Update(objIDIOMA);
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

