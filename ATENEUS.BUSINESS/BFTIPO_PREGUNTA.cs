
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFTIPOPREGUNTA.
	/// </summary>
	public class BFTIPOPREGUNTA
	{
		private DLTIPOPREGUNTA _objDAL;
		private DLTIPOPREGUNTAList _objDALList;
		
		public BFTIPOPREGUNTA()
		{
			_objDAL = new DLTIPOPREGUNTA();
			_objDALList = new DLTIPOPREGUNTAList();
		}

		public ETIPOPREGUNTA GetTIPOPREGUNTA()
		{
			return new ETIPOPREGUNTA();
		}

		public ETIPOPREGUNTA GetTIPOPREGUNTA(long id)
		{
            return new ETIPOPREGUNTA(id);
		}

		public bool Save(ETIPOPREGUNTA objTIPOPREGUNTA)
		{
			try
			{
				objTIPOPREGUNTA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ETIPOPREGUNTA> GetTIPOPREGUNTAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ETIPOPREGUNTA objTIPOPREGUNTA)
		{
			try
			{
                _objDAL.Delete(objTIPOPREGUNTA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ETIPOPREGUNTA objTIPOPREGUNTA)
        {
            try
            {
                _objDAL.Update(objTIPOPREGUNTA);
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

