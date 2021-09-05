
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFPAGINATRADUCCION.
	/// </summary>
	public class BFPAGINATRADUCCION
	{
		private DLPAGINATRADUCCION _objDAL;
		private DLPAGINATRADUCCIONList _objDALList;
		
		public BFPAGINATRADUCCION()
		{
			_objDAL = new DLPAGINATRADUCCION();
			_objDALList = new DLPAGINATRADUCCIONList();
		}

		public EPAGINATRADUCCION GetPAGINATRADUCCION()
		{
			return new EPAGINATRADUCCION();
		}

		public EPAGINATRADUCCION GetPAGINATRADUCCION(long id)
		{
            return new EPAGINATRADUCCION(id);
		}

		public bool Save(EPAGINATRADUCCION objPAGINATRADUCCION)
		{
			try
			{
				objPAGINATRADUCCION.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EPAGINATRADUCCION> GetPAGINATRADUCCIONAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPAGINATRADUCCION objPAGINATRADUCCION)
		{
			try
			{
                _objDAL.Delete(objPAGINATRADUCCION);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EPAGINATRADUCCION objPAGINATRADUCCION)
        {
            try
            {
                _objDAL.Update(objPAGINATRADUCCION);
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

