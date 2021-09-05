
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;
namespace ATENEUS.BUSINESS
{
    public class BFBITACORACORREO
    {
        private DLBITACORACORREO _objDAL;
        //private DLBITACORAACTIVIDADUSUARIOList _objDALList;

        public BFBITACORACORREO()
        {
            _objDAL = new DLBITACORACORREO();
           // _objDALList = new DLBITACORAACTIVIDADUSUARIOList();
        }

        public EBITACORACORREO GetBITACORACORREO()
        {
            return new EBITACORACORREO();
        }
        

        public EBITACORACORREO GetBITACORACORREO(long id)
        {
            return new EBITACORACORREO(id);
        }

        public bool Save(EBITACORACORREO objBITACORACORREO)
        {
            try
            {
                objBITACORACORREO.Save();
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        //public List<EBITACORACORREO> GetBITACORAACTIVIDADUSUARIOAll()
        //{
        //    return _objDALList.SelectAll();
        //}

        public bool Delete(EBITACORACORREO objBITACORAACTIVIDADUSUARIO)
        {
            try
            {
                _objDAL.Delete(objBITACORAACTIVIDADUSUARIO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EBITACORACORREO objBITACORAACTIVIDADUSUARIO)
        {
            try
            {
                _objDAL.Update(objBITACORAACTIVIDADUSUARIO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DataTable ReporteBitacoracorreo(string nombre, string email, string asunto, string rut, DateTime fechaDesde, DateTime fechaHasta, string curso, int codCaracteristica, int codAtributo, Int64 codEmpresa, int CodtipoNotificacion)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = _objDAL.ReporteBitacora(nombre, email, asunto,rut, fechaDesde.Year.ToString() + fechaDesde.Month.ToString().PadLeft(2, '0') + fechaDesde.Day.ToString().PadLeft(2, '0'), fechaHasta.Year.ToString() + fechaHasta.Month.ToString().PadLeft(2, '0') + fechaHasta.Day.ToString().PadLeft(2, '0'),curso, codCaracteristica, codAtributo, codEmpresa, CodtipoNotificacion);
                return dt;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return dt;
            }
        }

        public int CountCorreos(DateTime fecha, Int64 codEmpresa)
        {
            int cantidad;
            try
            {
                cantidad = _objDAL.CountCorreos(fecha.Year.ToString() + fecha.Month.ToString().PadLeft(2, '0') + fecha.Day.ToString().PadLeft(2, '0'),  codEmpresa);
                return cantidad;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return 0;
            }
        }

        public DataTable ReporteBitacoracorreoTotales(Int32 agno, Int64 codEmpresa)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = _objDAL.ReporteBitacoraTotales(agno, codEmpresa);
                return dt;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return dt;
            }
        }
    }
}
