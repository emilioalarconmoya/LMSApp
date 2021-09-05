using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;
namespace ATENEUS.BUSINESS
{
    public class BFCATALOGOACTIVIDAD
    {
        private DLCATALOGOACTIVIDAD _objDAL;
        private DLCATALOGOACTIVIDADList _objDALList;

        public BFCATALOGOACTIVIDAD()
        {
            _objDAL = new DLCATALOGOACTIVIDAD();
            _objDALList = new DLCATALOGOACTIVIDADList();
        }

        public ECATALOGOACTIVIDAD GetCATALOGOACTIVIDAD()
        {
            return new ECATALOGOACTIVIDAD();
        }

        public ECATALOGOACTIVIDAD GetCATALOGOACTIVIDAD(long id)
        {
            return new ECATALOGOACTIVIDAD(id);
        }

        public bool Save(ECATALOGOACTIVIDAD objCATALOGOACTOIVIDAD)
        {
            try
            {
                objCATALOGOACTOIVIDAD.Save();
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ECATALOGOACTIVIDAD> GetCATALOGOACTIVIDADAll()
        {
            return _objDALList.SelectAll();
        }

        public bool Delete(ECATALOGOACTIVIDAD objCATALOGOACTIVIDAD)
        {
            try
            {
                _objDAL.Delete(objCATALOGOACTIVIDAD);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ECATALOGOACTIVIDAD objCATALOGOACTIVIDAD)
        {
            try
            {
                _objDAL.Update(objCATALOGOACTIVIDAD);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ECATALOGOACTIVIDAD> SelectBuscadorCATALOGO(string Nombre, int codActividad, short estado, int codCATALOGO)
        {
            return _objDALList.SelectBuscadorCATALOGO(Nombre, codActividad, estado, codCATALOGO);
        }

        public Int32 StockDisponible(int codActividad, int codCATALOGO, long codEmpresa)
        {
            return _objDAL.StockDisponible(codActividad, codCATALOGO, codEmpresa);
        }

        public Int32 CodCATALOGOUsuario(long rutUsuario)
        {
            return _objDAL.CodCATALOGOUsuario(rutUsuario);
        }

        public DataTable SelectActividadesCatalogo(int codCatalogo)
        {
           return _objDAL.SelectActividadesCatalogo(codCatalogo);
        }
    }
}
