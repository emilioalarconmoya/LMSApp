
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
	/// BFTIENDA.
	/// </summary>
	public class BFTIENDA
	{
		private DLTIENDA _objDAL;
		private DLTIENDAList _objDALList;
		
		public BFTIENDA()
		{
			_objDAL = new DLTIENDA();
			_objDALList = new DLTIENDAList();
		}

		public ETIENDA GetTIENDA()
		{
			return new ETIENDA();
		}

		public ETIENDA GetTIENDA(long id)
		{
            return new ETIENDA(id);
        }

        public ETIENDA GetTIENDA(string id)
        {
            return _objDALList.GetTiendasByCodigo(id);
        }

        public List<ETIENDA> GetTiendasByNombreAndFechas(String Nombre, DateTime Inicio, DateTime Fin,Int64  CodEmpresa)
        {
            return _objDALList.GetTiendasByNombreAndFechas(Nombre, Inicio, Fin,CodEmpresa);
        }

        public List<ETIENDA> GetTiendasActivasByRut(Int64 RutUsuario)
        {
            return _objDALList.GetTiendasActivasByRut(RutUsuario);
        }

        public DataTable GetTiendasByCodigoTienda(String CodigoTienda)
        {
            return _objDALList.GetTiendasByCodigoTienda(CodigoTienda);
        }

        public DataTable GetProductosTiendaActiva(String CodigoTienda, Int16 CodCategoria)
        {
            return _objDALList.GetProductosTiendaActiva(CodigoTienda, CodCategoria);
        }

        public DataTable GetProductosTiendaActiva(String CodigoTienda, Int16 CodCategoria, Int64 RutUsuario)
        {
            return _objDALList.GetProductosTiendaActiva(CodigoTienda, CodCategoria, RutUsuario);
        }

        public bool Save(ETIENDA objTIENDA)
		{
			try
			{
				objTIENDA.Save();
                foreach(EPRODUCTOTIENDA obj in objTIENDA.PRODUCTOS_TIENDA)
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

		public List<ETIENDA> GetTIENDAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ETIENDA objTIENDA)
		{
			try
			{
                _objDAL.Delete(objTIENDA);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ETIENDA objTIENDA)
        {
            try
            {
                _objDAL.Update(objTIENDA);
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

