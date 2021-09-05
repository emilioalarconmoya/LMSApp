
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFPERFILOBJETO.
	/// </summary>
	public class BFPERFILOBJETO
	{
		private DLPERFILOBJETO _objDAL;
		private DLPERFILOBJETOList _objDALList;
		
		public BFPERFILOBJETO()
		{
			_objDAL = new DLPERFILOBJETO();
			_objDALList = new DLPERFILOBJETOList();
		}

		public EPERFILOBJETO GetPERFILOBJETO()
		{
			return new EPERFILOBJETO();
		}

		public EPERFILOBJETO GetPERFILOBJETO(long id)
		{
            return new EPERFILOBJETO(id);
		}

		public bool Save(EPERFILOBJETO objPERFILOBJETO)
		{
			try
			{
				objPERFILOBJETO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EPERFILOBJETO> GetPERFILOBJETOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPERFILOBJETO objPERFILOBJETO)
		{
			try
			{
                _objDAL.Delete(objPERFILOBJETO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EPERFILOBJETO objPERFILOBJETO)
        {
            try
            {
                _objDAL.Update(objPERFILOBJETO);
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

