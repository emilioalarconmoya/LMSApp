
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using System.Data;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFLOGCONEXION.
	/// </summary>
	public class BFLOGCONEXION
	{
		private DLLOGCONEXION _objDAL;
		private DLLOGCONEXIONList _objDALList;
		
		public BFLOGCONEXION()
		{
			_objDAL = new DLLOGCONEXION();
			_objDALList = new DLLOGCONEXIONList();
		}

		public ELOGCONEXION GetLOGCONEXION()
		{
			return new ELOGCONEXION();
		}

		public ELOGCONEXION GetLOGCONEXION(long id)
		{
            return new ELOGCONEXION(id);
		}

		public bool Save(ELOGCONEXION objLOGCONEXION)
		{
			try
			{
				objLOGCONEXION.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ELOGCONEXION> GetLOGCONEXIONAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ELOGCONEXION objLOGCONEXION)
		{
			try
			{
                _objDAL.Delete(objLOGCONEXION);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ELOGCONEXION objLOGCONEXION)
        {
            try
            {
                _objDAL.Update(objLOGCONEXION);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DataTable GetDatosUltimoLog(long CodActivUsr, Int32 CodUnidad, Int64 CodEmpresa)
        {
            return _objDALList.SelectDatosUltimoLog(CodActivUsr, CodUnidad,CodEmpresa);
        }

        public Boolean LogCerrado(long CodActivUsr, Int32 CodUnidad, Int64 CodEmpresa)
        {
            return _objDALList.LogCerrado(CodActivUsr, CodUnidad,CodEmpresa);
        }

        public DateTime FechaUltimaVisita(long CodActivUsr, Int32 CodUnidad,Int64 CodEmpresa)
        {
            return _objDALList.FechaUltimaVisita(CodActivUsr, CodUnidad,CodEmpresa);
        }

        public Int16 UltimoPasoVisitado(long CodActivUsr, Int32 CodUnidad, Int64 CodEmpresa)
        {
            return _objDALList.UltimoPasoVisitado(CodActivUsr, CodUnidad,CodEmpresa);
        }

        public void SetTerminoUnidad(long CodActivUsr, Int32 CodUnidad,Int64 CodEmpresa)
        {
            DateTime inicio = FechaUltimaVisita(CodActivUsr, CodUnidad, CodEmpresa);
            if(CodActivUsr!=0)
            {
                _objDALList.AvisaTermino(CodActivUsr, CodUnidad, inicio);
            }
            
        }

        public void SetTerminoUnidadSincronico(long CodActivUsr, Int32 CodUnidad, Int64 CodEmpresa)
        {
            DateTime inicio = FechaUltimaVisita(CodActivUsr, CodUnidad, CodEmpresa);
            if (CodActivUsr != 0)
            {
                _objDALList.AvisaTerminoSincronico(CodActivUsr, CodUnidad, inicio);
            }

        }

        public void SetPasoUltimaVisita(long CodActivUsr, Int32 CodUnidad, Int16 Paso, Int64 CodEmpresa)
        {
            DateTime inicio = FechaUltimaVisita(CodActivUsr, CodUnidad, CodEmpresa);
            _objDALList.SetPasoUltimaVisita(CodActivUsr, CodUnidad, inicio, Paso);
        }

        public void SetNotaUltimaVisita(long CodActivUsr, Int32 CodUnidad, double Nota, Int64 CodEmpresa)
        {
            DateTime inicio = FechaUltimaVisita(CodActivUsr, CodUnidad, CodEmpresa);
            _objDALList.SetNotaUltimaVisita(CodActivUsr, CodUnidad, inicio, Nota);
        }
        //deja terminada la unidad si el administrador lo hacer para que pasa a la siguiente unidad
        public void TerminaUnidad(long CodActivUsr, Int32 CodUnidad, Int64 CodEmpresa)
        {
            _objDAL.TreminaUnidad(CodActivUsr, CodUnidad, CodEmpresa);
        }
    }
}

