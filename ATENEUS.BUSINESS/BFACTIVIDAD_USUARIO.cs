
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
	/// BFACTIVIDADUSUARIO.
	/// </summary>
	public class BFACTIVIDADUSUARIO
	{
		private DLACTIVIDADUSUARIO _objDAL;
		private DLACTIVIDADUSUARIOList _objDALList;
		
		public BFACTIVIDADUSUARIO()
		{
			_objDAL = new DLACTIVIDADUSUARIO();
			_objDALList = new DLACTIVIDADUSUARIOList();
		}

		public EACTIVIDADUSUARIO GetACTIVIDADUSUARIO()
		{
			return new EACTIVIDADUSUARIO();
		}

		public EACTIVIDADUSUARIO GetACTIVIDADUSUARIO(long id)
		{
            return new EACTIVIDADUSUARIO(id);
        }

        public bool GetPoseeTutor(long CodActivUsr)
        {
            return _objDALList.GetPoseeTutor(CodActivUsr);
        }

        public bool Save(EACTIVIDADUSUARIO objACTIVIDADUSUARIO)
		{
			try
			{
                if (objACTIVIDADUSUARIO.CodActivUsr != 0) //para actualizar una asignación
                {
                    objACTIVIDADUSUARIO.Save();
                    return true;
                }
                else //para incribir una asignacion nueva
                {
                    if (!_objDAL.ExisteAlumnoEnLaActividad(objACTIVIDADUSUARIO.CodActividad, objACTIVIDADUSUARIO.RutUsuario, objACTIVIDADUSUARIO.FechaInicio, objACTIVIDADUSUARIO.CodEmpresa))
                    {
                        objACTIVIDADUSUARIO.Save();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
				
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool SaveTutor(EACTIVIDADUSUARIO objACTIVIDADUSUARIO)
        {
            try
            {
                if (objACTIVIDADUSUARIO.CodActivUsr != 0) //para actualizar una asignación
                {
                    objACTIVIDADUSUARIO.Save();
                    return true;
                }
                else //para incribir una asignacion nueva
                {
                    objACTIVIDADUSUARIO.Save();
                    return true;

                    //if (!_objDAL.ExisteAlumnoEnLaActividad(objACTIVIDADUSUARIO.CodActividad, objACTIVIDADUSUARIO.RutUsuario, objACTIVIDADUSUARIO.FechaInicio))
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

		public List<EACTIVIDADUSUARIO> GetACTIVIDADUSUARIOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EACTIVIDADUSUARIO objACTIVIDADUSUARIO)
		{
			try
			{
                _objDAL.Delete(objACTIVIDADUSUARIO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EACTIVIDADUSUARIO objACTIVIDADUSUARIO)
        {
            try
            {
                _objDAL.Update(objACTIVIDADUSUARIO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public DataTable GetActividadesVigentes(long Rut, Int16 DiasEspera,Int64 CodEmpresa, Int32 horaZona)
        {
            return _objDALList.SelectActividadesVigentes(Rut, DiasEspera,CodEmpresa, horaZona);
        }

        public DataTable GetActividadesVigentes(long Rut, string Email, Int16 DiasEspera)
        {
            return _objDALList.SelectActividadesVigentes(Rut, DiasEspera);
        }

        public List<EACTIVIDADUSUARIO> GetActividadesAsignadas(DateTime FechaInicio, DateTime FechaFin, string listaRuts, string listaActividades,Int64 CodEmpresa)
        {
            return _objDALList.GetActividadesAsignadas(FechaInicio, FechaFin, listaRuts, listaActividades,CodEmpresa);
        }

        public DataTable GetHistorialUsuario(long Rut,Int64 CodEmpresa)
        {
            return _objDALList.SelectHistorialUsuario(Rut,CodEmpresa);
        }

        public DataTable GetActividadesBuscador(string Nombre, Int16 Tipo, Boolean Abierta, Boolean Inscripcion)
        {
            return _objDALList.SelectActividadesBuscador(Nombre, Tipo, Abierta, Inscripcion);
        }

        public DataTable GetBuscadorCursos(string Nombre, Int64 CodEmpresa)
        {
            return _objDALList.SelectActividadesBuscadorCursos(Nombre, CodEmpresa);
        }

        public DataTable GetBuscadorTutoriales(string Nombre, Int64 CodEmpresa)
        {
            return _objDALList.SelectActividadesBuscadorTutoriales(Nombre, CodEmpresa);
        }

        public DataTable GetBuscadorDoctos(string Nombre, Int64 CodEmpresa)
        {
            return _objDALList.SelectActividadesBuscadorDoctos(Nombre, CodEmpresa);
        }

        public DataTable GetBuscadorVideos(string Nombre, Int64 CodEmpresa)
        {
            return _objDALList.SelectActividadesBuscadorVideos(Nombre, CodEmpresa);
        }

        public DataTable GetBuscadorImagenes(string Nombre, Int64 CodEmpresa)
        {
            return _objDALList.SelectActividadesBuscadorImagenes(Nombre, CodEmpresa);
        }

        public DataTable GetReporteGeneral(Int32 CodActividad, long RutUsuario, DateTime FechaInicial, DateTime FechaFinal)
        {
            return _objDALList.SelectReporteGeneral(CodActividad, RutUsuario, FechaInicial, FechaFinal);
        }

        public DataTable GetInformeAlumnos(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal,Int64 CodEmpresa)
        {
            DataTable dt = _objDALList.SelectInformeAlumnos(CodActividad, FechaInicial, FechaFinal,CodEmpresa);
            long SumConRepeticion = 0;
            long SumSinRepeticion = 0;
            foreach (DataRow dr in dt.Rows)
            {
                SumConRepeticion = SumConRepeticion + Utiles.ConvertToInt32(dr["CON REPETICION"]);
                SumSinRepeticion = SumSinRepeticion + Utiles.ConvertToInt32(dr["SIN REPETICION"]);
            }
            DataRow NuevaFila;
            NuevaFila = dt.NewRow();
            NuevaFila["CON REPETICION"] = SumConRepeticion;
            NuevaFila["SIN REPETICION"] = SumSinRepeticion;
            NuevaFila["ACTIVIDAD"] = "TODAS";
            dt.Rows.Add(NuevaFila);

            return dt;
        }

        public DataTable GetInformeAlumnosPorMes(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal)
        {
            DataTable dt = _objDALList.SelectInformeAlumnosPorMes(CodActividad, FechaInicial, FechaFinal);
            Boolean Enero = false;
            Boolean Febrero = false;
            Boolean Marzo = false;
            Boolean Abril = false;
            Boolean Mayo = false;
            Boolean Junio = false;
            Boolean Julio = false;
            Boolean Agosto = false;
            Boolean Septiembre = false;
            Boolean Octubre = false;
            Boolean Noviembre = false;
            Boolean Diciembre = false;

            int CantEnero = 0;
            int CantFebrero = 0;
            int CantMarzo = 0;
            int CantAbril = 0;
            int CantMayo = 0;
            int CantJunio = 0;
            int CantJulio = 0;
            int CantAgosto = 0;
            int CantSeptiembre = 0;
            int CantOctubre = 0;
            int CantNoviembre = 0;
            int CantDiciembre = 0;

            string NombreActividad = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (CodActividad == -1)
                {
                    switch (Utiles.ConvertToString(dr["MES"]))
                    {
                        case "ENERO":
                            CantEnero = CantEnero + Utiles.ConvertToInt32(dr["ALUMNOS"]);
                            break;
                        case "FEBRERO":
                            CantFebrero = CantFebrero + Utiles.ConvertToInt32(dr["ALUMNOS"]);
                            break;
                        case "MARZO":
                            CantMarzo = CantMarzo + Utiles.ConvertToInt32(dr["ALUMNOS"]);
                            break;
                        case "ABRIL":
                            CantAbril = CantAbril + Utiles.ConvertToInt32(dr["ALUMNOS"]);
                            break;
                        case "MAYO":
                            CantMayo = CantMayo + Utiles.ConvertToInt32(dr["ALUMNOS"]);
                            break;
                        case "JUNIO":
                            CantJunio = CantJunio + Utiles.ConvertToInt32(dr["ALUMNOS"]);
                            break;
                        case "JULIO":
                            CantJulio = CantJulio + Utiles.ConvertToInt32(dr["ALUMNOS"]);
                            break;
                        case "AGOSTO":
                            CantAgosto = CantAgosto + Utiles.ConvertToInt32(dr["ALUMNOS"]);
                            break;
                        case "SEPTIEMBRE":
                            CantSeptiembre = CantSeptiembre + Utiles.ConvertToInt32(dr["ALUMNOS"]);
                            break;
                        case "OCTUBRE":
                            CantOctubre = CantOctubre + Utiles.ConvertToInt32(dr["ALUMNOS"]);
                            break;
                        case "NOVIEMBRE":
                            CantNoviembre = CantNoviembre + Utiles.ConvertToInt32(dr["ALUMNOS"]);
                            break;
                        case "DICIEMBRE":
                            CantDiciembre = CantDiciembre + Utiles.ConvertToInt32(dr["ALUMNOS"]);
                            break;
                    }
                }
                if ((Utiles.ConvertToInt32(dr["COD_ACTIVIDAD"]) == CodActividad))
                {
                    NombreActividad = Utiles.ConvertToString(dr["ACTIVIDAD"]);
                    switch (Utiles.ConvertToString(dr["MES"]))
                    {
                        case "ENERO":
                            Enero = true;
                            break;
                        case "FEBRERO":
                            Febrero = true;
                            break;
                        case "MARZO":
                            Marzo = true;
                            break;
                        case "ABRIL":
                            Abril = true;
                            break;
                        case "MAYO":
                            Mayo = true;
                            break;
                        case "JUNIO":
                            Junio = true;
                            break;
                        case "JULIO":
                            Julio = true;
                            break;
                        case "AGOSTO":
                            Agosto = true;
                            break;
                        case "SEPTIEMBRE":
                            Septiembre = true;
                            break;
                        case "OCTUBRE":
                            Octubre = true;
                            break;
                        case "NOVIEMBRE":
                            Noviembre = true;
                            break;
                        case "DICIEMBRE":
                            Diciembre = true;
                            break;
                    }
                }
            }
            if (CodActividad != -1)
            {
                if (Enero == false)
                {
                    DataRow drtmp;
                    drtmp = dt.NewRow();
                    drtmp["ALUMNOS"] = 0;
                    drtmp["COD MES"] = 1;
                    drtmp["COD_ACTIVIDAD"] = CodActividad;
                    drtmp["ACTIVIDAD"] = NombreActividad;
                    drtmp["MES"] = "ENERO";
                    dt.Rows.Add(drtmp);
                }
                if (Febrero == false)
                {
                    DataRow drtmp;
                    drtmp = dt.NewRow();
                    drtmp["ALUMNOS"] = 0;
                    drtmp["COD MES"] = 2;
                    drtmp["COD_ACTIVIDAD"] = CodActividad;
                    drtmp["ACTIVIDAD"] = NombreActividad;
                    drtmp["MES"] = "FEBRERO";
                    dt.Rows.Add(drtmp);
                }
                if (Marzo == false)
                {
                    DataRow drtmp;
                    drtmp = dt.NewRow();
                    drtmp["ALUMNOS"] = 0;
                    drtmp["COD MES"] = 3;
                    drtmp["COD_ACTIVIDAD"] = CodActividad;
                    drtmp["ACTIVIDAD"] = NombreActividad;
                    drtmp["MES"] = "MARZO";
                    dt.Rows.Add(drtmp);
                }
                if (Abril == false)
                {
                    DataRow drtmp;
                    drtmp = dt.NewRow();
                    drtmp["ALUMNOS"] = 0;
                    drtmp["COD MES"] = 4;
                    drtmp["COD_ACTIVIDAD"] = CodActividad;
                    drtmp["ACTIVIDAD"] = NombreActividad;
                    drtmp["MES"] = "ABRIL";
                    dt.Rows.Add(drtmp);
                }
                if (Mayo == false)
                {
                    DataRow drtmp;
                    drtmp = dt.NewRow();
                    drtmp["ALUMNOS"] = 0;
                    drtmp["COD MES"] = 5;
                    drtmp["COD_ACTIVIDAD"] = CodActividad;
                    drtmp["ACTIVIDAD"] = NombreActividad;
                    drtmp["MES"] = "MAYO";
                    dt.Rows.Add(drtmp);
                }
                if (Junio == false)
                {
                    DataRow drtmp;
                    drtmp = dt.NewRow();
                    drtmp["ALUMNOS"] = 0;
                    drtmp["COD MES"] = 6;
                    drtmp["COD_ACTIVIDAD"] = CodActividad;
                    drtmp["ACTIVIDAD"] = NombreActividad;
                    drtmp["MES"] = "JUNIO";
                    dt.Rows.Add(drtmp);
                }
                if (Julio == false)
                {
                    DataRow drtmp;
                    drtmp = dt.NewRow();
                    drtmp["ALUMNOS"] = 0;
                    drtmp["COD MES"] = 7;
                    drtmp["COD_ACTIVIDAD"] = CodActividad;
                    drtmp["ACTIVIDAD"] = NombreActividad;
                    drtmp["MES"] = "JULIO";
                    dt.Rows.Add(drtmp);
                }
                if (Agosto == false)
                {
                    DataRow drtmp;
                    drtmp = dt.NewRow();
                    drtmp["ALUMNOS"] = 0;
                    drtmp["COD MES"] = 8;
                    drtmp["COD_ACTIVIDAD"] = CodActividad;
                    drtmp["ACTIVIDAD"] = NombreActividad;
                    drtmp["MES"] = "AGOSTO";
                    dt.Rows.Add(drtmp);
                }
                if (Septiembre == false)
                {
                    DataRow drtmp;
                    drtmp = dt.NewRow();
                    drtmp["ALUMNOS"] = 0;
                    drtmp["COD MES"] = 9;
                    drtmp["COD_ACTIVIDAD"] = CodActividad;
                    drtmp["ACTIVIDAD"] = NombreActividad;
                    drtmp["MES"] = "SEPTIEMBRE";
                    dt.Rows.Add(drtmp);
                }
                if (Octubre == false)
                {
                    DataRow drtmp;
                    drtmp = dt.NewRow();
                    drtmp["ALUMNOS"] = 0;
                    drtmp["COD MES"] = 10;
                    drtmp["COD_ACTIVIDAD"] = CodActividad;
                    drtmp["ACTIVIDAD"] = NombreActividad;
                    drtmp["MES"] = "OCTUBRE";
                    dt.Rows.Add(drtmp);
                }
                if (Noviembre == false)
                {
                    DataRow drtmp;
                    drtmp = dt.NewRow();
                    drtmp["ALUMNOS"] = 0;
                    drtmp["COD MES"] = 11;
                    drtmp["COD_ACTIVIDAD"] = CodActividad;
                    drtmp["ACTIVIDAD"] = NombreActividad;
                    drtmp["MES"] = "NOVIEMBRE";
                    dt.Rows.Add(drtmp);
                }
                if (Diciembre == false)
                {
                    DataRow drtmp;
                    drtmp = dt.NewRow();
                    drtmp["ALUMNOS"] = 0;
                    drtmp["COD MES"] = 12;
                    drtmp["COD_ACTIVIDAD"] = CodActividad;
                    drtmp["ACTIVIDAD"] = NombreActividad;
                    drtmp["MES"] = "DICIEMBRE";
                    dt.Rows.Add(drtmp);
                }
            }

            if (CodActividad == -1)
            {
                DataRow drtmp;
                drtmp = dt.NewRow();
                drtmp["ALUMNOS"] = CantEnero;
                drtmp["COD MES"] = 1;
                drtmp["COD_ACTIVIDAD"] = CodActividad;
                drtmp["ACTIVIDAD"] = "TODAS";
                drtmp["MES"] = "ENERO";
                dt.Rows.Add(drtmp);

                drtmp = dt.NewRow();
                drtmp["ALUMNOS"] = CantFebrero;
                drtmp["COD MES"] = 2;
                drtmp["COD_ACTIVIDAD"] = CodActividad;
                drtmp["ACTIVIDAD"] = "TODAS";
                drtmp["MES"] = "FEBRERO";
                dt.Rows.Add(drtmp);

                drtmp = dt.NewRow();
                drtmp["ALUMNOS"] = CantMarzo;
                drtmp["COD MES"] = 3;
                drtmp["COD_ACTIVIDAD"] = CodActividad;
                drtmp["ACTIVIDAD"] = "TODAS";
                drtmp["MES"] = "MARZO";
                dt.Rows.Add(drtmp);

                drtmp = dt.NewRow();
                drtmp["ALUMNOS"] = CantAbril;
                drtmp["COD MES"] = 4;
                drtmp["COD_ACTIVIDAD"] = CodActividad;
                drtmp["ACTIVIDAD"] = "TODAS";
                drtmp["MES"] = "ABRIL";
                dt.Rows.Add(drtmp);

                drtmp = dt.NewRow();
                drtmp["ALUMNOS"] = CantMayo;
                drtmp["COD MES"] = 5;
                drtmp["COD_ACTIVIDAD"] = CodActividad;
                drtmp["ACTIVIDAD"] = "TODAS";
                drtmp["MES"] = "MAYO";
                dt.Rows.Add(drtmp);

                drtmp = dt.NewRow();
                drtmp["ALUMNOS"] = CantJunio;
                drtmp["COD MES"] = 6;
                drtmp["COD_ACTIVIDAD"] = CodActividad;
                drtmp["ACTIVIDAD"] = "TODAS";
                drtmp["MES"] = "JUNIO";
                dt.Rows.Add(drtmp);

                drtmp = dt.NewRow();
                drtmp["ALUMNOS"] = CantJulio;
                drtmp["COD MES"] = 7;
                drtmp["COD_ACTIVIDAD"] = CodActividad;
                drtmp["ACTIVIDAD"] = "TODAS";
                drtmp["MES"] = "JULIO";
                dt.Rows.Add(drtmp);

                drtmp = dt.NewRow();
                drtmp["ALUMNOS"] = CantAgosto;
                drtmp["COD MES"] = 8;
                drtmp["COD_ACTIVIDAD"] = CodActividad;
                drtmp["ACTIVIDAD"] = "TODAS";
                drtmp["MES"] = "AGOSTO";
                dt.Rows.Add(drtmp);

                drtmp = dt.NewRow();
                drtmp["ALUMNOS"] = CantSeptiembre;
                drtmp["COD MES"] = 9;
                drtmp["COD_ACTIVIDAD"] = CodActividad;
                drtmp["ACTIVIDAD"] = "TODAS";
                drtmp["MES"] = "SPETIEMBRE";
                dt.Rows.Add(drtmp);

                drtmp = dt.NewRow();
                drtmp["ALUMNOS"] = CantOctubre;
                drtmp["COD MES"] = 10;
                drtmp["COD_ACTIVIDAD"] = CodActividad;
                drtmp["ACTIVIDAD"] = "TODAS";
                drtmp["MES"] = "OCTUBRE";
                dt.Rows.Add(drtmp);

                drtmp = dt.NewRow();
                drtmp["ALUMNOS"] = CantNoviembre;
                drtmp["COD MES"] = 11;
                drtmp["COD_ACTIVIDAD"] = CodActividad;
                drtmp["ACTIVIDAD"] = "TODAS";
                drtmp["MES"] = "NOVIEMBRE";
                dt.Rows.Add(drtmp);

                drtmp = dt.NewRow();
                drtmp["ALUMNOS"] = CantDiciembre;
                drtmp["COD MES"] = 12;
                drtmp["COD_ACTIVIDAD"] = CodActividad;
                drtmp["ACTIVIDAD"] = "TODAS";
                drtmp["MES"] = "DICIEMBRE";
                dt.Rows.Add(drtmp);
            }

            DataView dv = dt.DefaultView;
            dv.Sort = "COD MES";
            DataTable sortedDT = dv.ToTable();

            return sortedDT;
        }

        public DataTable GetInformeHoras(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal,Int64 CodEmpresa)
        {
            DataTable dt = _objDALList.SelectInformeHoras(CodActividad, FechaInicial, FechaFinal,CodEmpresa);
            long SumaHoras = 0;
            foreach (DataRow dr in dt.Rows)
            {
                SumaHoras = SumaHoras + Utiles.ConvertToInt32(dr["HORAS"]);
            }
            DataRow NuevaFila;
            NuevaFila = dt.NewRow();
            NuevaFila["HORAS"] = SumaHoras;
            NuevaFila["ACTIVIDAD"] = "TODAS";
            dt.Rows.Add(NuevaFila);
            return dt;
        }

        public DataTable GetInformeEstados(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal, Int64 CodEmpresa)
        {
            DataTable dt = _objDALList.SelectInformeEstados(CodActividad, FechaInicial, FechaFinal,CodEmpresa);

            long SumNoIniciado = 0;
            long SumIniciado = 0;
            long SumAprobado = 0;
            long SumReprobado = 0;
            long SumAnulados = 0;
            foreach (DataRow dr in dt.Rows)
            {
                SumNoIniciado = SumNoIniciado + Utiles.ConvertToInt32(dr["NO INICIADO"]);
                SumIniciado = SumIniciado + Utiles.ConvertToInt32(dr["INICIADO"]);
                SumAprobado = SumAprobado + Utiles.ConvertToInt32(dr["APROBADO"]);
                SumReprobado = SumReprobado + Utiles.ConvertToInt32(dr["REPROBADO"]);
                SumAnulados = SumAnulados + Utiles.ConvertToInt32(dr["ANULADO"]);
            }
            DataRow NuevaFila;
            NuevaFila = dt.NewRow();
            NuevaFila["COD ACTIVIDAD"] = -1;
            NuevaFila["NOMBRE"] = "TODAS";
            NuevaFila["NO INICIADO"] = SumNoIniciado;
            NuevaFila["INICIADO"] = SumIniciado;
            NuevaFila["APROBADO"] = SumAprobado;
            NuevaFila["REPROBADO"] = SumReprobado;
            NuevaFila["ANULADO"] = SumAnulados;
            dt.Rows.Add(NuevaFila);
            return dt;
        }

        public DataTable GetInformeRangoNotas(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal,Int64 CodEmpresa)
        {
            DataTable dt = _objDALList.SelectInformeRangoNotas(CodActividad, FechaInicial, FechaFinal,CodEmpresa);
            return dt;
        }

        public void UpActividadUsuario(EACTIVIDADUSUARIO obj)
        {
            _objDALList.UpdateActividadUsuario(obj);
        }

        //GRAFICO NUEVO Tiempo Prom Por Actividad
        public DataTable GetTiempoPromConex(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal, Int64 CodEmpresa)
        {
            return _objDALList.GetTiempoPromConex(CodActividad, FechaInicial, FechaFinal, CodEmpresa);
        }
        //

        //GRAFICO NUEVO Tiempo Prom Por Unidad
        public DataTable GetTiempoPromConexUnidad(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal,Int64 CodEmpresa)
        {
            return _objDALList.GetTiempoPromConexUnidad(CodActividad, FechaInicial, FechaFinal, CodEmpresa);
        }
        //
        //Carga de Actividades Abiertas
        public List<EACTIVIDADCAPAC> GetActividadesAbiertas(long CodEmpresa)
        {
            return _objDALList.ActividadesAbiertas(CodEmpresa);
        }
        //
        //
        public EACTIVIDADUSUARIO GetActividadesUsuarioEncuestaAbierta(int CodActividad, int Rut, long CodEmpresa)
        {
            return _objDALList.GetActividadesUsuarioEncuestaAbierta(CodActividad, Rut, CodEmpresa);
        }
        public bool ExiteAlumnoEnActividad(int CodActividad, long RutUsuario, DateTime FechaInicio, Int64 CodEmpresa)
        {
            try
            {
                if (!_objDAL.ExisteAlumnoEnLaActividad(CodActividad, RutUsuario, FechaInicio, CodEmpresa))
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }
        public Int32 CodActividad(Int32 codActividadTutor, Int64 CodEmpresa)
        {
 
            return _objDAL.CodActividad(codActividadTutor);
        }

        public void IngresaNotaEncuesta(int coddActivUsr, double nota)
        {
            _objDAL.IngresaNotaEncuestaSatis(coddActivUsr, nota);
        }
        //
    }
}

