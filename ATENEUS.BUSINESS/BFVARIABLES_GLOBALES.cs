
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFVARIABLESGLOBALES.
	/// </summary>
	public class BFVARIABLESGLOBALES
	{
		private DLVARIABLESGLOBALES _objDAL;
		private DLVARIABLESGLOBALESList _objDALList;
		
		public BFVARIABLESGLOBALES()
		{
			_objDAL = new DLVARIABLESGLOBALES();
			_objDALList = new DLVARIABLESGLOBALESList();
		}

		public EVARIABLESGLOBALES GetVARIABLESGLOBALES()
		{
			return new EVARIABLESGLOBALES();
		}

		public EVARIABLESGLOBALES GetVARIABLESGLOBALES(long id)
		{
            return new EVARIABLESGLOBALES(id);
		}

		public bool Save(EVARIABLESGLOBALES objVARIABLESGLOBALES)
		{
			try
			{
				objVARIABLESGLOBALES.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EVARIABLESGLOBALES> GetVARIABLESGLOBALESAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EVARIABLESGLOBALES objVARIABLESGLOBALES)
		{
			try
			{
                _objDAL.Delete(objVARIABLESGLOBALES);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EVARIABLESGLOBALES objVARIABLESGLOBALES)
        {
            try
            {
                _objDAL.Update(objVARIABLESGLOBALES);
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

