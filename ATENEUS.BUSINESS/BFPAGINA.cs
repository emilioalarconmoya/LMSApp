
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFPAGINA.
	/// </summary>
	public class BFPAGINA
	{
		private DLPAGINA _objDAL;
		private DLPAGINAList _objDALList;
		
		public BFPAGINA()
		{
			_objDAL = new DLPAGINA();
			_objDALList = new DLPAGINAList();
		}

		public EPAGINA GetPAGINA()
		{
			return new EPAGINA();
		}

		public EPAGINA GetPAGINA(long id)
		{
            return new EPAGINA(id);
		}

		public bool Save(EPAGINA objPAGINA)
		{
			try
			{
				objPAGINA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EPAGINA> GetPAGINAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPAGINA objPAGINA)
		{
			try
			{
                _objDAL.Delete(objPAGINA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EPAGINA objPAGINA)
        {
            try
            {
                _objDAL.Update(objPAGINA);
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

