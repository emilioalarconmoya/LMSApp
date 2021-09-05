
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using System.Data;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFMENSAJE.
	/// </summary>
	public class BFMENSAJE
	{
		private DLMENSAJE _objDAL;
		private DLMENSAJEList _objDALList;
		
		public BFMENSAJE()
		{
			_objDAL = new DLMENSAJE();
			_objDALList = new DLMENSAJEList();
		}

		public EMENSAJE GetMENSAJE()
		{
			return new EMENSAJE();
		}

		public EMENSAJE GetMENSAJE(long id)
		{
            return new EMENSAJE(id);
		}

		public bool Save(EMENSAJE objMENSAJE)
		{
			try
			{
				objMENSAJE.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EMENSAJE> GetMENSAJEAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EMENSAJE objMENSAJE)
		{
			try
			{
                _objDAL.Delete(objMENSAJE);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EMENSAJE objMENSAJE)
        {
            try
            {
                _objDAL.Update(objMENSAJE);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DataTable GetMensajesTutor(long CodActividad, long RutOrigen, long RutDestino)
        {
            return _objDALList.SelectMensajesTutor(CodActividad, RutOrigen, RutDestino);
        }

	}
}

