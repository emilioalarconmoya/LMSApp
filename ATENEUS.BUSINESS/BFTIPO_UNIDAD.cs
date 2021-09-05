
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFTIPOUNIDAD.
	/// </summary>
	public class BFTIPOUNIDAD
	{
		private DLTIPOUNIDAD _objDAL;
		private DLTIPOUNIDADList _objDALList;
		
		public BFTIPOUNIDAD()
		{
			_objDAL = new DLTIPOUNIDAD();
			_objDALList = new DLTIPOUNIDADList();
		}

		public ETIPOUNIDAD GetTIPOUNIDAD()
		{
			return new ETIPOUNIDAD();
		}

		public ETIPOUNIDAD GetTIPOUNIDAD(long id)
		{
            return new ETIPOUNIDAD(id);
		}

		public bool Save(ETIPOUNIDAD objTIPOUNIDAD)
		{
			try
			{
				objTIPOUNIDAD.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ETIPOUNIDAD> GetTIPOUNIDADAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ETIPOUNIDAD objTIPOUNIDAD)
		{
			try
			{
                _objDAL.Delete(objTIPOUNIDAD);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ETIPOUNIDAD objTIPOUNIDAD)
        {
            try
            {
                _objDAL.Update(objTIPOUNIDAD);
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

