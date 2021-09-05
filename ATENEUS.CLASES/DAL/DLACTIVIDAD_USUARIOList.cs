
using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;
//using Moebius.ErrorManagement;
//using ATENEUS.BUSINESS.Collections;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLACTIVIDADUSUARIOList.
	/// </summary>
    public class DLACTIVIDADUSUARIOList : DLGenericBaseList<EACTIVIDADUSUARIO>
	{
		public DLACTIVIDADUSUARIOList()
		{
            this._proc_select_all = "proc_select_ACTIVIDAD_USUARIO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EACTIVIDADUSUARIO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public DataTable SelectActividadesVigentes(long RutUsuario, Int16 DiasEspera)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = DiasEspera;
            prms[1].ParameterName = "@dias_espera";

           



            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_actividades_vigentes", prms);
            
            return dt;
        }

        public DataTable SelectActividadesVigentes(long RutUsuario, Int16 DiasEspera, Int64 CodEmpresa, Int32 horaZona)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = DiasEspera;
            prms[1].ParameterName = "@dias_espera";

            prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            prms[3] = db.GetParameter();
            prms[3].Value = horaZona;
            prms[3].ParameterName = "@hora_zona";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_actividades_vigentes", prms);

            return dt;
        }

        public DataTable SelectActividadesVigentes(long RutUsuario, string Email, Int16 DiasEspera)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = Email;
            prms[1].ParameterName = "@email";

            prms[2] = db.GetParameter();
            prms[2].Value = DiasEspera;
            prms[2].ParameterName = "@dias_espera";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_actividades_vigentes_2", prms);

            return dt;
        }

        public List<EACTIVIDADCAPAC> ActividadesAbiertas(long CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEmpresa;
            prms[0].ParameterName = "@CodEmpresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_actividades_abiertas", prms);

            List<EACTIVIDADCAPAC> lst = new List<EACTIVIDADCAPAC>();

            while (dr.Read())
            {
                EACTIVIDADCAPAC objACTIVIDADCAPAC = new EACTIVIDADCAPAC();

                objACTIVIDADCAPAC.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);

                objACTIVIDADCAPAC.CodTipo = Utiles.ConvertToInt16(dr["cod_tipo"]);

                objACTIVIDADCAPAC.CodProveedor = Utiles.ConvertToInt16(dr["cod_proveedor"]);

                objACTIVIDADCAPAC.Nombre = Utiles.ConvertToString(dr["nombre"]);

                objACTIVIDADCAPAC.Contenido = Utiles.ConvertToString(dr["contenido"]);

                objACTIVIDADCAPAC.Horas = Utiles.ConvertToDouble(dr["horas"]);

                objACTIVIDADCAPAC.Costo = Utiles.ConvertToDouble(dr["costo"]);

                objACTIVIDADCAPAC.Duracion = Utiles.ConvertToInt32(dr["duracion"]);

                objACTIVIDADCAPAC.CodigoSence = Utiles.ConvertToString(dr["codigo_sence"]);

                objACTIVIDADCAPAC.Objetivos = Utiles.ConvertToString(dr["objetivos"]);

                objACTIVIDADCAPAC.DestacadoHome = Utiles.ConvertToInt16(dr["destacado_home"]);

                objACTIVIDADCAPAC.Imagen = Utiles.ConvertToString(dr["imagen"]);

                objACTIVIDADCAPAC.OrdenDestacados = Utiles.ConvertToInt16(dr["orden_destacados"]);

                objACTIVIDADCAPAC.Vigente = Utiles.ConvertToBoolean(dr["Vigente"]);

                objACTIVIDADCAPAC.Mensaje = Utiles.ConvertToString(dr["Mensaje"]);

                objACTIVIDADCAPAC.NotaMinima = Utiles.ConvertToDouble(dr["nota_minima"]);

                objACTIVIDADCAPAC.PorcMinimo = Utiles.ConvertToDouble(dr["porc_minimo"]);

                objACTIVIDADCAPAC.NotaEnPorc = Utiles.ConvertToBoolean(dr["nota_en_porc"]);

                objACTIVIDADCAPAC.NotaMaxima = Utiles.ConvertToDouble(dr["nota_maxima"]);

                objACTIVIDADCAPAC.NotaAprobacion = Utiles.ConvertToDouble(dr["nota_aprobacion"]);

                objACTIVIDADCAPAC.Exigencia = Utiles.ConvertToDouble(dr["exigencia"]);

                objACTIVIDADCAPAC.Publica = Utiles.ConvertToBoolean(dr["flag_publica"]);

                objACTIVIDADCAPAC.Abierta = Utiles.ConvertToBoolean(dr["flag_abierta"]);

                objACTIVIDADCAPAC.ParaInscripcion = Utiles.ConvertToBoolean(dr["flag_para_inscripcion"]);

                objACTIVIDADCAPAC.DiasAutoIncrip = Utiles.ConvertToInt16(dr["dias_autoinscripcion"]);
                

                lst.Add(objACTIVIDADCAPAC);
            }
            dr.Close();
            return lst;

        }
        public EACTIVIDADUSUARIO GetActividadesUsuarioEncuestaAbierta(int CodActividad, int Rut, long CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = CodActividad;
            prms[1].ParameterName = "@CodActividad";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@CodEmpresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_actividad_usuario_eabierta", prms);
            EACTIVIDADUSUARIO objACTIVIDADUSUARIO = new EACTIVIDADUSUARIO();

            while (dr.Read())
            {

                //Poner las rutinas del Tools que se necesiten

                objACTIVIDADUSUARIO.CodActivUsr = Utiles.ConvertToDecimal(dr["cod_activ_usr"]);

                objACTIVIDADUSUARIO.RutUsuario = Utiles.ConvertToInt64(dr["rut_usuario"]);

                objACTIVIDADUSUARIO.CodEstado = Utiles.ConvertToInt16(dr["cod_estado"]);

                //objACTIVIDADUSUARIO.CodUnidad = "" //Utiles.ConvertToInt16(dr["cod_unidad"]);

                objACTIVIDADUSUARIO.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);

                objACTIVIDADUSUARIO.FechaInicio = Utiles.ConvertToDateTime(dr["fecha_inicio"]);

                objACTIVIDADUSUARIO.HoraInicio = Utiles.ConvertToDateTime(dr["hora_inicio"]);

                objACTIVIDADUSUARIO.FechaFin = Utiles.ConvertToDateTime(dr["fecha_fin"]);

                objACTIVIDADUSUARIO.HoraFin = Utiles.ConvertToDateTime(dr["hora_fin"]);

                objACTIVIDADUSUARIO.InicioReal = Utiles.ConvertToDateTime(dr["inicio_real"]);

                objACTIVIDADUSUARIO.HoraInicioReal = Utiles.ConvertToDateTime(dr["hora_inicio_real"]);

                objACTIVIDADUSUARIO.FinReal = Utiles.ConvertToDateTime(dr["fin_real"]);

                objACTIVIDADUSUARIO.HoraFinReal = Utiles.ConvertToDateTime(dr["hora_fin_real"]);

                objACTIVIDADUSUARIO.NotaFinal = Utiles.ConvertToDouble(dr["nota_final"]);

                //objACTIVIDADUSUARIO.PorcFinal = Utiles.ConvertToDouble(dr["porc_final"]);

                objACTIVIDADUSUARIO.NotaMinima = Utiles.ConvertToDouble(dr["nota_minima"]);

                objACTIVIDADUSUARIO.PorcMinimo = Utiles.ConvertToDouble(dr["porc_minimo"]);

                objACTIVIDADUSUARIO.Asistencia = Utiles.ConvertToDouble(dr["asistencia"]);

                objACTIVIDADUSUARIO.Comentarios = Utiles.ConvertToString(dr["comentarios"]);

                objACTIVIDADUSUARIO.EvaluacionCurso = Utiles.ConvertToDouble(dr["evaluacion_curso"]);

                objACTIVIDADUSUARIO.CostoSence = Utiles.ConvertToInt64(dr["costo_sence"]);

                objACTIVIDADUSUARIO.CostoEmpresa = Utiles.ConvertToInt64(dr["costo_empresa"]);

                objACTIVIDADUSUARIO.FlagComunicaSence = Utiles.ConvertToBoolean(dr["flag_comunica_sence"]);

                objACTIVIDADUSUARIO.FechaCertificacion = Utiles.ConvertToDateTime(dr["Fecha_certificacion"]);

                objACTIVIDADUSUARIO.MostrarCertificado = Utiles.ConvertToBoolean(dr["mostrar_certificado"]);

                objACTIVIDADUSUARIO.FlagEstadoAprobacion = Utiles.ConvertToBoolean(dr["flag_estado_aprobacion"]);

                objACTIVIDADUSUARIO.FlagEvalConHora = Utiles.ConvertToBoolean(dr["flag_eval_con_hora"]);

                objACTIVIDADUSUARIO.OrdenCompra = Utiles.ConvertToInt64(dr["orden_compra"]);

                

            }
            dr.Close();
            return objACTIVIDADUSUARIO;

        }

        public List<EACTIVIDADUSUARIO> GetActividadesAsignadas(DateTime FechaInicio, DateTime FechaFin, string listaRuts, string listaActividades,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(5);

            prms[0] = db.GetParameter();
            prms[0].Value = FechaInicio.Year.ToString() + FechaInicio.Month.ToString().PadLeft(2, '0') + FechaInicio.Day.ToString().PadLeft(2, '0');
            prms[0].ParameterName = "@FECHAINICIO";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaFin.Year.ToString() + FechaFin.Month.ToString().PadLeft(2, '0') + FechaFin.Day.ToString().PadLeft(2, '0');
            prms[1].ParameterName = "@FECHAFIN";

            prms[2] = db.GetParameter();
            prms[2].Value = listaRuts;
            prms[2].ParameterName = "@LISTRUTUSUARIOS";

            prms[3] = db.GetParameter();
            prms[3].Value = listaActividades;
            prms[3].ParameterName = "@LISTACTIVIDADES";

            prms[4] = db.GetParameter();
            prms[4].Value = CodEmpresa;
            prms[4].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_ACTIVIDADES_ASIGNADAS", prms);

            return GetCollection(dr);
        }


        public DataTable SelectHistorialUsuario(long RutUsuario,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_historial_usuario", prms);

            return dt;
        }

        public DataTable SelectActividadesBuscador(string NomActividad, Int16 Tipo, Boolean Abierta, Boolean ParaInscripcion)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(NomActividad);
            prms[0].ParameterName = "@nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = Tipo;
            prms[1].ParameterName = "@cod_tipo";

            prms[2] = db.GetParameter();
            prms[2].Value = Abierta;
            prms[2].ParameterName = "@abierta";

            prms[3] = db.GetParameter();
            prms[3].Value = ParaInscripcion;
            prms[3].ParameterName = "@inscripcion";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_buscador", prms);

            return dt;
        }


        public DataTable SelectActividadesBuscadorCursos(string NomActividad, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(NomActividad);
            prms[0].ParameterName = "@nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_buscador_cursos", prms);

            return dt;
        }
        public DataTable SelectActividadesBuscadorTutoriales(string NomActividad, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(NomActividad);
            prms[0].ParameterName = "@nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_buscador_tutoriales", prms);

            return dt;
        }
        public DataTable SelectActividadesBuscadorDoctos(string NomActividad, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(NomActividad);
            prms[0].ParameterName = "@nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_buscador_doctos", prms);

            return dt;
        }
        public DataTable SelectActividadesBuscadorVideos(string NomActividad, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(NomActividad);
            prms[0].ParameterName = "@nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_buscador_videos", prms);

            return dt;
        }
        public DataTable SelectActividadesBuscadorImagenes(string NomActividad, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(NomActividad);
            prms[0].ParameterName = "@nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_buscador_imagenes", prms);

            return dt;
        }

        public DataTable SelectReporteGeneral(Int32 CodActividad, Int64 RutUsuario, DateTime FechaInicial, DateTime FechaFinal)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@CodActividad";

            prms[1] = db.GetParameter();
            prms[1].Value = RutUsuario;
            prms[1].ParameterName = "@RutUsuario";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaInicial;
            prms[2].ParameterName = "@FechaInicial";

            prms[3] = db.GetParameter();
            prms[3].Value = FechaFinal;
            prms[3].ParameterName = "@FechaFinal";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_reporte_general", prms);

            return dt;
        }

        public DataTable SelectInformeAlumnos(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@CodActividad";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaInicial;
            prms[1].ParameterName = "@FechaInicial";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaFinal;
            prms[2].ParameterName = "@FechaFinal";

            prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_informe_cant_alumnos", prms);

            return dt;
        }

        public DataTable SelectInformeAlumnosPorMes(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@CodActividad";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaInicial;
            prms[1].ParameterName = "@FechaInicial";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaFinal;
            prms[2].ParameterName = "@FechaFinal";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_informe_cant_alumnos_por_mes", prms);

            return dt;
        }

        public DataTable SelectInformeEstados(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@CodActividad";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaInicial;
            prms[1].ParameterName = "@FechaInicial";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaFinal;
            prms[2].ParameterName = "@FechaFinal";

            prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_informe_estados_actividad", prms);

            return dt;
        }

        public DataTable SelectInformeHoras(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@CodActividad";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaInicial;
            prms[1].ParameterName = "@FechaInicial";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaFinal;
            prms[2].ParameterName = "@FechaFinal";

            prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_informe_horas_capacitacion", prms);

            return dt;
        }
        public DataTable SelectInformeRangoNotas(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@CodActividad";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaInicial;
            prms[1].ParameterName = "@FechaInicial";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaFinal;
            prms[2].ParameterName = "@FechaFinal";

            prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_informe_rango_notas", prms);

            return dt;
        }
        public bool GetPoseeTutor(long CodActivUsr)
        {
            bool blnResultado = false;
            try
            {
                DB db = DatabaseFactory.Instance.GetDatabase();
                IDbDataParameter[] prms;
                prms = db.GetArrayParameter(1);

                prms[0] = db.GetParameter();
                prms[0].Value = CodActivUsr;
                prms[0].ParameterName = "@CODACTIVUSR";

                IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_SELECT_POSEE_TUTOR", prms);

                if (Utiles.ConvertToInt16(dr[0]) > 0)
                {
                    blnResultado = true;
                }
                else
                {
                    blnResultado = false;
                }
            }
            catch(Exception ex)
            {
                blnResultado = false;
                Log log = new Log();
                log.EscribirLog(ex);
            }
            return blnResultado;
        }
        public void UpdateActividadUsuario(EACTIVIDADUSUARIO obj)
        { 
            try
            {
                DB db = DatabaseFactory.Instance.GetDatabase();
                IDbDataParameter[] prms;
                prms = db.GetArrayParameter(7);

                prms[0] = db.GetParameter();
                prms[0].Value = obj.CodActivUsr;
                prms[0].ParameterName = "@CodActivUsr";

                prms[1] = db.GetParameter();
                prms[1].Value = obj.FechaInicio;
                prms[1].ParameterName = "@FechaInicio";

                prms[2] = db.GetParameter();
                prms[2].Value = obj.FechaFin;
                prms[2].ParameterName = "@FechaFin";

                prms[3] = db.GetParameter();
                prms[3].Value = obj.HoraInicio;
                prms[3].ParameterName = "@HoraInicio";

                prms[4] = db.GetParameter();
                prms[4].Value = obj.HoraFin;
                prms[4].ParameterName = "@HoraFin";

                prms[5] = db.GetParameter();
                prms[5].Value = obj.FlagComunicaSence;
                prms[5].ParameterName = "@FlagComunicaSence";

                prms[6] = db.GetParameter();
                prms[6].Value = obj.MostrarCertificado;
                prms[6].ParameterName = "@MostrarCertificado";

                db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UP_ACTIVIDAD_USUARIO", prms);
                
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
            }
        }

        public DataTable GetTiempoPromConex(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@CodActividad";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaInicial;
            prms[1].ParameterName = "@FechaInicial";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaFinal;
            prms[2].ParameterName = "@FechaFinal";

            prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@CodEmpresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_informe_tiempo_prom_conex", prms);

            return dt;
        }

        public DataTable GetTiempoPromConexUnidad(Int32 CodActividad, DateTime FechaInicial, DateTime FechaFinal, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@CodActividad";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaInicial;
            prms[1].ParameterName = "@FechaInicial";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaFinal;
            prms[2].ParameterName = "@FechaFinal";

            prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@CodEmpresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_informe_tiempo_prom_conex_unidad", prms);

            return dt;
        }
        #endregion
    }
}
