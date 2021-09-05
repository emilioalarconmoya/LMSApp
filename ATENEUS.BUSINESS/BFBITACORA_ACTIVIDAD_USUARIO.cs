
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFBITACORAACTIVIDADUSUARIO.
	/// </summary>
	public class BFBITACORAACTIVIDADUSUARIO
	{
		private DLBITACORAACTIVIDADUSUARIO _objDAL;
		private DLBITACORAACTIVIDADUSUARIOList _objDALList;
		
		public BFBITACORAACTIVIDADUSUARIO()
		{
			_objDAL = new DLBITACORAACTIVIDADUSUARIO();
			_objDALList = new DLBITACORAACTIVIDADUSUARIOList();
		}

		public EBITACORAACTIVIDADUSUARIO GetBITACORAACTIVIDADUSUARIO()
		{
			return new EBITACORAACTIVIDADUSUARIO();
		}

		public EBITACORAACTIVIDADUSUARIO GetBITACORAACTIVIDADUSUARIO(long id)
		{
            return new EBITACORAACTIVIDADUSUARIO(id);
		}

		public bool Save(EBITACORAACTIVIDADUSUARIO objBITACORAACTIVIDADUSUARIO)
		{
			try
			{
				objBITACORAACTIVIDADUSUARIO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EBITACORAACTIVIDADUSUARIO> GetBITACORAACTIVIDADUSUARIOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EBITACORAACTIVIDADUSUARIO objBITACORAACTIVIDADUSUARIO)
		{
			try
			{
                _objDAL.Delete(objBITACORAACTIVIDADUSUARIO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EBITACORAACTIVIDADUSUARIO objBITACORAACTIVIDADUSUARIO)
        {
            try
            {
                _objDAL.Update(objBITACORAACTIVIDADUSUARIO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DateTime FechaHoraUltimaBitacora(long CodActivUsr)
        {
            DateTime FechaHora = DateTime.Now;
            try
            {
                FechaHora = _objDAL.FechaHoraUltimaBitacora(CodActivUsr);
                return FechaHora;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return DateTime.Now;
            }
        }

	}
}

