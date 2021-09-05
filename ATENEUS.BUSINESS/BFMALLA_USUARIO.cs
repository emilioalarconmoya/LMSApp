
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;

namespace ATENEUS.BUSINESS
{
    public class BFMALLAUSUARIO
    {
        private DLMALLAUSUARIO _objDAL;
        private DLMALLAUSUARIOList _objDALList;

        public BFMALLAUSUARIO()
        {
            _objDAL = new DLMALLAUSUARIO();
            _objDALList = new DLMALLAUSUARIOList();
        }

        public EMALLAUSUARIO GetMALLAACTUSUARIO()
        {
            return new EMALLAUSUARIO();
        }

        public EMALLAUSUARIO GetMALLAACTUSUARIO(long id)
        {
            return new EMALLAUSUARIO(id);
        }

        public bool Save(EMALLAUSUARIO objMALLAACTUSUARIO)
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

        public List<EMALLAUSUARIO> GetMALLAACTUSUARIOAll(Int64 CodEmpresa)
        {
            return _objDALList.SelectAll(CodEmpresa);
        }

        public bool Delete(EMALLAUSUARIO objMALLAACTUSUARIO)
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

        public bool Update(EMALLAUSUARIO objMALLAACTUSUARIO)
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

        public List<EMALLAUSUARIO> GetMallasAsignadas(string listaRuts, string listaActividades, Int64 CodEmpresa)
        {
            return _objDALList.GetMallasAsignadas(listaRuts, listaActividades, CodEmpresa);
        }

        public void UpdateMalla(long rutUsuario, Int64 CodEmpresa)
        {
            try
            {
                _objDAL.UpdateMallaUsuario(rutUsuario, CodEmpresa);
               
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
               
            }
        }

        public List<EMALLAUSUARIO> GetUsuarioMalla(Int32 codMalla, Int64 rut, string nombre, string apellidos,Int64 CodEmpresa)
        {
            return _objDALList.SelectUsuariosMalla(codMalla, rut, nombre, apellidos, CodEmpresa);
        }

        public DataTable GetUsuarioMallaDescarga(Int32 codMalla, Int64 rut, string nombre, string apellidos,Int64 CodEmpresa)
        {
            return _objDALList.SelectUsuariosMallaDescarga(codMalla, rut, nombre, apellidos, CodEmpresa);
        }
    }
}
