
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFMALLA.
	/// </summary>
	public class BFMALLA
	{
		private DLMALLA _objDAL;
		private DLMALLAList _objDALList;
		
		public BFMALLA()
		{
			_objDAL = new DLMALLA();
			_objDALList = new DLMALLAList();
		}

		public EMALLA GetMALLA()
		{
			return new EMALLA();
		}

		public EMALLA GetMALLA(long id)
		{
            return new EMALLA(id);
		}

        public EMALLA GetMALLA(long id, Int64 CodEmpresa)
        {
            return new EMALLA(id, CodEmpresa);
        }


        public Int32 Save(EMALLA objMALLA)
		{
			try
			{
                //Int32 CodMalla = objMALLA.CodMalla;
                //if (objMALLA.IsPersisted == false)
                //{
                //    //CodMalla = Utiles.ConvertToInt16(_objDAL.Serial());
                //    objMALLA.CodMalla = CodMalla;
                //}
                //else
                //{
                //    CodMalla = objMALLA.CodMalla;
                //}
                objMALLA.Save();
				return objMALLA.CodMalla;
            }
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return 0;
            }
        }

		public List<EMALLA> GetMALLAAll(Int64 CodEmpresa)
		{
			return _objDALList.SelectAll(CodEmpresa);
		}

        public bool Delete(EMALLA objMALLA)
		{
			try
			{
                _objDAL.Delete(objMALLA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EMALLA objMALLA)
        {
            try
            {
                _objDAL.Update(objMALLA);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<EMALLA> GetMallasParametros(string Nombre, Int16 codEstado, Int64 CodEmpresa)
        {
            return _objDALList.SelectMallasParametros(Nombre, codEstado, CodEmpresa);
        }

        public List<EMALLA> GetMallasParametrosConCaracteristicas(string Nombre, Int16 codEstado, Int16 codCaracteristica, Int16 codAtributo,Int64 CodEmpresa)
        {
            return _objDALList.SelectMallasParametrosConCaracteristicas(Nombre, codEstado, codCaracteristica, codAtributo,CodEmpresa);
        }

    }
}

