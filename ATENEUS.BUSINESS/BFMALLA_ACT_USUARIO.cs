
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFMALLAACTUSUARIO.
	/// </summary>
	public class BFMALLAACTUSUARIO
	{
		private DLMALLAACTUSUARIO _objDAL;
		private DLMALLAACTUSUARIOList _objDALList;
		
		public BFMALLAACTUSUARIO()
		{
			_objDAL = new DLMALLAACTUSUARIO();
			_objDALList = new DLMALLAACTUSUARIOList();
		}

		public EMALLAACTUSUARIO GetMALLAACTUSUARIO()
		{
			return new EMALLAACTUSUARIO();
		}

		public EMALLAACTUSUARIO GetMALLAACTUSUARIO(long id)
		{
            return new EMALLAACTUSUARIO(id);
		}

		public bool Save(EMALLAACTUSUARIO objMALLAACTUSUARIO)
		{
			try
			{
				objMALLAACTUSUARIO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EMALLAACTUSUARIO> GetMALLAACTUSUARIOAll(Int64 CodEmpresa)
		{
			return _objDALList.SelectAll(CodEmpresa);
		}

        public bool Delete(EMALLAACTUSUARIO objMALLAACTUSUARIO)
		{
			try
			{
                _objDAL.Delete(objMALLAACTUSUARIO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EMALLAACTUSUARIO objMALLAACTUSUARIO)
        {
            try
            {
                _objDAL.Update(objMALLAACTUSUARIO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<EMALLAACTUSUARIO> GetMallasAsignadas(string listaRuts, string listaActividades, Int64 CodEmpresa)
        {
            return _objDALList.GetMallasAsignadas(listaRuts, listaActividades, CodEmpresa);
        }

    }
}

