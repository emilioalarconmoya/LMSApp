
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFETIQUETAIDIOMA.
	/// </summary>
	public class BFETIQUETAIDIOMA
	{
		private DLETIQUETAIDIOMA _objDAL;
		private DLETIQUETAIDIOMAList _objDALList;
		
		public BFETIQUETAIDIOMA()
		{
			_objDAL = new DLETIQUETAIDIOMA();
			_objDALList = new DLETIQUETAIDIOMAList();
		}

		public EETIQUETAIDIOMA GetETIQUETAIDIOMA()
		{
			return new EETIQUETAIDIOMA();
		}

		public EETIQUETAIDIOMA GetETIQUETAIDIOMA(long id)
		{
            return new EETIQUETAIDIOMA(id);
		}

		public bool Save(EETIQUETAIDIOMA objETIQUETAIDIOMA)
		{
			try
			{
				objETIQUETAIDIOMA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EETIQUETAIDIOMA> GetETIQUETAIDIOMAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EETIQUETAIDIOMA objETIQUETAIDIOMA)
		{
			try
			{
                _objDAL.Delete(objETIQUETAIDIOMA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EETIQUETAIDIOMA objETIQUETAIDIOMA)
        {
            try
            {
                _objDAL.Update(objETIQUETAIDIOMA);
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

