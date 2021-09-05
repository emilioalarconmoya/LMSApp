
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFETIQUETA.
	/// </summary>
	public class BFETIQUETA
	{
		private DLETIQUETA _objDAL;
		private DLETIQUETAList _objDALList;
		
		public BFETIQUETA()
		{
			_objDAL = new DLETIQUETA();
			_objDALList = new DLETIQUETAList();
		}

		public EETIQUETA GetETIQUETA()
		{
			return new EETIQUETA();
		}

		public EETIQUETA GetETIQUETA(long id)
		{
            return new EETIQUETA(id);
		}

		public bool Save(EETIQUETA objETIQUETA)
		{
			try
			{
				objETIQUETA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EETIQUETA> GetETIQUETAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EETIQUETA objETIQUETA)
		{
			try
			{
                _objDAL.Delete(objETIQUETA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EETIQUETA objETIQUETA)
        {
            try
            {
                _objDAL.Update(objETIQUETA);
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

