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
    public class BFNOTIFICACIONCORREO
    {
        private DLNOTIFICACIONCORREO _objDAL;
        private DLNOTIFICACIONCORREOList _objDALList;
        
        public BFNOTIFICACIONCORREO()
        {
            _objDAL = new DLNOTIFICACIONCORREO();
            _objDALList = new DLNOTIFICACIONCORREOList();
        }

        public ENOTIFICACIONCORREO GetNOTIFICACIONCORREO()
        {
            return new ENOTIFICACIONCORREO();
        }

       

        public ENOTIFICACIONCORREO GetNOTIFICACIONCORREO(long id)
        {
            return new ENOTIFICACIONCORREO(id);
        }

        public bool Save(ENOTIFICACIONCORREO objNOTIFICACIONCORREO)
        {
            
            try
            {
                objNOTIFICACIONCORREO.Save();
                objNOTIFICACIONCORREO.IsPersisted = false;
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
           

        }

        public List<ENOTIFICACIONCORREO> GetNOTIFICACIONAll()
        {
            return _objDALList.SelectAll();
        }

       
        public bool Delete(ENOTIFICACIONCORREO objNOTIFICACIONCORREO)
        {
            try
            {
                _objDAL.Delete(objNOTIFICACIONCORREO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ENOTIFICACIONCORREO objNOTIFICACIONCORREO)
        {
            try
            {
                _objDAL.Update(objNOTIFICACIONCORREO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

       
        public DataTable GetBuscadorNotificacion(String asunto, Int16 CodTipo, Int64 codEmpresa)
        {
            return _objDALList.SelectBuscadornotificacioncorreo(asunto, CodTipo, codEmpresa);
        }

        public List<ENOTIFICACIONCORREO> GetNotificacionPorTipo(Int16 codTipoNotificacion, Int64 codEmpresa)
        {
            return _objDALList.NotificacionPorTipo(codTipoNotificacion, codEmpresa);
        }
    }
}
