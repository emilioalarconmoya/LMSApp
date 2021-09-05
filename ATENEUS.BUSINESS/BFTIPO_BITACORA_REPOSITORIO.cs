
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFTIPOBITACORAREPOSITORIO.
	/// </summary>
	public class BFTIPOBITACORAREPOSITORIO
	{
		private DLTIPOBITACORAREPOSITORIO _objDAL;
		private DLTIPOBITACORAREPOSITORIOList _objDALList;
		
		public BFTIPOBITACORAREPOSITORIO()
		{
			_objDAL = new DLTIPOBITACORAREPOSITORIO();
			_objDALList = new DLTIPOBITACORAREPOSITORIOList();
		}

		public ETIPOBITACORAREPOSITORIO GetTIPOBITACORAREPOSITORIO()
		{
			return new ETIPOBITACORAREPOSITORIO();
		}

		public ETIPOBITACORAREPOSITORIO GetTIPOBITACORAREPOSITORIO(long id)
		{
            return new ETIPOBITACORAREPOSITORIO(id);
		}

		public bool Save(ETIPOBITACORAREPOSITORIO objTIPOBITACORAREPOSITORIO)
		{
			try
			{
				objTIPOBITACORAREPOSITORIO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ETIPOBITACORAREPOSITORIO> GetTIPOBITACORAREPOSITORIOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ETIPOBITACORAREPOSITORIO objTIPOBITACORAREPOSITORIO)
		{
			try
			{
                _objDAL.Delete(objTIPOBITACORAREPOSITORIO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ETIPOBITACORAREPOSITORIO objTIPOBITACORAREPOSITORIO)
        {
            try
            {
                _objDAL.Update(objTIPOBITACORAREPOSITORIO);
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

