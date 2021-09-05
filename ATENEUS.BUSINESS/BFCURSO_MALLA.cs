
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;

namespace ATENEUS.BUSINESS
{
    public class BFCURSOMALLA
    {
        private DLCURSOMALLA _objDAL;
        private DLCURSOMALLAList _objDALList;

        public BFCURSOMALLA()
        {
            _objDAL = new DLCURSOMALLA();
            _objDALList = new DLCURSOMALLAList();
        }

        public ECURSOMALLA GetCURSOMALLA()
        {
            return new ECURSOMALLA();
        }

        public ECURSOMALLA GetCURSOMALLA(long id)
        {
            return new ECURSOMALLA(id);
        }

        public bool Save(ECURSOMALLA objCURSOMALLA)
        {
            try
            {
                objCURSOMALLA.Save();
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ECURSOMALLA> GetACTIVIDADMALLAAll(Int64 CodEmpresa)
        {
            return _objDALList.SelectAll(CodEmpresa);
        }

        public bool Delete(ECURSOMALLA objCURSODMALLA)
        {
            try
            {
                _objDAL.Delete(objCURSODMALLA);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ECURSOMALLA objCURSODMALLA)
        {
            try
            {
                _objDAL.Update(objCURSODMALLA);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }
        //curso malla
        public DataTable GetCursoMalla(long CodMalla, Int64 CodEmpresa)
        {
            return _objDALList.SelectCursoMalla(CodMalla, CodEmpresa);
        }

        public DataTable GetMallaUsuario(long Rut, Int64 CodEmpresa)
        {
            return _objDALList.SelectMallaUsuario(Rut, CodEmpresa);
        }

        public bool GetAproboActividad(long Rut, int CodTipoCurso, Int64 CodEmpresa)
        {
            return _objDALList.SelectAproboActividad(Rut, CodTipoCurso, CodEmpresa);
        }
    }
}
