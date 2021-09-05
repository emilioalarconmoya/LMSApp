
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFMATERIALAPOYO.
	/// </summary>
	public class BFMATERIALAPOYO
	{
		private DLMATERIALAPOYO _objDAL;
		private DLMATERIALAPOYOList _objDALList;
		
		public BFMATERIALAPOYO()
		{
			_objDAL = new DLMATERIALAPOYO();
			_objDALList = new DLMATERIALAPOYOList();
		}

		public EMATERIALAPOYO GetMATERIALAPOYO()
		{
			return new EMATERIALAPOYO();
		}

		public EMATERIALAPOYO GetMATERIALAPOYO(long id)
		{
            return new EMATERIALAPOYO(id);
		}

		public bool Save(EMATERIALAPOYO objMATERIALAPOYO)
		{
			try
			{
				objMATERIALAPOYO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EMATERIALAPOYO> GetMATERIALAPOYOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EMATERIALAPOYO objMATERIALAPOYO)
		{
			try
			{
                _objDAL.Delete(objMATERIALAPOYO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EMATERIALAPOYO objMATERIALAPOYO)
        {
            try
            {
                _objDAL.Update(objMATERIALAPOYO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }


        public List<EMATERIALAPOYO> GetMaterialApoyoActividad(Int16 CodActividad)
        {
            return _objDALList.SelectMaterialApoyoActividad(CodActividad);
        }
	}
}

