
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFMODELODISPOSITIVO.
	/// </summary>
	public class BFMODELODISPOSITIVO
	{
		private DLMODELODISPOSITIVO _objDAL;
		private DLMODELODISPOSITIVOList _objDALList;
		
		public BFMODELODISPOSITIVO()
		{
			_objDAL = new DLMODELODISPOSITIVO();
			_objDALList = new DLMODELODISPOSITIVOList();
		}

		public EMODELODISPOSITIVO GetMODELODISPOSITIVO()
		{
			return new EMODELODISPOSITIVO();
		}

		public EMODELODISPOSITIVO GetMODELODISPOSITIVO(long id)
		{
            return new EMODELODISPOSITIVO(id);
		}

		public bool Save(EMODELODISPOSITIVO objMODELODISPOSITIVO)
		{
			try
			{
				objMODELODISPOSITIVO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EMODELODISPOSITIVO> GetMODELODISPOSITIVOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EMODELODISPOSITIVO objMODELODISPOSITIVO)
		{
			try
			{
                _objDAL.Delete(objMODELODISPOSITIVO);
			    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(); //throw new MoebiusException(Translate.ORM.GetString("msg_error_al_grabar"), this.GetType().ToString(), ex);
            }
		}

        public bool Update(EMODELODISPOSITIVO objMODELODISPOSITIVO)
        {
            try
            {
                _objDAL.Update(objMODELODISPOSITIVO);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(); //throw new MoebiusException(Translate.ORM.GetString("msg_error_al_grabar"), this.GetType().ToString(), ex);
            }
        }

	}
}

