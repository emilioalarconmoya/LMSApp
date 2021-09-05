using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;


namespace ATENEUS.BUSINESS
{
    public class BFACTIVIDADTUTOR
    {
        private DLACTIVIDADTUTOR _objDAL;
        private DLACTIVIDADTUTORList _objDALList;

        public BFACTIVIDADTUTOR()
        {
            _objDAL = new DLACTIVIDADTUTOR();
            _objDALList = new DLACTIVIDADTUTORList();
        }

        public EACTIVIDADTUTOR GetACTIVIDADTUTOR()
        {
            return new EACTIVIDADTUTOR();
        }

        public EACTIVIDADTUTOR GetACTIVIDADTUTOR(long id)
        {
            return new EACTIVIDADTUTOR(id);
        }

        public bool Save(EACTIVIDADTUTOR objACTIVIDADTUTOR)
        {
            try
            {
                objACTIVIDADTUTOR.IsPersisted = false;
                objACTIVIDADTUTOR.Save();
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<EACTIVIDADTUTOR> GetACTIVIDADTUTORll()
        {
            return _objDALList.SelectAll();
        }

        public List<EACTIVIDADTUTOR> GetACTIVIDADTUTORllRut(long rut)
        {
            return _objDALList.SelectAll(rut);
        }
        public List<EACTIVIDADTUTOR> GetBuscaActividadTutorNombre(String Nombre, Int64 rutTutor)
        {
            return _objDALList.SelectBuscadorActividadTutorNombre(Nombre, rutTutor);
        }
        public bool Delete(EACTIVIDADTUTOR objACTIVIDADUNIDAD)
        {
            try
            {
                _objDAL.Delete(objACTIVIDADUNIDAD);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EACTIVIDADTUTOR objACTIVIDADUNIDAD)
        {
            try
            {
                _objDAL.Update(objACTIVIDADUNIDAD);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DataTable GetActividadTutoe(long CodActividad)
        {
            return _objDALList.SelectActividadTutor2(CodActividad);
        }

       

        //public Boolean GetTerminoUnidad(long CodActivUsr, long CodUnidad)
        //{
        //    return _objDALList.GetTerminoUnidad(CodActivUsr, CodUnidad);
        //}

        //public void ActializaUnidadActivo(long CodActividad, long CodUnidad, Boolean flag_activo)
        //{
        //    _objDAL.ActualizaFlagActivo(CodActividad, CodUnidad, flag_activo);
        //}

    }
}
