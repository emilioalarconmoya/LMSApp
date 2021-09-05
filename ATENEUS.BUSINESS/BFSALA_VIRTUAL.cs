using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;

namespace ATENEUS.BUSINESS
{
    public class BFSALAVIRTUAL
    {
        private DLSALAVIRTUAL _objDAL;
        private DLSALAVIRTUALList _objDALList;

        public BFSALAVIRTUAL()
        {
            _objDAL = new DLSALAVIRTUAL();
            _objDALList = new DLSALAVIRTUALList();
        }

        public ESALAVIRTUAL GetSALAVIRTUAL()
        {
            return new ESALAVIRTUAL();
        }

        public ESALAVIRTUAL GetSALAVIRTUAL(long id)
        {
            return new ESALAVIRTUAL(id);
        }

        public bool Save(ESALAVIRTUAL objSALAVIRTUAL)
        {
            try
            {
                objSALAVIRTUAL.Save();
                objSALAVIRTUAL.IsPersisted = false;
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ESALAVIRTUAL> GetMALLAACTUSUARIOAll(long CodEmpresa)
        {
            return _objDALList.SelectAll(CodEmpresa);
        }

        public DataTable GetSalaVirtual(long RutUsuario, Int64 CodEmpresa)
        {
            return _objDALList.SelectSalaVirtual(RutUsuario, CodEmpresa);
        }

        public DataTable GetSalaVirtualVigente(long RutUsuario, Int64 CodEmpresa)
        {
            return _objDALList.SelectSalaVirtualVigente(RutUsuario, CodEmpresa);
        }

        public bool Delete(ESALAVIRTUAL objSALAVIRTUAL)
        {
            try
            {
                _objDAL.Delete(objSALAVIRTUAL);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ESALAVIRTUAL objSALAVIRTUAL)
        {
            try
            {
                _objDAL.Update(objSALAVIRTUAL);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        //public List<EMALLAUSUARIO> GetMallasAsignadas(string listaRuts, string listaActividades)
        //{
        //    return _objDALList.GetMallasAsignadas(listaRuts, listaActividades);
        //}

        //public void UpdateMalla(long rutUsuario)
        //{
        //    try
        //    {
        //        _objDAL.UpdateMallaUsuario(rutUsuario);

        //    }
        //    catch (Exception ex)
        //    {
        //        Log log = new Log();
        //        log.EscribirLog(ex);

        //    }
        //}
    }
}
