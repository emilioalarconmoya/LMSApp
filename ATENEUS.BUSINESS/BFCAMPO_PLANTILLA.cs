
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
//using ATENEUS.BUSINESS.Collections;
using ATENEUS.CLASES.DAL;
//using Moebius.ErrorManagement;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFCAMPOPLANTILLA.
	/// </summary>
	public class BFCAMPOPLANTILLA
	{
		private DLCAMPOPLANTILLA _objDAL;
		private DLCAMPOPLANTILLAList _objDALList;
		
		public BFCAMPOPLANTILLA()
		{
			_objDAL = new DLCAMPOPLANTILLA();
			_objDALList = new DLCAMPOPLANTILLAList();
		}

		public ECAMPOPLANTILLA GetCAMPOPLANTILLA()
		{
			return new ECAMPOPLANTILLA();
		}

		public ECAMPOPLANTILLA GetCAMPOPLANTILLA(long id)
		{
            return new ECAMPOPLANTILLA(id);
		}

		public bool Save(ECAMPOPLANTILLA objCAMPOPLANTILLA)
		{
			try
			{
				objCAMPOPLANTILLA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ECAMPOPLANTILLA> GetCAMPOPLANTILLAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ECAMPOPLANTILLA objCAMPOPLANTILLA)
		{
			try
			{
                _objDAL.Delete(objCAMPOPLANTILLA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ECAMPOPLANTILLA objCAMPOPLANTILLA)
        {
            try
            {
                _objDAL.Update(objCAMPOPLANTILLA);
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

