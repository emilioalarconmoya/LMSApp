
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFMODULOPAGINA.
	/// </summary>
	public class BFMODULOPAGINA
	{
		private DLMODULOPAGINA _objDAL;
		private DLMODULOPAGINAList _objDALList;
		
		public BFMODULOPAGINA()
		{
			_objDAL = new DLMODULOPAGINA();
			_objDALList = new DLMODULOPAGINAList();
		}

		public EMODULOPAGINA GetMODULOPAGINA()
		{
			return new EMODULOPAGINA();
		}

		public EMODULOPAGINA GetMODULOPAGINA(long id)
		{
            return new EMODULOPAGINA(id);
		}

		public bool Save(EMODULOPAGINA objMODULOPAGINA)
		{
			try
			{
				objMODULOPAGINA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EMODULOPAGINA> GetMODULOPAGINAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EMODULOPAGINA objMODULOPAGINA)
		{
			try
			{
                _objDAL.Delete(objMODULOPAGINA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EMODULOPAGINA objMODULOPAGINA)
        {
            try
            {
                _objDAL.Update(objMODULOPAGINA);
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

