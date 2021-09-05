
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFPREGUNTAFRECUENTE.
	/// </summary>
	public class BFPREGUNTAFRECUENTE
	{
		private DLPREGUNTAFRECUENTE _objDAL;
		private DLPREGUNTAFRECUENTEList _objDALList;
		
		public BFPREGUNTAFRECUENTE()
		{
			_objDAL = new DLPREGUNTAFRECUENTE();
			_objDALList = new DLPREGUNTAFRECUENTEList();
		}

		public EPREGUNTAFRECUENTE GetPREGUNTAFRECUENTE()
		{
			return new EPREGUNTAFRECUENTE();
		}

		public EPREGUNTAFRECUENTE GetPREGUNTAFRECUENTE(long id)
		{
            return new EPREGUNTAFRECUENTE(id);
		}

		public bool Save(EPREGUNTAFRECUENTE objPREGUNTAFRECUENTE)
		{
			try
			{
				objPREGUNTAFRECUENTE.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EPREGUNTAFRECUENTE> GetPREGUNTAFRECUENTEAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPREGUNTAFRECUENTE objPREGUNTAFRECUENTE)
		{
			try
			{
                _objDAL.Delete(objPREGUNTAFRECUENTE);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EPREGUNTAFRECUENTE objPREGUNTAFRECUENTE)
        {
            try
            {
                _objDAL.Update(objPREGUNTAFRECUENTE);
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

