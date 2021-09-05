
using System;
using System.Collections.Generic;
using System.Data;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFATRIBUTOUSUARIO.
	/// </summary>
	public class BFATRIBUTOUSUARIO
	{
		private DLATRIBUTOUSUARIO _objDAL;
		private DLATRIBUTOUSUARIOList _objDALList;
		
		public BFATRIBUTOUSUARIO()
		{
			_objDAL = new DLATRIBUTOUSUARIO();
			_objDALList = new DLATRIBUTOUSUARIOList();
		}

		public EATRIBUTOUSUARIO GetATRIBUTOUSUARIO()
		{
			return new EATRIBUTOUSUARIO();
		}

		public EATRIBUTOUSUARIO GetATRIBUTOUSUARIO(long id)
		{
            return new EATRIBUTOUSUARIO(id);
		}

		public bool Save(EATRIBUTOUSUARIO objATRIBUTOUSUARIO)
		{
			try
			{
				objATRIBUTOUSUARIO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EATRIBUTOUSUARIO> GetATRIBUTOUSUARIOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EATRIBUTOUSUARIO objATRIBUTOUSUARIO)
		{
			try
			{
                _objDAL.Delete(objATRIBUTOUSUARIO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EATRIBUTOUSUARIO objATRIBUTOUSUARIO)
        {
            try
            {
                _objDAL.Update(objATRIBUTOUSUARIO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DataTable GetAtributosUsuario(Int64 RutUsuario,Int64 CodEmpresa)
        {
            return _objDALList.GetAtributosUsuario(RutUsuario,CodEmpresa);
        }

    }
}

