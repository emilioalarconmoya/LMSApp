
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFBITACORAREPOSITORIO.
	/// </summary>
	public class BFBITACORAREPOSITORIO
	{
		private DLBITACORAREPOSITORIO _objDAL;
		private DLBITACORAREPOSITORIOList _objDALList;
		
		public BFBITACORAREPOSITORIO()
		{
			_objDAL = new DLBITACORAREPOSITORIO();
			_objDALList = new DLBITACORAREPOSITORIOList();
		}

		public EBITACORAREPOSITORIO GetBITACORAREPOSITORIO()
		{
			return new EBITACORAREPOSITORIO();
		}

		public EBITACORAREPOSITORIO GetBITACORAREPOSITORIO(long id)
		{
            return new EBITACORAREPOSITORIO(id);
		}

		public bool Save(EBITACORAREPOSITORIO objBITACORAREPOSITORIO)
		{
			try
			{
				objBITACORAREPOSITORIO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EBITACORAREPOSITORIO> GetBITACORAREPOSITORIOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EBITACORAREPOSITORIO objBITACORAREPOSITORIO)
		{
			try
			{
                _objDAL.Delete(objBITACORAREPOSITORIO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EBITACORAREPOSITORIO objBITACORAREPOSITORIO)
        {
            try
            {
                _objDAL.Update(objBITACORAREPOSITORIO);
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

