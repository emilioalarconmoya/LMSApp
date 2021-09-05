
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFCAMPO.
	/// </summary>
	public class BFCAMPO
	{
		private DLCAMPO _objDAL;
		private DLCAMPOList _objDALList;
		
		public BFCAMPO()
		{
			_objDAL = new DLCAMPO();
			_objDALList = new DLCAMPOList();
		}

		public ECAMPO GetCAMPO()
		{
			return new ECAMPO();
		}

		public ECAMPO GetCAMPO(long id)
		{
            return new ECAMPO(id);
		}

		public bool Save(ECAMPO objCAMPO)
		{
			try
			{
				objCAMPO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ECAMPO> GetCAMPOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ECAMPO objCAMPO)
		{
			try
			{
                _objDAL.Delete(objCAMPO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ECAMPO objCAMPO)
        {
            try
            {
                _objDAL.Update(objCAMPO);
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

