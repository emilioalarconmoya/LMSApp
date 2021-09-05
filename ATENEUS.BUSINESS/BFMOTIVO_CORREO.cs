
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFMOTIVOCORREO.
	/// </summary>
	public class BFMOTIVOCORREO
	{
		private DLMOTIVOCORREO _objDAL;
		private DLMOTIVOCORREOList _objDALList;
		
		public BFMOTIVOCORREO()
		{
			_objDAL = new DLMOTIVOCORREO();
			_objDALList = new DLMOTIVOCORREOList();
		}

		public EMOTIVOCORREO GetMOTIVOCORREO()
		{
			return new EMOTIVOCORREO();
		}

		public EMOTIVOCORREO GetMOTIVOCORREO(long id)
		{
            return new EMOTIVOCORREO(id);
		}

		public bool Save(EMOTIVOCORREO objMOTIVOCORREO)
		{
			try
			{
				objMOTIVOCORREO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EMOTIVOCORREO> GetMOTIVOCORREOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EMOTIVOCORREO objMOTIVOCORREO)
		{
			try
			{
                _objDAL.Delete(objMOTIVOCORREO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EMOTIVOCORREO objMOTIVOCORREO)
        {
            try
            {
                _objDAL.Update(objMOTIVOCORREO);
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

