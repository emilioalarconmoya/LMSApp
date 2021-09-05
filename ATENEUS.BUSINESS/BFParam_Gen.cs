
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFParamGen.
	/// </summary>
	public class BFParamGen
	{
		private DLParamGen _objDAL;
		private DLParamGenList _objDALList;
		
		public BFParamGen()
		{
			_objDAL = new DLParamGen();
			_objDALList = new DLParamGenList();
		}

		public EParamGen GetParamGen()
		{
			return new EParamGen();
		}

		public EParamGen GetParamGen(long id)
		{
            return new EParamGen(id);
		}

		public bool Save(EParamGen objParamGen)
		{
			try
			{
				objParamGen.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EParamGen> GetParamGenAll(Int64 Cod_Empresa)
		{
			return _objDALList.SelectAll(Cod_Empresa);
		}

        public bool Delete(EParamGen objParamGen)
		{
			try
			{
                _objDAL.Delete(objParamGen);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EParamGen objParamGen)
        {
            try
            {
                _objDAL.Update(objParamGen);
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

