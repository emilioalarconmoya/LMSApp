using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;

namespace ATENEUS.BUSINESS
{
    public class BFCOMENTARIOTUTOR
    {
        private DLCOMENTARIOTUTOR _objDAL;
        private DLCOMENTARIOTUTORList _objDALList;

        public BFCOMENTARIOTUTOR()
        {
            _objDAL = new DLCOMENTARIOTUTOR();
            _objDALList = new DLCOMENTARIOTUTORList();
        }

        public ECOMENTARIOTUTOR GetCOMENTARIOTUTOR()
        {
            return new ECOMENTARIOTUTOR();
        }

        public ECOMENTARIOTUTOR GetCOMENTARIOTUTOR(long id)
        {
            return new ECOMENTARIOTUTOR(id);
        }

        public bool Save(ECOMENTARIOTUTOR objCOMENTARIOTUTOR)
        {
            try
            {
                objCOMENTARIOTUTOR.Save();
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ECOMENTARIOTUTOR> GetMATERIALAPOYOAll()
        {
            return _objDALList.SelectAll();
        }

        public bool Delete(ECOMENTARIOTUTOR objCOMENTARIOTUTOR)
        {
            try
            {
                _objDAL.Delete(objCOMENTARIOTUTOR);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ECOMENTARIOTUTOR objCOMENTARIOTUTOR)
        {
            try
            {
                _objDAL.Update(objCOMENTARIOTUTOR);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }


        public DataTable GetComentarioTutor(Int64 CodActividadTutor, Int64 CodEmpresa)
        {
            return _objDALList.SelectComentarioSala(CodActividadTutor, CodEmpresa);
        }

        public DataTable GetDatosTutor(Int64 CodActividadTutor)
        {
            return _objDALList.SelectDatosTutor(CodActividadTutor);
        }
    }
}
