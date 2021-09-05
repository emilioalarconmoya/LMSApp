using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;

namespace ATENEUS.BUSINESS
{
    public class BFSOLICITUDCURSO
    {
        private DLSOLICITUDCURSO _objDAL;
        private DLSOLICITUDCURSOList _objDALList;

        public BFSOLICITUDCURSO()
        {
            _objDAL = new DLSOLICITUDCURSO();
            _objDALList = new DLSOLICITUDCURSOList();
        }

        public ESOLICITUDCURSO GetSOLICITUDCURSO()
        {
            return new ESOLICITUDCURSO();
        }

        public ESOLICITUDCURSO GetSOLICITUDCURSO(long id)
        {
            return new ESOLICITUDCURSO(id);
        }

        public ESOLICITUDCURSO GetSelectSolicitud(int codCurso, int codActividad, int rutUsuario, Int64 CodEmpresa)
        {
            return _objDAL.SelectSolicitud(codCurso, codActividad, rutUsuario, CodEmpresa);
        }

        public bool Save(ESOLICITUDCURSO objCURSOACTIVIDAD)
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

        public List<ESOLICITUDCURSO> GetSOLICITUDCURSOAll()
        {
            return _objDALList.SelectAll();
        }

        public bool Delete(ESOLICITUDCURSO objSOLICITUDCURSO)
        {
            try
            {
                _objDAL.Delete(objSOLICITUDCURSO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ESOLICITUDCURSO objSOLICITUDCURSO)
        {
            try
            {
                _objDAL.Update(objSOLICITUDCURSO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }
        

        public Boolean GetSolicitoCurso(long codCurso, long codActividad, long rutUsuario, Int64 CodEmpresa)
        {
            return _objDALList.GetSolicitoCurso(codCurso, codActividad, rutUsuario, CodEmpresa);
        }

        public DataTable BucadorSolecitudesCursos(long rutUsuario, string nombreUsuario, int estado, Int64 CodEmpresa)
        {
            return _objDALList.ListaSolicitudesCursos(rutUsuario, nombreUsuario, estado, CodEmpresa);
        }
    }
}
