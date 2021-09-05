
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFTIPOMOVIMIENTO.
	/// </summary>
	public class BFTIPOMOVIMIENTO
	{
		private DLTIPOMOVIMIENTO _objDAL;
		private DLTIPOMOVIMIENTOList _objDALList;
		
		public BFTIPOMOVIMIENTO()
		{
			_objDAL = new DLTIPOMOVIMIENTO();
			_objDALList = new DLTIPOMOVIMIENTOList();
		}

		public ETIPOMOVIMIENTO GetTIPOMOVIMIENTO()
		{
			return new ETIPOMOVIMIENTO();
		}

		public ETIPOMOVIMIENTO GetTIPOMOVIMIENTO(long id)
		{
            return new ETIPOMOVIMIENTO(id);
		}

		public bool Save(ETIPOMOVIMIENTO objTIPOMOVIMIENTO)
		{
			try
			{
				objTIPOMOVIMIENTO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ETIPOMOVIMIENTO> GetTIPOMOVIMIENTOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ETIPOMOVIMIENTO objTIPOMOVIMIENTO)
		{
			try
			{
                _objDAL.Delete(objTIPOMOVIMIENTO);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ETIPOMOVIMIENTO objTIPOMOVIMIENTO)
        {
            try
            {
                _objDAL.Update(objTIPOMOVIMIENTO);
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

