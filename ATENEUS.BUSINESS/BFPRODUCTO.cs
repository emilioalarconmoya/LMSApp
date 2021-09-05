
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
	/// BFPRODUCTO.
	/// </summary>
	public class BFPRODUCTO
	{
		private DLPRODUCTO _objDAL;
		private DLPRODUCTOList _objDALList;
		
		public BFPRODUCTO()
		{
			_objDAL = new DLPRODUCTO();
			_objDALList = new DLPRODUCTOList();
		}

		public EPRODUCTO GetPRODUCTO()
		{
			return new EPRODUCTO();
		}

		public EPRODUCTO GetPRODUCTO(long id)
		{
            return new EPRODUCTO(id);
        }

        public EPRODUCTO GetPRODUCTO(String id)
        {
            return _objDALList.GetProductoByCodigo(id);
        }

        public DataTable GetProductoByNombreAndCategoria(String Nombre, Int16 CodCategoria,Int64 CodEmpresa)
        {
            return _objDALList.GetProductoByNombreAndCategoria(Nombre, CodCategoria,CodEmpresa);
        }

        public bool Save(EPRODUCTO objPRODUCTO)
		{
			try
			{
				objPRODUCTO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EPRODUCTO> GetPRODUCTOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPRODUCTO objPRODUCTO)
		{
			try
			{
                _objDAL.Delete(objPRODUCTO);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EPRODUCTO objPRODUCTO)
        {
            try
            {
                _objDAL.Update(objPRODUCTO);
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

