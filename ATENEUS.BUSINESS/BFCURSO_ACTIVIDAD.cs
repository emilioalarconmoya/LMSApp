using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;

namespace ATENEUS.BUSINESS
{
    public class BFCURSOACTIVIDAD
    {
        private DLCURSOACTIVIDAD _objDAL;
        private DLCURSOACTIVIDADList _objDALList;

        public BFCURSOACTIVIDAD()
        {
            _objDAL = new DLCURSOACTIVIDAD();
            _objDALList = new DLCURSOACTIVIDADList();
        }

        public ECURSOACTIVIDAD GetCURSOACTIVIDAD()
        {
            return new ECURSOACTIVIDAD();
        }

        public ECURSOACTIVIDAD GetCURSOACTIVIDAD(long id)
        {
            return new ECURSOACTIVIDAD(id);
        }

        public ECURSOACTIVIDAD GetSelectActividad(int codCurso, int codActividad, Int64 CodEmpresa)
        {
            return _objDAL.SelectActividad(codCurso, codActividad, CodEmpresa);
        }

        public bool Save(ECURSOACTIVIDAD objCURSOACTIVIDAD)
        {
            try
            {
                objCURSOACTIVIDAD.Save();
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ECURSOACTIVIDAD> GetCURSOACTIVIDADAll()
        {
            return _objDALList.SelectAll();
        }

        public bool Delete(ECURSOACTIVIDAD objCURSOACTIVIDAD)
        {
            try
            {
                _objDAL.Delete(objCURSOACTIVIDAD);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ECURSOACTIVIDAD objCURSOACTIVIDAD)
        {
            try
            {
                _objDAL.Update(objCURSOACTIVIDAD);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DataTable GetActividadesCurso(long CodCurso, Int64 CodEmpresa)
        {
            return _objDALList.SelectActividadesCurso(CodCurso, CodEmpresa);
        }

        public List<ECURSO> GetBuscaCursoMalla(String Nombre, Int64 CodEmpresa)
        {
            return _objDALList.SelectBuscadorCurso(Nombre, CodEmpresa);
        }

        public Boolean GetSolicitoCurso(long codCurso, long codActividad, Int64 CodEmpresa)
        {
            return _objDALList.GetSolicitoCurso(codCurso, codActividad, CodEmpresa);
        }
        public Boolean GetTieneautoinscripcion(long codCurso, long codActividad, Int64 CodEmpresa)
        {
            return _objDALList.GetTieneautoinscripcion(codCurso, codActividad, CodEmpresa);
        }

        public Boolean Actualizasolicitud(long codCurso, long codActividad, Int64 CodEmpresa)
        {
            return _objDALList.ActualizaSolicitud(codCurso, codActividad, CodEmpresa);
        }

        public DataTable GetAproboCurso(long codActividad, long rutUsuario, Int64 CodEmpresa)
        {
            return _objDALList.GetAproboCurso(codActividad, rutUsuario, CodEmpresa);
        }
    }
}
