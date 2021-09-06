
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using System.Data;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFUNIDAD.
	/// </summary>
	public class BFUNIDAD
	{
		private DLUNIDAD _objDAL;
		private DLUNIDADList _objDALList;

        private string _detalleError;

        public System.String DetalleError
        {
            get { return _detalleError; }
            set { _detalleError = value; }
        }

        public BFUNIDAD()
		{
			_objDAL = new DLUNIDAD();
			_objDALList = new DLUNIDADList();
		}

		public EUNIDAD GetUNIDAD()
		{
			return new EUNIDAD();
		}

		public EUNIDAD GetUNIDAD(Int64 CodActivUsr, long id)
		{
            EUNIDAD objUnidad = new EUNIDAD(id);
            objUnidad.TiempoRestante = TiempoRestante(CodActivUsr, Utiles.ConvertToInt32(id));
            return objUnidad;
		}

        public EUNIDAD GetUNIDAD(long id)
        {
            return new EUNIDAD(id);
        }
     
        public bool Save(EUNIDAD objUNIDAD)
		{
			try
            {
                Int16 intCodUnidad;
                if (_objDAL.Existe(objUNIDAD.CodUnidad))
                {
                    intCodUnidad = objUNIDAD.CodUnidad;
                    objUNIDAD.IsPersisted = true;
                }
                else
                {
                    intCodUnidad = SerialUnidad();
                    objUNIDAD.CodUnidad = intCodUnidad;
                    objUNIDAD.IsPersisted = false;
                }
                
				objUNIDAD.Save();
                objUNIDAD.CodUnidad = intCodUnidad;

                BFFORO objBFFO = new BFFORO();
                EFORO objFO = new EFORO();
                if (!(objBFFO.ExisteForoUnidad(intCodUnidad)))
                {
                    objFO.Nombre = objUNIDAD.Nombre;
                    objFO.CodEmpresa = objUNIDAD.CodEmpresa;
                    objFO.Total = 0;
                    objFO.Ultimo = DateTime.Now;
                    objFO.Descripcion = "Unidad";
                    objFO.IdForo = objBFFO.SerialForo();

                    EUNIDADFORO objUF = new EUNIDADFORO();
                    objUF.IdForo = objFO.IdForo;
                    objUF.CodUnidad = intCodUnidad;

                    BFUNIDADFORO objBFUF = new BFUNIDADFORO();

                    objBFFO.Save(objFO);
                    objBFUF.Save(objUF);

                }

                if (!(System.IO.Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "contenidos\\Emp" + objFO.CodEmpresa + "\\uams\\" + intCodUnidad)))
                    System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "contenidos\\Emp" + objFO.CodEmpresa + "\\uams\\" + intCodUnidad);
                return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EUNIDAD> GetUNIDADAll(Int64 CodEmpresa)
		{
			return _objDALList.SelectAll(CodEmpresa);
		}

        public string GetNombreUnidad(int codUnidad, Int64 CodEmpresa)
        {
            return _objDALList.SelectNombreUnidad(codUnidad, CodEmpresa);
        }

        public List<EUNIDAD> GetUNIDADAllTUTOR(Int64 rutTutor, Int64 CodEmpresa)
        {
            return _objDALList.SelectAllTutor(rutTutor, CodEmpresa);
        }

		public List<EUNIDAD> GetUNIDADESACTIVIDADTIPO(Int32 CodActividad, Int16 CodTipo)
		{
			return _objDALList.GetUNIDADESACTIVIDADTIPO(CodActividad, CodTipo);
		}

        public bool Delete(EUNIDAD objUNIDAD)
		{
			try
            {
                _objDAL.Delete(objUNIDAD);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EUNIDAD objUNIDAD)
        {
            try
            {
                _objDAL.Update(objUNIDAD);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DataTable GetAvanceUnidades(long CodActivUsr, Int64 CodEmpresa)
        {
            return _objDALList.SelectAvanceUnidades(CodActivUsr,CodEmpresa);
        }

        public DataTable GetUnidadesSU(long CodActividad)
        {
            return _objDALList.SelectActividadSU(CodActividad);
        }

        public List<EUNIDAD> GetBuscadorUnidades(String Nombre, Int16 CodTipo, Int32 CodActividad,Int64 CodEmpresa, Int64 RutTutor, Int16 codEstado)
        {
            return _objDALList.SelectBuscadorUnidad(Nombre, CodTipo, CodActividad,CodEmpresa, RutTutor, codEstado);
        }

        public DataTable SubirUnidad(string Archivo, string Path)
        {
            //if(Utiles.Descomprimir(Archivo, Path))
            //{
            //    return ArchivosUnidad(Path);
            //}
            //else
            //{
                return new DataTable();
            //}
            
        }
        //se sube el archivo de la unidad quw no sea zzip
        public DataTable SubirUnidadNoZip(string Archivo, string Path)
        {
                return ArchivosUnidad(Path);
        }


        public Boolean ComprobarArchivo(string Archivo, string Path)
        {
            //if(Utiles.Descomprimir(Archivo, Path))
            //{
            //    DataTable dt = ArchivosUnidad(Path);

            //    ////después de descomprimir, busco el archivo imsmanifest.xml
            //    string buscar = "Archivo = 'imsmanifest.xml'";
            //    DataRow[] datos = dt.Select(buscar);

            //    if (datos.Length > 0) //si existe el archivo lo cargo
            //    {
            //        XDocument documento = XDocument.Load(Path + "\\imsmanifest.xml");

            //        documento.Root.RemoveAttributes(); //elimino los atributos de los nodos que no importan

            //        //debido a que no se borraba el atributo xmlns, lo paso a un dataset para trabajarlo.
            //        DataSet ds = new DataSet();
            //        ds.ReadXml(Path + "\\imsmanifest.xml");

            //        // verifico que la versión sea la correcta CAM 1.3
            //        if (ds.Tables["metadata"].Rows[0]["schemaversion"].ToString() == "1.2" || ds.Tables["metadata"].Rows[0]["schemaversion"].ToString() == "CAM 1.3")
            //        {
            //            //si la versión es la misma reemplazo el archvio API.js modificado para que llame a la funcion avisatermino()
            //            if (System.IO.File.Exists(Path + "\\lms\\API.js"))
            //            {
            //                System.IO.File.Delete(Path + "\\lms\\API.js");
            //                System.IO.File.Copy(System.AppDomain.CurrentDomain.BaseDirectory + "\\contenidos\\scorm\\API.js", Path + "\\lms\\API.js");
            //            }
            //            else
            //            {
            //                _detalleError = "Error al cargar el archivo: No existe el archivo API.js.";
            //                documento = null;
            //                return false;
            //            }

            //            // HACEMOS LO MISMO PARA EL ARCHIVO SCORMFunctions.js
            //            if (System.IO.File.Exists(Path + "\\lms\\SCORMFunctions.js"))
            //            {
            //                System.IO.File.Delete(Path + "\\lms\\SCORMFunctions.js");
            //                System.IO.File.Copy(System.AppDomain.CurrentDomain.BaseDirectory + "\\contenidos\\scorm\\SCORMFunctions.js", Path + "\\lms\\SCORMFunctions.js");
            //            }
            //            else
            //            {
            //                _detalleError = "Error al cargar el archivo: No existe el archivo SCORMFunctions.js.";
            //                documento = null;
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            _detalleError = "Error al cargar el archivo: La versión no es compatible (versión requerida: 1.2).";
            //            documento = null;
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        _detalleError = "Error al cargar el archivo: No existe el archivo imsmanifest.xml";
            //        return false;
            //    }

            //    return true;
            //}
            //else
            //{
            //    _detalleError = "Error al cargar el archivo: Verificar si el archivo no se encuentra dañado.";
            //    return false;
            //}

            return false;

            
        }

        public DataTable ArchivosUnidad(string Path)
        {
            DataTable dt = Utiles.ListaArchivos(Path);
            return dt;
        }

        private Int32 TiempoRestante(Int64 CodActivUsr, Int32 CodUnidad)
        {
            return _objDALList.TiempoRestante(CodActivUsr, CodUnidad);
        }

        public Int16 SerialUnidad()
        {
            return _objDAL.Serial();
        }

        public void ActualizaEstadoUnidad(long CodUnidad, Boolean flag_activo)
        {
            _objDAL.ActualizaEstadoUnidad(CodUnidad, flag_activo);
        }
    }
}

