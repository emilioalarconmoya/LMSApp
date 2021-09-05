
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using System.Data;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.IO;
using System.Text;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFACTIVIDADCAPAC.
	/// </summary>
	public class BFACTIVIDADCAPAC
	{
		private DLACTIVIDADCAPAC _objDAL;
		private DLACTIVIDADCAPACList _objDALList;
		
		public BFACTIVIDADCAPAC()
		{
			_objDAL = new DLACTIVIDADCAPAC();
			_objDALList = new DLACTIVIDADCAPACList();
		}

		public EACTIVIDADCAPAC GetACTIVIDADCAPAC()
		{
			return new EACTIVIDADCAPAC();
		}

		public EACTIVIDADCAPAC GetACTIVIDADCAPAC(long id)
		{
            return new EACTIVIDADCAPAC(id);
		}

		public Int16 Save(EACTIVIDADCAPAC objACTIVIDADCAPAC)
		{
			try 
			{
                Int16 CodActividad = objACTIVIDADCAPAC.CodActividad;
                objACTIVIDADCAPAC.IsPersisted = _objDAL.ExisteActividad(objACTIVIDADCAPAC.CodActividad);
                if (objACTIVIDADCAPAC.IsPersisted == false)
                {
                    CodActividad = Utiles.ConvertToInt16(_objDAL.Serial());
                    objACTIVIDADCAPAC.CodActividad = CodActividad;
                    objACTIVIDADCAPAC.Vigente = true;
                }
				objACTIVIDADCAPAC.Save();

                BFFORO objBFFO = new BFFORO();
                EFORO objFO = new EFORO();
                if (!(objBFFO.ExisteForoActividad(objACTIVIDADCAPAC.CodActividad)))
                {
                    objFO.Nombre = objACTIVIDADCAPAC.Nombre;
                    objFO.Total = 0;
                    objFO.Ultimo = DateTime.Now;
                    objFO.Descripcion = "Curso";
                    objFO.IdForo = objBFFO.SerialForo();
                    objFO.CodEmpresa = objACTIVIDADCAPAC.CodEmpresa;
                    EACTIVIDADFORO objAF = new EACTIVIDADFORO();
                    objAF.IdForo = objFO.IdForo;
                    objAF.CodActividad = CodActividad;

                    BFACTIVIDADFORO objBFAF = new BFACTIVIDADFORO();

                    objBFFO.Save(objFO);
                    objBFAF.Save(objAF);

                }

                return CodActividad;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return 0;
            }
        }

		public List<EACTIVIDADCAPAC> GetACTIVIDADCAPACAll(Int64 CodEmpresa)
		{
			return _objDALList.SelectAll(CodEmpresa);
		}
		 public List<EACTIVIDADCAPAC> GetACTIVIDADCAPACAllPORATRIBUTO(int codCaracteristica, int codAtributo,Int64 CodEmpresa)
        {
            return _objDALList.SelectAllPorAtributo(codCaracteristica, codAtributo,CodEmpresa);
        }
        public List<EACTIVIDADCAPAC> GetACTIVIDADCAPACCodActividad(Int32 codActividad, Int64 CodEmpresa)
        {
            return _objDALList.SelectActividad(codActividad);
        }
        public List<EACTIVIDADCAPAC> GetACTIVIDADCAPACAllTUTOR(long rutTutor)
        {
            return _objDALList.SelectAllTutor(rutTutor);
        }
 
        public List<EACTIVIDADCAPAC> GetACTIVIDADCAPACMALLAAll()
        {
            return _objDALList.SelectActividadMallaAll();
        }

        public List<EACTIVIDADCAPAC> GetBuscaActividadMalla(String Nombre, Int64 CodEmpresa)
        {
            return _objDALList.SelectBuscadorActividad(Nombre, CodEmpresa);
        }

        public bool Delete(EACTIVIDADCAPAC objACTIVIDADCAPAC)
		{
			try
			{
                _objDAL.Delete(objACTIVIDADCAPAC);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EACTIVIDADCAPAC objACTIVIDADCAPAC)
        {
            try
            {
                _objDAL.Update(objACTIVIDADCAPAC);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DataTable GetFichaActividad(long CodActividad)
        {
            return _objDALList.SelectFichaActividad(CodActividad);
        }

        public List<EACTIVIDADCAPAC> GetActividadesParametros(string Nombre, Int32 CodProveedor, Int16 CodTipo, string  CodSence,Int64 CodEmpresa, long RutTutor, Int16 codEstado)
        {
            return _objDALList.SelectActividadesParametros(Nombre, CodProveedor, CodTipo, CodSence,CodEmpresa,RutTutor, codEstado);
        }

        public List<EACTIVIDADCAPAC> ListaActividadesConEncuesta(Int16 CodTipo, Int64 CodEmpresa)
        {
            return _objDALList.ListaActividadesConEncuesta(CodTipo,CodEmpresa);
        }


        public void CargarMaterialApoyo(string Archivo, string strRuta, Int16 CodActividad, string strRutaFisica)
        {
            try
            {
                DataTable dt = ArchivosUnidad(strRuta);
                System.IO.Directory.GetFiles(strRuta);

                BFMATERIALAPOYO objBFMatApoyo = new BFMATERIALAPOYO();
                List<EMATERIALAPOYO> objLstMatApo = new List<EMATERIALAPOYO>();
                objLstMatApo = objBFMatApoyo.GetMaterialApoyoActividad(CodActividad);
                foreach (EMATERIALAPOYO obj in objLstMatApo)
                {
                    objBFMatApoyo.Delete(obj);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    
                    EMATERIALAPOYO obj = new EMATERIALAPOYO();
                    obj.Archivo = strRutaFisica + dr["archivo"];
                    obj.CodActividad = CodActividad;
                    obj.Descripcion = "";
                    obj.Nombre = Utiles.ConvertToString(dr["archivo"]);
                    objBFMatApoyo.Save(obj);
                }

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
            }
        }

        public void EliminaMaterialApoyo(Int16 CodActividad)
        {
            try
            {
                //DataTable dt = ArchivosUnidad(strRuta);
                //System.IO.Directory.GetFiles(strRuta);

                BFMATERIALAPOYO objBFMatApoyo = new BFMATERIALAPOYO();
                List<EMATERIALAPOYO> objLstMatApo = new List<EMATERIALAPOYO>();
                objLstMatApo = objBFMatApoyo.GetMaterialApoyoActividad(CodActividad);
                foreach (EMATERIALAPOYO obj in objLstMatApo)
                {
                    objBFMatApoyo.Delete(obj);
                }
                //foreach (DataRow dr in dt.Rows)
                //{

                //    EMATERIALAPOYO obj = new EMATERIALAPOYO();
                //    obj.Archivo = strRutaFisica + dr["archivo"];
                //    obj.CodActividad = CodActividad;
                //    obj.Descripcion = "";
                //    obj.Nombre = Utiles.ConvertToString(dr["archivo"]);
                //    objBFMatApoyo.Save(obj);
                //}

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
            }
        }

        public void CargarMaterialApoyoTutor(string Archivo, string strRuta, Int16 CodActividadtutor, string strRutaFisica, string Descripcion, Int64 CodEmpresa)
        {
            try
            {
                DataTable dt = ArchivosUnidad(strRuta);
                System.IO.Directory.GetFiles(strRuta);

                BFMATERIALAPOYO objBFMatApoyo = new BFMATERIALAPOYO();
                //List<EMATERIALAPOYOTUTOR> objLstMatApo = new List<EMATERIALAPOYOTUTOR>();
                //objLstMatApo = objBFMatApoyo.GetMaterialApoyoActividad(CodActividadtutor);
                //foreach (EMATERIALAPOYOTUTOR obj in objLstMatApo)
                //{
                //    objBFMatApoyo.Delete(obj);
                //}
                //foreach (DataRow dr in dt.Rows)
                //{

                    EMATERIALAPOYO obj = new EMATERIALAPOYO();
                    obj.Archivo = strRutaFisica + Archivo;
                    obj.CodActividad = CodActividadtutor;
                    obj.Descripcion = Descripcion;
                    obj.Nombre = Archivo;
                    //obj.CodEmpresa = CodEmpresa;
                    objBFMatApoyo.Save(obj);
                //}

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
            }
        }

        public DataTable ArchivosUnidad(string Path)
        {
            DataTable dt = Utiles.ListaArchivos(Path);
            return dt;
        }

        public Int16 SerialActidad()
        {
            return _objDAL.Serial();
        }
        public void ActualizaEstadoActividad(long CodActividad, Boolean flag_activo)
        {
            _objDAL.ActualizaEstadoActividad(CodActividad, flag_activo);
        }

        public DataTable CategoriaActividad(Int64 codEmpresa)
        {
            return _objDALList.SelectCategoriaActividad(codEmpresa);
        }

    }
}

