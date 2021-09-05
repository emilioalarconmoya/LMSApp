
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFACTIVIDADMALLA.
	/// </summary>
	public class BFACTIVIDADMALLA
	{
		private DLACTIVIDADMALLA _objDAL;
		private DLACTIVIDADMALLAList _objDALList;
		
		public BFACTIVIDADMALLA()
		{
			_objDAL = new DLACTIVIDADMALLA();
			_objDALList = new DLACTIVIDADMALLAList();
		}

		public EACTIVIDADMALLA GetACTIVIDADMALLA()
		{
			return new EACTIVIDADMALLA();
		}

		public EACTIVIDADMALLA GetACTIVIDADMALLA(long id)
		{
            return new EACTIVIDADMALLA(id);
		}

		public bool Save(EACTIVIDADMALLA objACTIVIDADMALLA)
		{
			try
			{
				objACTIVIDADMALLA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EACTIVIDADMALLA> GetACTIVIDADMALLAAll(Int64 Codempresa)
		{
			return _objDALList.SelectAll(Codempresa);
		}

        public bool Delete(EACTIVIDADMALLA objACTIVIDADMALLA)
		{
			try
			{
                _objDAL.Delete(objACTIVIDADMALLA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EACTIVIDADMALLA objACTIVIDADMALLA)
        {
            try
            {
                _objDAL.Update(objACTIVIDADMALLA);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DataTable GetActividadMalla(long CodMalla, Int64 CodEmpresa)
        {
            return _objDALList.SelectActividadMalla(CodMalla, CodEmpresa);
        }

        public DataTable GetMallaUsuario(long Rut, Int64 CodEmpresa)
        {
            return _objDALList.SelectMallaUsuario(Rut, CodEmpresa);
        }

        public DataTable GetAproboActividad(long Rut, int CodCurso, Int64 CodEmpresa)
        {
            return _objDALList.SelectAproboActividad(Rut, CodCurso, CodEmpresa);
        }



    }
}

