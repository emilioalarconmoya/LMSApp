
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using System.Data;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFFORO.
	/// </summary>
	public class BFFORO
	{
		private DLFORO _objDAL;
		private DLFOROList _objDALList;
		
		public BFFORO()
		{
			_objDAL = new DLFORO();
			_objDALList = new DLFOROList();
		}

		public EFORO GetFORO()
		{
			return new EFORO();
		}

		public EFORO GetFORO(long id)
		{
            return new EFORO(id);
		}

		public bool Save(EFORO objFORO)
		{
			try
			{
				objFORO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EFORO> GetFOROAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EFORO objFORO)
		{
			try
			{
                _objDAL.Delete(objFORO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EFORO objFORO)
        {
            try
            {
                _objDAL.Update(objFORO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DataTable GetForoActividad(Int32 CodActividad)
        {
            return _objDALList.SelectForoActividad(CodActividad);
        }

        public DataTable GetTemasForo(int IdForo, Int64 CodEmpresa)
        {
            return _objDALList.SelectTemasForo(IdForo, CodEmpresa);
        }

        public DataTable GetRespuestaForo(int IdHead, Int64 CodEmpresa)
        {
            return _objDALList.SelectRespuestasForo(IdHead, CodEmpresa);
        }

        public Boolean ExisteForoActividad(Int32 CodActividad)
        {
            return _objDALList.ExisteForoActividad(CodActividad);
        }

        public Boolean ExisteForoUnidad(Int32 CodUnidad)
        {
            return _objDALList.ExisteForoUnidad(CodUnidad);
        }

        public Int16 SerialForo()
        {
            return _objDALList.SerialForo();
        }

    }
}

