
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    /// <summary>
    /// Summary description for DLPROVEEDOR.
    /// </summary>
    public class DLREPORTES
    {
        public DLREPORTES()
		{
        }

        #region Protected Methods

        public DataTable ReporteGeneral(string CodActividad, string FechaInicial, string FechaFinal,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@CODACTIVIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaInicial;
            prms[1].ParameterName = "@FECHAINICIO";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaFinal;
            prms[2].ParameterName = "@FECHAFIN";

            prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_ESTADO_AVANCE_GENERAL", prms);

            return dt;
        }

        public DataTable ReportePersonalizado(Int16 CodPlantilla, Int32 CodActividad, string FechaInicial, string FechaFinal,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(5);

            prms[0] = db.GetParameter();
            prms[0].Value = CodPlantilla;
            prms[0].ParameterName = "@CODPLANTILLA";

            prms[1] = db.GetParameter();
            prms[1].Value = CodActividad;
            prms[1].ParameterName = "@CODACTIVIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaInicial;
            prms[2].ParameterName = "@FECHAINICIO";

            prms[3] = db.GetParameter();
            prms[3].Value = FechaFinal;
            prms[3].ParameterName = "@FECHAFIN";

            prms[4] = db.GetParameter();
            prms[4].Value = CodEmpresa;
            prms[4].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_EXEC_REPORTE_PERSONALIZADO", prms);

            return dt;
        }

        public DataTable ReporteConsolidado(DateTime FechaInicial, DateTime FechaFinal, Int32 CodActividad, Int16 CodCaracteristica, string NombreCaracteristica,Int64 CodEmpresa, Int32 CodATributo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(7);

            prms[0] = db.GetParameter();
            prms[0].Value = FechaInicial.Year.ToString() + FechaInicial.Month.ToString().PadLeft(2, '0') + FechaInicial.Day.ToString().PadLeft(2, '0');
            prms[0].ParameterName = "@FECHAINICIO";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaFinal.Year.ToString() + FechaFinal.Month.ToString().PadLeft(2, '0') + FechaFinal.Day.ToString().PadLeft(2, '0');
            prms[1].ParameterName = "@FECHAFIN";

            prms[2] = db.GetParameter();
            prms[2].Value = Utiles.ConvertToString(CodActividad);
            prms[2].ParameterName = "@CODACTIVIDAD";

            prms[3] = db.GetParameter();
            prms[3].Value = Utiles.ConvertToString(CodCaracteristica);
            prms[3].ParameterName = "@CODCARACTERISTICA";

            prms[4] = db.GetParameter();
            prms[4].Value = Utiles.ConvertToString(NombreCaracteristica);
            prms[4].ParameterName = "@NOMBRECAMPO";

            prms[5] = db.GetParameter();
            prms[5].Value = CodEmpresa;
            prms[5].ParameterName = "@cod_empresa";

            if (CodATributo == 0) { CodATributo = -1; }
            prms[6] = db.GetParameter();
            prms[6].Value = Utiles.ConvertToString(CodATributo);
            prms[6].ParameterName = "@codatributo";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_EXEC_REPORTE_CONSOLIDADO", prms);

            return dt;
        }

        public DataTable ReporteDetalleEvaluaciones(DateTime FechaInicial, DateTime FechaFinal, Int32 CodActividad, Int16 CodUnidad,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(5);

            prms[0] = db.GetParameter();
            prms[0].Value = FechaInicial.Year.ToString() + FechaInicial.Month.ToString().PadLeft(2, '0') + FechaInicial.Day.ToString().PadLeft(2, '0');
            prms[0].ParameterName = "@FECHAINICIO";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaFinal.Year.ToString() + FechaFinal.Month.ToString().PadLeft(2, '0') + FechaFinal.Day.ToString().PadLeft(2, '0');
            prms[1].ParameterName = "@FECHAFIN";

            prms[2] = db.GetParameter();
            prms[2].Value = Utiles.ConvertToString(CodActividad);
            prms[2].ParameterName = "@CODACTIVIDAD";

            prms[3] = db.GetParameter();
            prms[3].Value = CodUnidad;
            prms[3].ParameterName = "@CODUNIDAD";

            prms[4] = db.GetParameter();
            prms[4].Value = CodEmpresa;
            prms[4].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_REPORTE_DETALLE_EVALUACION", prms);

            return dt;
        }

        public DataTable ReporteConexionAlumnoSence(long rutAlumno, string fechaDesde, string fechaHasta, Int64 CodEmpresa, Int32 CodActividad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(5);

            prms[0] = db.GetParameter();
            prms[0].Value = rutAlumno;
            prms[0].ParameterName = "@RUTALUMNO";

            prms[1] = db.GetParameter();
            prms[1].Value = fechaDesde;
            prms[1].ParameterName = "@FECHAINICIO";

            prms[2] = db.GetParameter();
            prms[2].Value = fechaHasta;
            prms[2].ParameterName = "@FECHAFIN";
			
			prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@CODEMPRESA";
			
			prms[4] = db.GetParameter();
            prms[4].Value = CodActividad;
            prms[4].ParameterName = "@CODACTIVIDAD";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_CONEXION_ALUMNO_SENCE", prms);

            return dt;
        }

        public DataTable ReporteSeguimiento(string CodActividad, string FechaInicial, string FechaFinal, Int64 CodEmpresa, Int16 codCaracteristica, Int16 codAtributo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(6);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@CODACTIVIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaInicial;
            prms[1].ParameterName = "@FECHAINICIO";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaFinal;
            prms[2].ParameterName = "@FECHAFIN";
			
			prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@CODEMPRESA";
			
			prms[4] = db.GetParameter();
            prms[4].Value = codCaracteristica;
            prms[4].ParameterName = "@codcaracteristica";

            if (codAtributo == 0)
            {
                codAtributo = -1;
            }
            prms[5] = db.GetParameter();
            prms[5].Value = codAtributo;
            prms[5].ParameterName = "@codatributo";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_REPORTE_SEGUIMIENTO", prms);

            return dt;
        }

        public DataTable ReporteIndicadoresActividad(int CodActividad, DateTime FechaInicial, DateTime FechaFinal, Int16 codCaracteristica, Int16 codAtributo, long codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(6);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@COD_ACTIVIVIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaInicial;
            prms[1].ParameterName = "@FECHA_INICIO";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaFinal;
            prms[2].ParameterName = "@FECHA_FIN";

            prms[3] = db.GetParameter();
            prms[3].Value = codCaracteristica;
            prms[3].ParameterName = "@codcaracteristica";

            if (codAtributo == 0)
            {
                codAtributo = -1;
            }
            prms[4] = db.GetParameter();
            prms[4].Value = codAtributo;
            prms[4].ParameterName = "@codatributo";
			
			prms[5] = db.GetParameter();
            prms[5].Value = codEmpresa;
            prms[5].ParameterName = "@cod_empresa";


            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_INDICADORES_ACTIVIDAD", prms);

            return dt;
        }

        public DataTable ReporteEstadisticasGenerales(DateTime FechaInicial, DateTime FechaFinal, long codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = FechaInicial;
            prms[0].ParameterName = "@FECHA_INICIO";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaFinal;
            prms[1].ParameterName = "@FECHA_FIN";
			
			prms[2] = db.GetParameter();
            prms[2].Value = codEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_ESTADISTICAS_GENERALES", prms);

            return dt;
        }

        public DataTable ReporteAlumnoTutor(string CodActividadTutor, string FechaInicial, string FechaFinal, int codEstado, int estadoAprobado, long codEmpresa, long rutTutor)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(7);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividadTutor;
            prms[0].ParameterName = "@CODACTIVIDADTUTOR";

            prms[1] = db.GetParameter();
            prms[1].Value = FechaInicial;
            prms[1].ParameterName = "@FECHAINICIO";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaFinal;
            prms[2].ParameterName = "@FECHAFIN";

            prms[3] = db.GetParameter();
            prms[3].Value = codEstado;
            prms[3].ParameterName = "@CODESTADO";

            prms[4] = db.GetParameter();
            prms[4].Value = estadoAprobado;
            prms[4].ParameterName = "@EstadoAprobado";

            prms[5] = db.GetParameter();
            prms[5].Value = codEmpresa;
            prms[5].ParameterName = "@CODEMPRESA";

            prms[6] = db.GetParameter();
            prms[6].Value = rutTutor;
            prms[6].ParameterName = "@rut_tutor";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_REPORTE_ALUMNOS_TUTOR", prms);

            return dt;
        }

       

        #endregion
    }
}
