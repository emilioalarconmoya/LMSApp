
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFPRODUCTOTIENDA.
	/// </summary>
	public class BFPRODUCTOTIENDA
	{
		private DLPRODUCTOTIENDA _objDAL;
		private DLPRODUCTOTIENDAList _objDALList;
		
		public BFPRODUCTOTIENDA()
		{
			_objDAL = new DLPRODUCTOTIENDA();
			_objDALList = new DLPRODUCTOTIENDAList();
		}

		public EPRODUCTOTIENDA GetPRODUCTOTIENDA()
		{
			return new EPRODUCTOTIENDA();
		}

		public EPRODUCTOTIENDA GetPRODUCTOTIENDA(long id)
		{
            return new EPRODUCTOTIENDA(id);
		}

		public bool Save(EPRODUCTOTIENDA objPRODUCTOTIENDA)
		{
			try
			{
				objPRODUCTOTIENDA.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EPRODUCTOTIENDA> GetPRODUCTOTIENDAAll()
		{
			return _objDALList.SelectAll();
        }

        public EPRODUCTOTIENDA GetProductoTienda(string CodTienda, string CodProducto)
        {
            return _objDALList.GetProductoTienda(CodTienda, CodProducto);
        }

        public bool Delete(EPRODUCTOTIENDA objPRODUCTOTIENDA)
		{
			try
			{
                _objDAL.Delete(objPRODUCTOTIENDA);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EPRODUCTOTIENDA objPRODUCTOTIENDA)
        {
            try
            {
                _objDAL.Update(objPRODUCTOTIENDA);
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

