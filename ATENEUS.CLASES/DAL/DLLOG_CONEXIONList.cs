
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
	/// Summary description for DLLOGCONEXIONList.
	/// </summary>
    public class DLLOGCONEXIONList : DLGenericBaseList<ELOGCONEXION>
	{
		public DLLOGCONEXIONList()
		{
            this._proc_select_all = "proc_select_LOG_CONEXION_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ELOGCONEXION> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public DataTable SelectDatosUltimoLog(long CodActivUsr, Int32 CodUnidad,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";

            prms[1] = db.GetParameter();
            prms[1].Value = CodUnidad;
            prms[1].ParameterName = "@cod_unidad";

            prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";


            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_datos_ultimo_log_conexion", prms);

            return dt;
        }

        public Boolean LogCerrado(long CodActivUsr, Int32 CodUnidad,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";

            prms[1] = db.GetParameter();
            prms[1].Value = CodUnidad;
            prms[1].ParameterName = "@cod_unidad";

            prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_log_conexion_cerrado", prms);

            if (dt.Rows.Count > 0)
            {
                return Utiles.ConvertToBoolean(dt.Rows[0]["cerrada"]);
            }
            else
            {
                return true;
            }
        }

        public DateTime FechaUltimaVisita(long CodActivUsr, Int32 CodUnidad,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";

            prms[1] = db.GetParameter();
            prms[1].Value = CodUnidad;
            prms[1].ParameterName = "@cod_unidad";

            prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_fecha_ultima_visita", prms);

            if (dt.Rows.Count > 0)
            {
                return Utiles.ConvertToDateTime(dt.Rows[0]["fecha_inicio"]);
            }
            else
            {
                return DateTime.Now;
            }
        }

        public Int16 UltimoPasoVisitado(long CodActivUsr, Int32 CodUnidad,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";

            prms[1] = db.GetParameter();
            prms[1].Value = CodUnidad;
            prms[1].ParameterName = "@cod_unidad";

            prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_paso_ultima_unidad", prms);

            if (dt.Rows.Count > 0)
            {
                return Utiles.ConvertToInt16(dt.Rows[0]["paso"]);
            }
            else
            {
                return 0;
            }
        }

        public void AvisaTermino(long CodActivUsr, Int32 CodUnidad, DateTime FechaInicio)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";

            prms[1] = db.GetParameter();
            prms[1].Value = CodUnidad;
            prms[1].ParameterName = "@cod_unidad";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaInicio;
            prms[2].ParameterName = "@fecha_inicio";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_avisa_termino", prms);

        }

        public void AvisaTerminoSincronico(long CodActivUsr, Int32 CodUnidad, DateTime FechaInicio)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";

            prms[1] = db.GetParameter();
            prms[1].Value = CodUnidad;
            prms[1].ParameterName = "@cod_unidad";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaInicio;
            prms[2].ParameterName = "@fecha_inicio";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_avisa_termino_sincronico", prms);

        }

        public void SetPasoUltimaVisita(long CodActivUsr, Int32 CodUnidad, DateTime FechaInicio, Int16 Paso)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";

            prms[1] = db.GetParameter();
            prms[1].Value = CodUnidad;
            prms[1].ParameterName = "@cod_unidad";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaInicio;
            prms[2].ParameterName = "@fecha_inicio";

            prms[3] = db.GetParameter();
            prms[3].Value = Paso;
            prms[3].ParameterName = "@paso";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_set_paso_ultima_visita", prms);

        }

        public void SetNotaUltimaVisita(long CodActivUsr, Int32 CodUnidad, DateTime FechaInicio, double Nota)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";

            prms[1] = db.GetParameter();
            prms[1].Value = CodUnidad;
            prms[1].ParameterName = "@cod_unidad";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaInicio;
            prms[2].ParameterName = "@fecha_inicio";

            prms[3] = db.GetParameter();
            prms[3].Value = Nota;
            prms[3].ParameterName = "@nota";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_set_nota_ultima_visita", prms);

        }

		#endregion
	}
}
