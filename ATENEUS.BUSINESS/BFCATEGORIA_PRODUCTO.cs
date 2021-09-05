
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
	public class BFCATEGORIAPRODUCTO
	{
		private DLCATEGORIAPRODUCTO _objDAL;
		private DLCATEGORIAPRODUCTOList _objDALList;
		
		public BFCATEGORIAPRODUCTO()
		{
			_objDAL = new DLCATEGORIAPRODUCTO();
			_objDALList = new DLCATEGORIAPRODUCTOList();
		}

		public ECATEGORIAPRODUCTO GetCATEGORIAPRODUCTO()
		{
			return new ECATEGORIAPRODUCTO();
		}

		public ECATEGORIAPRODUCTO GetCATEGORIAPRODUCTO(long id)
		{
            return new ECATEGORIAPRODUCTO(id);
		}

		public bool Save(ECATEGORIAPRODUCTO objCATEGORIAPRODUCTO)
		{
			try
			{
				objCATEGORIAPRODUCTO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
        }

        public bool Save(List<ECATEGORIAPRODUCTO> Lista)
        {
            try
            {
                foreach (ECATEGORIAPRODUCTO obj in Lista)
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

        public List<ECATEGORIAPRODUCTO> GetCATEGORIAPRODUCTOAll()
		{
			return _objDALList.SelectAll();
        }

        public List<ECATEGORIAPRODUCTO> GetCategoriaProductoByTienda(string CodTienda)
        {
            return _objDALList.GetCategoriaProductoByTienda(CodTienda);
        }

        public bool Delete(ECATEGORIAPRODUCTO objCATEGORIAPRODUCTO)
		{
			try
			{
                _objDAL.Delete(objCATEGORIAPRODUCTO);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ECATEGORIAPRODUCTO objCATEGORIAPRODUCTO)
        {
            try
            {
                _objDAL.Update(objCATEGORIAPRODUCTO);
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

