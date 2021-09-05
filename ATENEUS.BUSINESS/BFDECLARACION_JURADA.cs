
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFDECLARACIONJURADA.
	/// </summary>
	public class BFDECLARACIONJURADA
	{
		private DLDECLARACIONJURADA _objDAL;
		private DLDECLARACIONJURADAList _objDALList;
		
		public BFDECLARACIONJURADA()
		{
			_objDAL = new DLDECLARACIONJURADA();
			_objDALList = new DLDECLARACIONJURADAList();
		}

		public EDECLARACIONJURADA GetDECLARACIONJURADA()
		{
			return new EDECLARACIONJURADA();
		}

		public EDECLARACIONJURADA GetDECLARACIONJURADA(long id)
		{
            return new EDECLARACIONJURADA(id);
		}

		public bool Save(EDECLARACIONJURADA objDECLARACIONJURADA)
		{
			try
			{
				objDECLARACIONJURADA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EDECLARACIONJURADA> GetDECLARACIONJURADAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EDECLARACIONJURADA objDECLARACIONJURADA)
		{
			try
			{
                _objDAL.Delete(objDECLARACIONJURADA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EDECLARACIONJURADA objDECLARACIONJURADA)
        {
            try
            {
                _objDAL.Update(objDECLARACIONJURADA);
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

