
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFOBJETO.
	/// </summary>
	public class BFOBJETO
	{
		private DLOBJETO _objDAL;
		private DLOBJETOList _objDALList;
		
		public BFOBJETO()
		{
			_objDAL = new DLOBJETO();
			_objDALList = new DLOBJETOList();
		}

		public EOBJETO GetOBJETO()
		{
			return new EOBJETO();
		}

		public EOBJETO GetOBJETO(long id)
		{
            return new EOBJETO(id);
		}

		public bool Save(EOBJETO objOBJETO)
		{
			try
			{
				objOBJETO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EOBJETO> GetOBJETOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EOBJETO objOBJETO)
		{
			try
			{
                _objDAL.Delete(objOBJETO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EOBJETO objOBJETO)
        {
            try
            {
                _objDAL.Update(objOBJETO);
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

