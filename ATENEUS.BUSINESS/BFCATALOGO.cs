
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFCATALOGO.
	/// </summary>
	public class BFCATALOGO
	{
		private DLCATALOGO _objDAL;
		private DLCATALOGOList _objDALList;
		
		public BFCATALOGO()
		{
			_objDAL = new DLCATALOGO();
			_objDALList = new DLCATALOGOList();
		}

		public ECATALOGO GetCATALOGO()
		{
			return new ECATALOGO();
		}

		public ECATALOGO GetCATALOGO(long id)
		{
            return new ECATALOGO(id);
		}

		public int Save(ECATALOGO objCATALOGO)
		{
			try
			{
				objCATALOGO.Save();
                return objCATALOGO.Codcatalogo;
            }
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return 0;
            }
        }

		public List<ECATALOGO> GetCATALOGOAll(Int64 codEmpresa)
		{
			return _objDALList.SelectAll(codEmpresa);
		}

        public bool Delete(ECATALOGO objCATALOGO)
		{
			try
			{
                _objDAL.Delete(objCATALOGO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ECATALOGO objCATALOGO)
        {
            try
            {
                _objDAL.Update(objCATALOGO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ECATALOGO> GetCatalogoParametros(string Nombre, Int16 codEstado, Int64 codEmpresa)
        {
            return _objDALList.SelectBuscadorCatalogoParametros(Nombre, codEstado, codEmpresa);
        }

    }
}

