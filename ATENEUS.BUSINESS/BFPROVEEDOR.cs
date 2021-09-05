
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFPROVEEDOR.
	/// </summary>
	public class BFPROVEEDOR
	{
		private DLPROVEEDOR _objDAL;
		private DLPROVEEDORList _objDALList;
		
		public BFPROVEEDOR()
		{
			_objDAL = new DLPROVEEDOR();
			_objDALList = new DLPROVEEDORList();
		}

		public EPROVEEDOR GetPROVEEDOR()
		{
			return new EPROVEEDOR();
		}

		public EPROVEEDOR GetPROVEEDOR(long id)
		{
            return new EPROVEEDOR(id);
		}

		public bool Save(EPROVEEDOR objPROVEEDOR)
		{
			try
			{
				objPROVEEDOR.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EPROVEEDOR> GetPROVEEDORAll(Int64 CodEmpresa)
		{
			return _objDALList.SelectAll(CodEmpresa);
		}

        public bool Delete(EPROVEEDOR objPROVEEDOR)
		{
			try
			{
                _objDAL.Delete(objPROVEEDOR);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EPROVEEDOR objPROVEEDOR)
        {
            try
            {
                _objDAL.Update(objPROVEEDOR);
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

