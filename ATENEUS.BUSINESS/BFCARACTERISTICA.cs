
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFCARACTERISTICA.
	/// </summary>
	public class BFCARACTERISTICA
	{
		private DLCARACTERISTICA _objDAL;
		private DLCARACTERISTICAList _objDALList;
		
		public BFCARACTERISTICA()
		{
			_objDAL = new DLCARACTERISTICA();
			_objDALList = new DLCARACTERISTICAList();
		}

		public ECARACTERISTICA GetCARACTERISTICA()
		{
			return new ECARACTERISTICA();
		}

		public ECARACTERISTICA GetCARACTERISTICA(long id)
		{
            return new ECARACTERISTICA(id);
		}

		public bool Save(ECARACTERISTICA objCARACTERISTICA)
		{
			try
			{
				objCARACTERISTICA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ECARACTERISTICA> GetCARACTERISTICAAll(long codEmpresa)
		{
			return _objDALList.SelectAll(codEmpresa);
		}

        public bool Delete(ECARACTERISTICA objCARACTERISTICA)
		{
			try
			{
                _objDAL.Delete(objCARACTERISTICA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool EnUso(Int16 CodCaracterisitca)
        {
            try
            {
                return _objDAL.EnUso(CodCaracterisitca);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ECARACTERISTICA objCARACTERISTICA)
        {
            try
            {
                _objDAL.Update(objCARACTERISTICA);
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

