
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using System.Data;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFUNIDAD.
	/// </summary>
	public class BFENCUESTASATISFACCION
	{
		private DLENCUESTASATISFACCION _objDAL;
		private DLENCUESTASATISFACCIONList _objDALList;

        private string _detalleError;

        public System.String DetalleError
        {
            get { return _detalleError; }
            set { _detalleError = value; }
        }

        public BFENCUESTASATISFACCION()
		{
			_objDAL = new DLENCUESTASATISFACCION();
			_objDALList = new DLENCUESTASATISFACCIONList();
		}

		public EENCUESTASATISFACCION GetENCUESTASATISFACCION()
		{
			return new EENCUESTASATISFACCION();
		}

		

        public EENCUESTASATISFACCION GetENCUESTASATISFACCION(long id)
        {
            return new EENCUESTASATISFACCION(id);
        }
     
        public bool Save(EENCUESTASATISFACCION objENCUESTASATISFACCION)
		{
			try
            {
                Int16 intCodEncuesta;
                if (_objDAL.Existe(objENCUESTASATISFACCION.CodEncuestaSatisfaccion))
                {
                    intCodEncuesta = objENCUESTASATISFACCION.CodEncuestaSatisfaccion;
                    objENCUESTASATISFACCION.IsPersisted = true;
                }
                else
                {
                    intCodEncuesta = SerialEncuesta();
                    objENCUESTASATISFACCION.CodEncuestaSatisfaccion = intCodEncuesta;
                    objENCUESTASATISFACCION.IsPersisted = false;
                }

                objENCUESTASATISFACCION.Save();
                objENCUESTASATISFACCION.CodEncuestaSatisfaccion = intCodEncuesta;

                
                return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EENCUESTASATISFACCION> GetEncuetaSatisfaccionAll(Int64 CodEmpresa)
		{
			return _objDALList.SelectAll(CodEmpresa);
		}

        public string GetNombreEncuestaSatisfaccion(int codEncuesta, Int64 CodEmpresa)
        {
            return _objDALList.SelectNombreEncuestaSatisfaccion(codEncuesta, CodEmpresa);
        }

        
        public bool Delete(EENCUESTASATISFACCION objENCUESTASATISFACCION)
		{
			try
            {
                _objDAL.Delete(objENCUESTASATISFACCION);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EENCUESTASATISFACCION objENCUESTASATISFACCION)
        {
            try
            {
                _objDAL.Update(objENCUESTASATISFACCION);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        

        public List<EENCUESTASATISFACCION> GetBuscadorEncuestaSatisfaccion(String Nombre, Int64 CodEmpresa, Int16 codEstado)
        {
            return _objDALList.SelectBuscadorEncuestaSatisfaccion(Nombre, CodEmpresa,  codEstado);
        }

        

        public Int16 SerialEncuesta()
        {
            return _objDAL.Serial();
        }

        public void ActualizaEstadoEncuestaSatisfaccion(long codEncuesta, Boolean flag_activo)
        {
            _objDAL.ActualizaEstadoEncuestaSatisfaccion(codEncuesta, flag_activo);
        }
    }
}

