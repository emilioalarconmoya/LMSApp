
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
	/// BFAVISOSHOME.
	/// </summary>
	public class BFAVISOSHOME
	{
		private DLAVISOSHOME _objDAL;
		private DLAVISOSHOMEList _objDALList;
		
		public BFAVISOSHOME()
		{
			_objDAL = new DLAVISOSHOME();
			_objDALList = new DLAVISOSHOMEList();
		}

		public EAVISOSHOME GetAVISOSHOME()
		{
			return new EAVISOSHOME();
		}

		public EAVISOSHOME GetAVISOSHOME(long id)
		{
            return new EAVISOSHOME(id);
		}

		public bool Save(EAVISOSHOME objAVISOSHOME)
		{
			try
			{
				objAVISOSHOME.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EAVISOSHOME> GetAVISOSHOMEAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EAVISOSHOME objAVISOSHOME)
		{
			try
			{
                _objDAL.Delete(objAVISOSHOME);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EAVISOSHOME objAVISOSHOME)
        {
            try
            {
                _objDAL.Update(objAVISOSHOME);
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

