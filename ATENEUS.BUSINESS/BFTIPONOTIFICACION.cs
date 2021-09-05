using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
    public class BFTIPONOTIFICACION
    {
        private DLTIPONOTIFICACION _objDAL;
        private DLTIPONOTIFICACIONList _objDALList;

        public BFTIPONOTIFICACION()
        {
           // _objDAL = new DLTIPOACTIVIDAD();
            _objDALList = new DLTIPONOTIFICACIONList();
        }

        public ETIPONOTIFICACION GetTIPOACTIVIDAD()
        {
            return new ETIPONOTIFICACION();
        }

        public ETIPONOTIFICACION GetTIPOACTIVIDAD(long id)
        {
            return new ETIPONOTIFICACION(id);
        }

        public bool Save(ETIPONOTIFICACION objTIPONOTIFICACION)
        {
            try
            {
                objTIPONOTIFICACION.Save();
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ETIPONOTIFICACION> GetTIPOACTIVIDADAll()
        {
            return _objDALList.SelectAll();
        }

        public bool Delete(ETIPONOTIFICACION objTIPOACTIVIDAD)
        {
            try
            {
                _objDAL.Delete(objTIPOACTIVIDAD);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ETIPONOTIFICACION objTIPOACTIVIDAD)
        {
            try
            {
                _objDAL.Update(objTIPOACTIVIDAD);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }
    }
}
