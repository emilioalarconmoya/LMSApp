using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
    public class BFCURSO
    {
        private DLCURSO _objDAL;
        private DLCURSOList _objDALList;

        public BFCURSO()
        {
            _objDAL = new DLCURSO();
            _objDALList = new DLCURSOList();
        }

        public ECURSO GetCURSO()
        {
            return new ECURSO();
        }

        public ECURSO GetCURSO(long id)
        {
            return new ECURSO(id);
        }

        public Int32 Save(ECURSO objCURSO)
        {
            try
            {
                //Int32 CodMalla = objMALLA.CodMalla;
                //if (objMALLA.IsPersisted == false)
                //{
                //    //CodMalla = Utiles.ConvertToInt16(_objDAL.Serial());
                //    objMALLA.CodMalla = CodMalla;
                //}
                //else
                //{
                //    CodMalla = objMALLA.CodMalla;
                //}
                objCURSO.Save();
                return objCURSO.CodCurso;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return 0;
            }
        }

        public List<ECURSO> GetCURSOAll(Int64 CodEmpresa)
        {
            return _objDALList.SelectAll(CodEmpresa);
        }

        public bool Delete(ECURSO objCURSO)
        {
            try
            {
                _objDAL.Delete(objCURSO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ECURSO objCURSO)
        {
            try
            {
                _objDAL.Update(objCURSO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ECURSO> GetCursosParametros(string Nombre, int codTipo, Int64 CodEmpresa)
        {
            return _objDALList.SelectCursosParametros(Nombre, codTipo, CodEmpresa);
        }
    }
}
