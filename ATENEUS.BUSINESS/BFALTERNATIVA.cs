
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFALTERNATIVA.
	/// </summary>
	public class BFALTERNATIVA
	{
		private DLALTERNATIVA _objDAL;
		private DLALTERNATIVAList _objDALList;
		
		public BFALTERNATIVA()
		{
			_objDAL = new DLALTERNATIVA();
			_objDALList = new DLALTERNATIVAList();
		}

		public EALTERNATIVA GetALTERNATIVA()
		{
			return new EALTERNATIVA();
		}

		public EALTERNATIVA GetALTERNATIVA(long id)
		{
            return new EALTERNATIVA(id);
		}

		public bool Save(EALTERNATIVA objALTERNATIVA)
		{
			try
			{
				objALTERNATIVA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EALTERNATIVA> GetALTERNATIVAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EALTERNATIVA objALTERNATIVA)
		{
			try
			{
                _objDAL.Delete(objALTERNATIVA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EALTERNATIVA objALTERNATIVA)
        {
            try
            {
                _objDAL.Update(objALTERNATIVA);
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

