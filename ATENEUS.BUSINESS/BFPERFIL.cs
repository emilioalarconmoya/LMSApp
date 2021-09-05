
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFPERFIL.
	/// </summary>
	public class BFPERFIL
	{
		private DLPERFIL _objDAL;
		private DLPERFILList _objDALList;
		
		public BFPERFIL()
		{
			_objDAL = new DLPERFIL();
			_objDALList = new DLPERFILList();
		}

		public EPERFIL GetPERFIL()
		{
			return new EPERFIL();
		}

		public EPERFIL GetPERFIL(long id)
		{
            return new EPERFIL(id);
		}

		public bool Save(EPERFIL objPERFIL)
		{
			try
			{
				objPERFIL.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EPERFIL> GetPERFILAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPERFIL objPERFIL)
		{
			try
			{
                _objDAL.Delete(objPERFIL);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EPERFIL objPERFIL)
        {
            try
            {
                _objDAL.Update(objPERFIL);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<EPERFIL> GetPerfilesAsignados(Int64 RutUsuario)
        {
            return _objDALList.SelectPerfilesAsignados(RutUsuario);
        }

        public List<EPERFIL> GetPerfilesDisponibles(Int64 RutUsuario)
        {
            return _objDALList.SelectPerfilesDisponibles(RutUsuario);
        }


	}
}

