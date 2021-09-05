
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFLINKEXTERNO.
	/// </summary>
	public class BFLINKEXTERNO
	{
		private DLLINKEXTERNO _objDAL;
		private DLLINKEXTERNOList _objDALList;
		
		public BFLINKEXTERNO()
		{
			_objDAL = new DLLINKEXTERNO();
			_objDALList = new DLLINKEXTERNOList();
		}

		public ELINKEXTERNO GetLINKEXTERNO()
		{
			return new ELINKEXTERNO();
		}

		public ELINKEXTERNO GetLINKEXTERNO(long id)
		{
            return new ELINKEXTERNO(id);
		}

		public bool Save(ELINKEXTERNO objLINKEXTERNO)
		{
			try
			{
				objLINKEXTERNO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<ELINKEXTERNO> GetLINKEXTERNOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ELINKEXTERNO objLINKEXTERNO)
		{
			try
			{
                _objDAL.Delete(objLINKEXTERNO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ELINKEXTERNO objLINKEXTERNO)
        {
            try
            {
                _objDAL.Update(objLINKEXTERNO);
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

