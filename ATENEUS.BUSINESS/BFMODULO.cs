
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFMODULO.
	/// </summary>
	public class BFMODULO
	{
		private DLMODULO _objDAL;
		private DLMODULOList _objDALList;
		
		public BFMODULO()
		{
			_objDAL = new DLMODULO();
			_objDALList = new DLMODULOList();
		}

		public EMODULO GetMODULO()
		{
			return new EMODULO();
		}

		public EMODULO GetMODULO(long id)
		{
            return new EMODULO(id);
		}

		public bool Save(EMODULO objMODULO)
		{
			try
			{
				objMODULO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EMODULO> GetMODULOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EMODULO objMODULO)
		{
			try
			{
                _objDAL.Delete(objMODULO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EMODULO objMODULO)
        {
            try
            {
                _objDAL.Update(objMODULO);
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

