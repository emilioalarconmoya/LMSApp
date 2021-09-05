
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFTUTOR.
	/// </summary>
	public class BFTUTOR
	{
		private DLTUTOR _objDAL;
		private DLTUTORList _objDALList;
		
		public BFTUTOR()
		{
			_objDAL = new DLTUTOR();
			_objDALList = new DLTUTORList();
		}

		public ETUTOR GetTUTOR()
		{
			return new ETUTOR();
		}

		public ETUTOR GetTUTOR(long id)
		{
            return new ETUTOR(id);
		}

		public bool Save(ETUTOR objTUTOR)
		{
			try
			{
				objTUTOR.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ETUTOR> GetTUTORAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ETUTOR objTUTOR)
		{
			try
			{
                _objDAL.Delete(objTUTOR);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ETUTOR objTUTOR)
        {
            try
            {
                _objDAL.Update(objTUTOR);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public ETUTOR GetTutorActividad(long CodActivUsr)
        {
            return _objDALList.SelectTutorActividad(CodActivUsr);
        }

	}
}

