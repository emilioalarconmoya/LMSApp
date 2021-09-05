
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFCOMENTARIO.
	/// </summary>
	public class BFCOMENTARIO
	{
		private DLCOMENTARIO _objDAL;
		private DLCOMENTARIOList _objDALList;
		
		public BFCOMENTARIO()
		{
			_objDAL = new DLCOMENTARIO();
			_objDALList = new DLCOMENTARIOList();
		}

		public ECOMENTARIO GetCOMENTARIO()
		{
			return new ECOMENTARIO();
		}

		public ECOMENTARIO GetCOMENTARIO(long id)
		{
            return new ECOMENTARIO(id);
		}

		public bool Save(ECOMENTARIO objCOMENTARIO)
		{
			try
			{
				objCOMENTARIO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ECOMENTARIO> GetCOMENTARIOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ECOMENTARIO objCOMENTARIO)
		{
			try
			{
                _objDAL.Delete(objCOMENTARIO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ECOMENTARIO objCOMENTARIO)
        {
            try
            {
                _objDAL.Update(objCOMENTARIO);
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

