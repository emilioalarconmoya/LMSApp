using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
    public class BFTIPOCURSO
    {
        private DLTIPOCURSO _objDAL;
        private DLTIPOCURSOList _objDALList;

        public BFTIPOCURSO()
        {
            _objDAL = new DLTIPOCURSO();
            _objDALList = new DLTIPOCURSOList();
        }

        public ETIPOCURSO GetTIPOCURSO()
        {
            return new ETIPOCURSO();
        }
        public ETIPOCURSO GetTIPOCURSO(long id)
        {
            return new ETIPOCURSO(id);
        }

        public Int32 Save(ETIPOCURSO objTIPOCURSO)
        {
            try
            {
                objTIPOCURSO.Save();
                return objTIPOCURSO.CodTipoCurso;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return 0;
            }
        }

        public List<ETIPOCURSO> GetTIPOCURSOAll(Int64 CodEmpresa)
        {
            return _objDALList.SelectAll(CodEmpresa);
        }

        public bool Delete(ETIPOCURSO objTIPOCURSO)
        {
            try
            {
                _objDAL.Delete(objTIPOCURSO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ETIPOCURSO objTIPOCURSO)
        {
            try
            {
                _objDAL.Update(objTIPOCURSO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ETIPOCURSO> GetTipoCursoParametros(string Nombre, Int64 CodEmpresa)
        {
            return _objDALList.SelectTipoCursoParametros(Nombre, CodEmpresa);
        }
    }
}
