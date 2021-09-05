
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFMARCADISPOSITIVO.
	/// </summary>
	public class BFMARCADISPOSITIVO
	{
		private DLMARCADISPOSITIVO _objDAL;
		private DLMARCADISPOSITIVOList _objDALList;
		
		public BFMARCADISPOSITIVO()
		{
			_objDAL = new DLMARCADISPOSITIVO();
			_objDALList = new DLMARCADISPOSITIVOList();
		}

		public EMARCADISPOSITIVO GetMARCADISPOSITIVO()
		{
			return new EMARCADISPOSITIVO();
		}

		public EMARCADISPOSITIVO GetMARCADISPOSITIVO(long id)
		{
            return new EMARCADISPOSITIVO(id);
		}

		public bool Save(EMARCADISPOSITIVO objMARCADISPOSITIVO)
		{
			try
			{
				objMARCADISPOSITIVO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EMARCADISPOSITIVO> GetMARCADISPOSITIVOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EMARCADISPOSITIVO objMARCADISPOSITIVO)
		{
			try
			{
                _objDAL.Delete(objMARCADISPOSITIVO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EMARCADISPOSITIVO objMARCADISPOSITIVO)
        {
            try
            {
                _objDAL.Update(objMARCADISPOSITIVO);
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

