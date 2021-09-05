
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFACTIVIDADFORO.
	/// </summary>
	public class BFACTIVIDADFORO
	{
		private DLACTIVIDADFORO _objDAL;
		private DLACTIVIDADFOROList _objDALList;
		
		public BFACTIVIDADFORO()
		{
			_objDAL = new DLACTIVIDADFORO();
			_objDALList = new DLACTIVIDADFOROList();
		}

		public EACTIVIDADFORO GetACTIVIDADFORO()
		{
			return new EACTIVIDADFORO();
		}

		public EACTIVIDADFORO GetACTIVIDADFORO(long id)
		{
            return new EACTIVIDADFORO(id);
		}

		public bool Save(EACTIVIDADFORO objACTIVIDADFORO)
		{
			try
			{
				objACTIVIDADFORO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EACTIVIDADFORO> GetACTIVIDADFOROAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EACTIVIDADFORO objACTIVIDADFORO)
		{
			try
			{
                _objDAL.Delete(objACTIVIDADFORO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EACTIVIDADFORO objACTIVIDADFORO)
        {
            try
            {
                _objDAL.Update(objACTIVIDADFORO);
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

