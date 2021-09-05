
using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFATRIBUTO.
	/// </summary>
	public class BFATRIBUTO
	{
		private DLATRIBUTO _objDAL;
		private DLATRIBUTOList _objDALList;
		
		public BFATRIBUTO()
		{
			_objDAL = new DLATRIBUTO();
			_objDALList = new DLATRIBUTOList();
		}

		public EATRIBUTO GetATRIBUTO()
		{
			return new EATRIBUTO();
		}

		public EATRIBUTO GetATRIBUTO(long id)
		{
            return new EATRIBUTO(id);
		}

		public bool Save(EATRIBUTO objATRIBUTO)
		{
			try
			{
				objATRIBUTO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EATRIBUTO> GetATRIBUTOAll()
		{
			return _objDALList.SelectAll();
		}

        public List<EATRIBUTO> GetATRIBUTOCARAC(Int16 CodCaracteristica, long codEmpresa)
        {
            return _objDALList.AtributosCaracteristicas(CodCaracteristica, codEmpresa);
        }

        public DataTable GetATRIBUTOPORCARAC(Int16 CodCaracteristica)
        {
            return _objDALList.AtributosPorCaracteristica(CodCaracteristica);
        }

        public bool Delete(EATRIBUTO objATRIBUTO)
		{
			try
			{
                _objDAL.Delete(objATRIBUTO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EATRIBUTO objATRIBUTO)
        {
            try
            {
                _objDAL.Update(objATRIBUTO);
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

