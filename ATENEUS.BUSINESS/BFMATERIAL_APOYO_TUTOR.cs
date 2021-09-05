using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
    public class BFMATERIALAPOYOTUTOR
    {
        private DLMATERIALAPOYOTUTOR _objDAL;
        private DLMATERIALAPOYOTUTORList _objDALList;

        public BFMATERIALAPOYOTUTOR()
        {
            _objDAL = new DLMATERIALAPOYOTUTOR();
            _objDALList = new DLMATERIALAPOYOTUTORList();
        }

        public EMATERIALAPOYOTUTOR GetMATERIALAPOYOTUTOR()
        {
            return new EMATERIALAPOYOTUTOR();
        }

        public EMATERIALAPOYOTUTOR GetMATERIALAPOYO(long id)
        {
            return new EMATERIALAPOYOTUTOR(id);
        }

        public bool Save(EMATERIALAPOYOTUTOR objMATERIALAPOYO)
        {
            try
            {
                objMATERIALAPOYO.Save();
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<EMATERIALAPOYOTUTOR> GetMATERIALAPOYOAll()
        {
            return _objDALList.SelectAll();
        }

        public bool Delete(EMATERIALAPOYOTUTOR objMATERIALAPOYO)
        {
            try
            {
                _objDAL.Delete(objMATERIALAPOYO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EMATERIALAPOYOTUTOR objMATERIALAPOYO)
        {
            try
            {
                _objDAL.Update(objMATERIALAPOYO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }


        public List<EMATERIALAPOYOTUTOR> GetMaterialApoyoActividad(Int16 CodActividad, Int64 CodEmpresa)
        {
            return _objDALList.SelectMaterialApoyoActividad(CodActividad, CodEmpresa);
        }

    }
}
