
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFCATEGORIAPRODUCTO.
	/// </summary>
	public class BFCATEGORIAACTIVIDAD
	{
		private DLCATEGORIAACTIVIDAD _objDAL;
		private DLCATEGORIAACTIVIDADList _objDALList;
		
		public BFCATEGORIAACTIVIDAD()
		{
			_objDAL = new DLCATEGORIAACTIVIDAD();
			_objDALList = new DLCATEGORIAACTIVIDADList();
		}

		public ECATAGORIAACTIVIDAD GetCATEGORIAPRODUCTO()
		{
			return new ECATAGORIAACTIVIDAD();
		}

		public ECATAGORIAACTIVIDAD GetCATEGORIAPRODUCTO(long id)
		{
            return new ECATAGORIAACTIVIDAD(id);
		}

		public bool Save(ECATAGORIAACTIVIDAD objCATEGORIAACTIVIDAD)
		{
			try
			{
                objCATEGORIAACTIVIDAD.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
        }

        public bool Save(List<ECATAGORIAACTIVIDAD> Lista)
        {
            try
            {
                foreach (ECATAGORIAACTIVIDAD obj in Lista)
                {
                    obj.Save();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ECATAGORIAACTIVIDAD> GetCATEGORIAACTIVIDADAll(Int64 codEmpresa)
		{
			return _objDALList.SelectAll(codEmpresa);
        }

        //public List<ECATEGORIAPRODUCTO> GetCategoriaProductoByTienda(string CodTienda)
        //{
        //    return _objDALList.GetCategoriaProductoByTienda(CodTienda);
        //}

        public bool Delete(ECATAGORIAACTIVIDAD objCATEGORIAACTIVIDAD)
		{
			try
			{
                _objDAL.Delete(objCATEGORIAACTIVIDAD);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ECATAGORIAACTIVIDAD objCATEGORIAACTIVIDAD)
        {
            try
            {
                _objDAL.Update(objCATEGORIAACTIVIDAD);
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

