
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
	/// BFGRUPOUSUARIO.
	/// </summary>
	public class BFCATALOGOUSUARIO
	{
		private DLCATALOGOUSUARIO _objDAL;
		private DLCATALOGOUSUARIOList _objDALList;
		
		public BFCATALOGOUSUARIO()
		{
			_objDAL = new DLCATALOGOUSUARIO();
			_objDALList = new DLCATALOGOUSUARIOList();
		}

		public ECATALOGOUSUARIO GetACTIVIDADUSUARIO()
		{
			return new ECATALOGOUSUARIO();
		}

		public ECATALOGOUSUARIO GetACTIVIDADUSUARIO(long id)
		{
            return new ECATALOGOUSUARIO(id);
        }

        
        public bool Save(ECATALOGOUSUARIO objCATALOGOUSUARIO)
		{
			try
			{
                //if(objCATALOGOUSUARIO.CodGrupoUsuario!=0) //para actualizar una asignación
                //{
                    objCATALOGOUSUARIO.Save();
                    return true;
                //}
                //else //para incribir una asignacion nueva
                //{
                //    //if (!_objDAL.ExisteAlumnoEnLaActividad(objCATALOGOUSUARIO.CodActividad, objCATALOGOUSUARIO.RutUsuario, objCATALOGOUSUARIO.FechaInicio))
                //    //{
                //    //    objCATALOGOUSUARIO.Save();
                //    //    return true;
                //    //}
                //    //else
                //    //{
                //    return false;
                //    //}
                //}
                
				
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool SaveTutor(ECATALOGOUSUARIO objCATALOGOUSUARIO)
        {
            try
            {
                if (objCATALOGOUSUARIO.Codcatalogo != 0) //para actualizar una asignación
                {
                    objCATALOGOUSUARIO.Save();
                    return true;
                }
                else //para incribir una asignacion nueva
                {
                    objCATALOGOUSUARIO.Save();
                    return true;

                    //if (!_objDAL.ExisteAlumnoEnLaActividad(objCATALOGOUSUARIO.CodActividad, objCATALOGOUSUARIO.RutUsuario, objCATALOGOUSUARIO.FechaInicio))
                    //{

                    //    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }


            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ECATALOGOUSUARIO> GetACTIVIDADUSUARIOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ECATALOGOUSUARIO objCATALOGOUSUARIO)
		{
			try
			{
                _objDAL.Delete(objCATALOGOUSUARIO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(ECATALOGOUSUARIO objCATALOGOUSUARIO)
        {
            try
            {
                _objDAL.Update(objCATALOGOUSUARIO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DataTable GetCatalogoAsignados(string listaRuts, string listaActividades, Int64 codEmpresa)
        {
            return _objDALList.GetCatalogoAsignados(listaRuts, listaActividades, codEmpresa);
        }
        public Boolean ExisteenGrupoUsuario(int codActividad, long rutUsuario)
        {
            return _objDAL.ExisteEnCATALOGOUsuario(codActividad, rutUsuario);
        }

        public DataTable GetActividadesAbiertaPortal(long rutusuario, Int64 codEmpresa)
        {
            return _objDAL.SelectActividadesVigentesPortal(rutusuario, codEmpresa);
        }

    }
}

