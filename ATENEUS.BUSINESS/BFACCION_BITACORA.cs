
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
  
namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFACCIONBITACORA.
	/// </summary>
	public class BFACCIONBITACORA
	{
		private DLACCIONBITACORA _objDAL;
		private DLACCIONBITACORAList _objDALList;
		
		public BFACCIONBITACORA()
		{
			_objDAL = new DLACCIONBITACORA();
			_objDALList = new DLACCIONBITACORAList();
		}

		public EACCIONBITACORA GetACCIONBITACORA()
		{
			return new EACCIONBITACORA();
		}

		public EACCIONBITACORA GetACCIONBITACORA(long id)
		{
            return new EACCIONBITACORA(id);
		}

		public bool Save(EACCIONBITACORA objACCIONBITACORA)
		{
			try
			{
				objACCIONBITACORA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EACCIONBITACORA> GetACCIONBITACORAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EACCIONBITACORA objACCIONBITACORA)
		{
			try
			{
                _objDAL.Delete(objACCIONBITACORA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EACCIONBITACORA objACCIONBITACORA)
        {
            try
            {
                _objDAL.Update(objACCIONBITACORA);
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

