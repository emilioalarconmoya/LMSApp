using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;

namespace ATENEUS.BUSINESS
{
    public class BFSOLICITUDCURSOCATALOGO
    {
        private DLSOLICITUDCURSOCATALOGO _objDAL;
        private DLSOLICITUDCURSOCATALOGOList _objDALList;

        public BFSOLICITUDCURSOCATALOGO()
        {
            _objDAL = new DLSOLICITUDCURSOCATALOGO();
            _objDALList = new DLSOLICITUDCURSOCATALOGOList();
        }

        public ESOLICITUDCURSOCATALOGO GetSOLICITUDCURSO()
        {
            return new ESOLICITUDCURSOCATALOGO();
        }

        public ESOLICITUDCURSOCATALOGO GetSOLICITUDCURSO(long id)
        {
            return new ESOLICITUDCURSOCATALOGO(id);
        }

        //public ESOLICITUDCURSOCATALOGO GetSelectSolicitud(int codCurso, int codActividad, int rutUsuario)
        //{
        //    //return _objDAL.SelectSolicitud(codCurso, codActividad, rutUsuario);
        //}

        public bool Save(ESOLICITUDCURSOCATALOGO objSOLICITUDCURSO)
        {
            try
            {
                objSOLICITUDCURSO.Save();
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ESOLICITUDCURSOCATALOGO> GetSOLICITUDCURSOAll()
        {
            return _objDALList.SelectAll();
        }

        public bool Delete(ESOLICITUDCURSOCATALOGO objSOLICITUDCURSO)
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

        public bool Update(ESOLICITUDCURSOCATALOGO objSOLICITUDCURSO)
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
        

        public Boolean GetSolicitoCurso(long codCurso, long codActividad, long rutUsuario)
        {
            return _objDALList.GetSolicitoCurso(codCurso, codActividad, rutUsuario);
        }

        public DataTable BucadorSolecitudesCursos(long rutUsuario, string nombreUsuario, int estado, int codGrupo, int codActividad, long codEmpresa)
        {
            return _objDALList.ListaSolicitudesCursos(rutUsuario, nombreUsuario, estado, codGrupo, codActividad, codEmpresa);
        }
    }
}
