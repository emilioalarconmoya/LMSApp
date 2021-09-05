
using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFPRODUCTOCANJEADO.
	/// </summary>
	public class BFPRODUCTOCANJEADO
	{
		private DLPRODUCTOCANJEADO _objDAL;
		private DLPRODUCTOCANJEADOList _objDALList;
		
		public BFPRODUCTOCANJEADO()
		{
			_objDAL = new DLPRODUCTOCANJEADO();
			_objDALList = new DLPRODUCTOCANJEADOList();
		}

		public EPRODUCTOCANJEADO GetPRODUCTOCANJEADO()
		{
			return new EPRODUCTOCANJEADO();
		}

		public EPRODUCTOCANJEADO GetPRODUCTOCANJEADO(long id)
		{
            return new EPRODUCTOCANJEADO(id);
		}

		public bool Save(EPRODUCTOCANJEADO objPRODUCTOCANJEADO)
		{
			try
			{
				objPRODUCTOCANJEADO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
        }

        public bool Save(List<EPRODUCTOCANJEADO> Lista)
        {
            try
            {
                foreach (EPRODUCTOCANJEADO obj in Lista)
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

        public List<EPRODUCTOCANJEADO> GetPRODUCTOCANJEADOAll()
		{
			return _objDALList.SelectAll();
        }

        public DataTable GetCanjesByRut(Int64 Rut)
        {
            return _objDALList.GetCanjesByRut(Rut);
        }

        public DataTable GetProductoCanjeadoByCodMovimiento(Decimal CodMovimiento)
        {
            return _objDALList.GetProductoCanjeadoByCodMovimiento(CodMovimiento);
        }

        public DataTable GetCanjesByRutAndTienda(Int64 Rut, string CodTienda, DateTime Inicio, DateTime Fin)
        {
            return _objDALList.GetCanjesByRutAndTienda(Rut, CodTienda, Inicio, Fin);
        }

        public bool Delete(EPRODUCTOCANJEADO objPRODUCTOCANJEADO)
		{
			try
			{
                _objDAL.Delete(objPRODUCTOCANJEADO);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EPRODUCTOCANJEADO objPRODUCTOCANJEADO)
        {
            try
            {
                _objDAL.Update(objPRODUCTOCANJEADO);
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

