
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFSUBMOTIVOCORREO.
	/// </summary>
	public class BFSUBMOTIVOCORREO
	{
		private DLSUBMOTIVOCORREO _objDAL;
		private DLSUBMOTIVOCORREOList _objDALList;
		
		public BFSUBMOTIVOCORREO()
		{
			_objDAL = new DLSUBMOTIVOCORREO();
			_objDALList = new DLSUBMOTIVOCORREOList();
		}

		public ESUBMOTIVOCORREO GetSUBMOTIVOCORREO()
		{
			return new ESUBMOTIVOCORREO();
		}

		public ESUBMOTIVOCORREO GetSUBMOTIVOCORREO(long id)
		{
            return new ESUBMOTIVOCORREO(id);
		}

		public bool Save(ESUBMOTIVOCORREO objSUBMOTIVOCORREO)
		{
			try
			{
				objSUBMOTIVOCORREO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ESUBMOTIVOCORREO> GetSUBMOTIVOCORREOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ESUBMOTIVOCORREO objSUBMOTIVOCORREO)
		{
			try
			{
                _objDAL.Delete(objSUBMOTIVOCORREO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ESUBMOTIVOCORREO objSUBMOTIVOCORREO)
        {
            try
            {
                _objDAL.Update(objSUBMOTIVOCORREO);
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

