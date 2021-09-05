using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using System.Data;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace ATENEUS.BUSINESS
{
    public class BFTIPOSALAVIRTUAL
    {
        private DLTIPOSALAVIRTUAL _objDAL;
        private DLTIPOSALAVIRTUALList _objDALList;

        public BFTIPOSALAVIRTUAL()
        {
            _objDAL = new DLTIPOSALAVIRTUAL();
            _objDALList = new DLTIPOSALAVIRTUALList();
        }

        public ETIPOSALAVIRTUAL GetTIPOCURSO()
        {
            return new ETIPOSALAVIRTUAL();
        }
        public ETIPOSALAVIRTUAL GetTIPOCURSO(long id)
        {
            return new ETIPOSALAVIRTUAL(id);
        }

        public Int32 Save(ETIPOSALAVIRTUAL objTIPOCURSO)
        {
            try
            {
                objTIPOCURSO.Save();
                return objTIPOCURSO.CodTipo;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return 0;
            }
        }

        public List<ETIPOSALAVIRTUAL> GetTIPOCURSOAll()
        {
            return _objDALList.SelectAll();
        }

        public bool Delete(ETIPOSALAVIRTUAL objTIPOCURSO)
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

        public bool Update(ETIPOSALAVIRTUAL objTIPOCURSO)
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

        public List<ETIPOSALAVIRTUAL> GetSala()
        {
            return _objDALList.SelectAll();
        }
    }
}
