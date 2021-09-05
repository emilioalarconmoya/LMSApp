
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFESCALANOTAS.
	/// </summary>
	public class BFESCALANOTAS
	{
		private DLESCALANOTAS _objDAL;
		private DLESCALANOTASList _objDALList;
		
		public BFESCALANOTAS()
		{
			_objDAL = new DLESCALANOTAS();
			_objDALList = new DLESCALANOTASList();
		}

		public EESCALANOTAS GetESCALANOTAS()
		{
			return new EESCALANOTAS();
		}

		public EESCALANOTAS GetESCALANOTAS(long id)
		{
            return new EESCALANOTAS(id);
		}

		public bool Save(EESCALANOTAS objESCALANOTAS)
		{
			try
			{
				objESCALANOTAS.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EESCALANOTAS> GetESCALANOTASAll(Int64 CodEmpresa)
		{
			return _objDALList.SelectAll(CodEmpresa);
		}

        public bool Delete(EESCALANOTAS objESCALANOTAS)
		{
			try
			{
                _objDAL.Delete(objESCALANOTAS);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EESCALANOTAS objESCALANOTAS)
        {
            try
            {
                _objDAL.Update(objESCALANOTAS);
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

