
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFPLANTILLA.
	/// </summary>
	public class BFPLANTILLA
	{
		private DLPLANTILLA _objDAL;
		private DLPLANTILLAList _objDALList;
		
		public BFPLANTILLA()
		{
			_objDAL = new DLPLANTILLA();
			_objDALList = new DLPLANTILLAList();
		}

		public EPLANTILLA GetPLANTILLA()
		{
			return new EPLANTILLA();
		}

		public EPLANTILLA GetPLANTILLA(long id)
		{
            return new EPLANTILLA(id);
		}

		public Decimal Save(EPLANTILLA objPLANTILLA)
		{
			try
			{
                if (objPLANTILLA.CodPlantilla == 0)
                {
                    objPLANTILLA.IsPersisted = false;
                }
                else
                {
                    objPLANTILLA.IsPersisted = true;
                }
				objPLANTILLA.Save();
                foreach (ECAMPO objCA in objPLANTILLA.Campos)
                {
                    BFCAMPOPLANTILLA objBFCP = new BFCAMPOPLANTILLA();
                    ECAMPOPLANTILLA objCP = new ECAMPOPLANTILLA();
                    objCP.CodCampo = objCA.CodCampo;
                    objCP.Orden = objCA.Orden;
                    objCP.CodPlantilla = objPLANTILLA.CodPlantilla;
                    objBFCP.Save(objCP);
                }
				return objPLANTILLA.CodPlantilla;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return 0;
            }
        }

		public List<EPLANTILLA> GetPLANTILLAAll(Int64 CodEmpresa)
		{
			return _objDALList.SelectAll(CodEmpresa);
        }

        public List<EPLANTILLA> GetPLANTILLABYNOMBRE(string Nombre,Int64 CodEmpresa)
        {
            return _objDALList.GetPlantillasByNombre(Nombre,CodEmpresa);
        }

        public bool Delete(EPLANTILLA objPLANTILLA)
		{
			try
			{
                _objDAL.Delete(objPLANTILLA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool DeletePlantilla(Decimal CodPlantilla)
        {
            try
            {
                return _objDALList.DelPlantillaCampos(CodPlantilla);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EPLANTILLA objPLANTILLA)
        {
            try
            {
                _objDAL.Update(objPLANTILLA);
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

