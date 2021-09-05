
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFASIGNAMOVIMIENTO.
	/// </summary>
	public class BFASIGNAMOVIMIENTO
	{
		private DLASIGNAMOVIMIENTO _objDAL;
		private DLASIGNAMOVIMIENTOList _objDALList;
		
		public BFASIGNAMOVIMIENTO()
		{
			_objDAL = new DLASIGNAMOVIMIENTO();
			_objDALList = new DLASIGNAMOVIMIENTOList();
		}

		public EASIGNAMOVIMIENTO GetASIGNAMOVIMIENTO()
		{
			return new EASIGNAMOVIMIENTO();
		}

		public EASIGNAMOVIMIENTO GetASIGNAMOVIMIENTO(long id)
		{
            return new EASIGNAMOVIMIENTO(id);
		}

		public bool Save(EASIGNAMOVIMIENTO objASIGNAMOVIMIENTO)
		{
			try
			{
				objASIGNAMOVIMIENTO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EASIGNAMOVIMIENTO> GetASIGNAMOVIMIENTOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EASIGNAMOVIMIENTO objASIGNAMOVIMIENTO)
		{
			try
			{
                _objDAL.Delete(objASIGNAMOVIMIENTO);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EASIGNAMOVIMIENTO objASIGNAMOVIMIENTO)
        {
            try
            {
                _objDAL.Update(objASIGNAMOVIMIENTO);
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

