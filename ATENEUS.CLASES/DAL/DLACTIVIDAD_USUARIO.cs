
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;


namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLACTIVIDADUSUARIO.
	/// </summary>
	public class DLACTIVIDADUSUARIO : DLBase
	{
		public DLACTIVIDADUSUARIO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ACTIVIDAD_USUARIO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ACTIVIDAD_USUARIO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ACTIVIDAD_USUARIO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ACTIVIDAD_USUARIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_activ_usr";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EACTIVIDADUSUARIO objACTIVIDADUSUARIO = obj as EACTIVIDADUSUARIO;

            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADUSUARIO.CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(31);
            EACTIVIDADUSUARIO objACTIVIDADUSUARIO = obj as EACTIVIDADUSUARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADUSUARIO.RutUsuario;
            prms[0].ParameterName = "@rut_usuario";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADUSUARIO.CodEstado;
            prms[1].ParameterName = "@cod_estado";
            	
            //prms[2] = db.GetParameter();
            //prms[2].Value = ""; //objACTIVIDADUSUARIO.CodUnidad;
            //prms[2].ParameterName = "@cod_unidad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objACTIVIDADUSUARIO.CodActividad;
            prms[2].ParameterName = "@cod_actividad";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objACTIVIDADUSUARIO.FechaInicio;
            prms[3].ParameterName = "@fecha_inicio";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objACTIVIDADUSUARIO.HoraInicio;
            prms[4].ParameterName = "@hora_inicio";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objACTIVIDADUSUARIO.FechaFin;
            prms[5].ParameterName = "@fecha_fin";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objACTIVIDADUSUARIO.HoraFin;
            prms[6].ParameterName = "@hora_fin";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objACTIVIDADUSUARIO.InicioReal;
            prms[7].ParameterName = "@inicio_real";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objACTIVIDADUSUARIO.HoraInicioReal;
            prms[8].ParameterName = "@hora_inicio_real";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objACTIVIDADUSUARIO.FinReal;
            prms[9].ParameterName = "@fin_real";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objACTIVIDADUSUARIO.HoraFinReal;
            prms[10].ParameterName = "@hora_fin_real";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objACTIVIDADUSUARIO.NotaFinal;
            prms[11].ParameterName = "@nota_final";
            	
            //prms[12] = db.GetParameter();
            //prms[12].Value = objACTIVIDADUSUARIO.PorcFinal;
            //prms[12].ParameterName = "@porc_final";
            	
            prms[12] = db.GetParameter();
            prms[12].Value = objACTIVIDADUSUARIO.NotaMinima;
            prms[12].ParameterName = "@nota_minima";
            	
            prms[13] = db.GetParameter();
            prms[13].Value = objACTIVIDADUSUARIO.PorcMinimo;
            prms[13].ParameterName = "@porc_minimo";
            	
            prms[14] = db.GetParameter();
            prms[14].Value = objACTIVIDADUSUARIO.Asistencia;
            prms[14].ParameterName = "@asistencia";
            	
            prms[15] = db.GetParameter();
            prms[15].Value = objACTIVIDADUSUARIO.Comentarios;
            prms[15].ParameterName = "@comentarios";
            	
            prms[16] = db.GetParameter();
            prms[16].Value = objACTIVIDADUSUARIO.EvaluacionCurso;
            prms[16].ParameterName = "@evaluacion_curso";
            	
            prms[17] = db.GetParameter();
            prms[17].Value = objACTIVIDADUSUARIO.CostoSence;
            prms[17].ParameterName = "@costo_sence";
            	
            prms[18] = db.GetParameter();
            prms[18].Value = objACTIVIDADUSUARIO.CostoEmpresa;
            prms[18].ParameterName = "@costo_empresa";
            	
            prms[19] = db.GetParameter();
            prms[19].Value = objACTIVIDADUSUARIO.FlagComunicaSence;
            prms[19].ParameterName = "@flag_comunica_sence";
            	
            prms[20] = db.GetParameter();
            prms[20].Value = objACTIVIDADUSUARIO.FechaCertificacion;
            prms[20].ParameterName = "@Fecha_certificacion";
            	
            prms[21] = db.GetParameter();
            prms[21].Value = objACTIVIDADUSUARIO.MostrarCertificado;
            prms[21].ParameterName = "@mostrar_certificado";
            	
            prms[22] = db.GetParameter();
            prms[22].Value = objACTIVIDADUSUARIO.FlagEstadoAprobacion;
            prms[22].ParameterName = "@flag_estado_aprobacion";
            	
            prms[23] = db.GetParameter();
            prms[23].Value = objACTIVIDADUSUARIO.FlagEvalConHora;
            prms[23].ParameterName = "@flag_eval_con_hora";
            	
            prms[24] = db.GetParameter();
            prms[24].Value = objACTIVIDADUSUARIO.OrdenCompra;
            prms[24].ParameterName = "@orden_compra";

            prms[25] = db.GetParameter();
            prms[25].Value = objACTIVIDADUSUARIO.IdRegistroSence;
            prms[25].ParameterName = "@ID_REGISTRO_SENCE";

            prms[26] = db.GetParameter();
            prms[26].Value = objACTIVIDADUSUARIO.CodEmpresa;
            prms[26].ParameterName = "@cod_empresa";

            prms[27] = db.GetParameter();
            prms[27].Value = objACTIVIDADUSUARIO.CodActividadTutor;
            prms[27].ParameterName = "@COD_ACTIVIDAD_TUTOR";

            prms[28] = db.GetParameter();
            prms[28].Value = objACTIVIDADUSUARIO.MinutosEvaluacion;
            prms[28].ParameterName = "@minutos_evaluacion";

            prms[29] = db.GetParameter();
            prms[29].Value = objACTIVIDADUSUARIO.EnviarEncuesta;
            prms[29].ParameterName = "@flag_enviar_encuesta";

            prms[30] = db.GetParameter();
            prms[30].Value = objACTIVIDADUSUARIO.CodEncuestaSatisfaccion;
            prms[30].ParameterName = "@COD_ENCUESTA_SATISFACCION";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(31);
            EACTIVIDADUSUARIO objACTIVIDADUSUARIO = obj as EACTIVIDADUSUARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADUSUARIO.CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADUSUARIO.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objACTIVIDADUSUARIO.CodEstado;
            prms[2].ParameterName = "@cod_estado";
            	
            //prms[3] = db.GetParameter();
            //prms[3].Value = ""; // objACTIVIDADUSUARIO.CodUnidad;
            //prms[3].ParameterName = "@cod_unidad";

            prms[3] = db.GetParameter();
            prms[3].Value = objACTIVIDADUSUARIO.OrdenCompra;
            prms[3].ParameterName = "@orden_compra";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objACTIVIDADUSUARIO.CodActividad;
            prms[4].ParameterName = "@cod_actividad";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objACTIVIDADUSUARIO.FechaInicio;
            prms[5].ParameterName = "@fecha_inicio";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objACTIVIDADUSUARIO.HoraInicio;
            prms[6].ParameterName = "@hora_inicio";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objACTIVIDADUSUARIO.FechaFin;
            prms[7].ParameterName = "@fecha_fin";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objACTIVIDADUSUARIO.HoraFin;
            prms[8].ParameterName = "@hora_fin";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objACTIVIDADUSUARIO.InicioReal;
            prms[9].ParameterName = "@inicio_real";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objACTIVIDADUSUARIO.HoraInicioReal;
            prms[10].ParameterName = "@hora_inicio_real";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objACTIVIDADUSUARIO.FinReal;
            prms[11].ParameterName = "@fin_real";
            	
            prms[12] = db.GetParameter();
            prms[12].Value = objACTIVIDADUSUARIO.HoraFinReal;
            prms[12].ParameterName = "@hora_fin_real";
            	
            prms[13] = db.GetParameter();
            prms[13].Value = objACTIVIDADUSUARIO.NotaFinal;
            prms[13].ParameterName = "@nota_final";
            	
            //prms[14] = db.GetParameter();
            //prms[14].Value = objACTIVIDADUSUARIO.PorcFinal;
            //prms[14].ParameterName = "@porc_final";

            prms[14] = db.GetParameter();
            prms[14].Value = objACTIVIDADUSUARIO.FlagEvalConHora;
            prms[14].ParameterName = "@flag_eval_con_hora";            	
            	
            prms[15] = db.GetParameter();
            prms[15].Value = objACTIVIDADUSUARIO.NotaMinima;
            prms[15].ParameterName = "@nota_minima";
            	
            prms[16] = db.GetParameter();
            prms[16].Value = objACTIVIDADUSUARIO.PorcMinimo;
            prms[16].ParameterName = "@porc_minimo";
            	
            prms[17] = db.GetParameter();
            prms[17].Value = objACTIVIDADUSUARIO.Asistencia;
            prms[17].ParameterName = "@asistencia";
            	
            prms[18] = db.GetParameter();
            prms[18].Value = objACTIVIDADUSUARIO.Comentarios;
            prms[18].ParameterName = "@comentarios";
            	
            prms[19] = db.GetParameter();
            prms[19].Value = objACTIVIDADUSUARIO.EvaluacionCurso;
            prms[19].ParameterName = "@evaluacion_curso";
            	
            prms[20] = db.GetParameter();
            prms[20].Value = objACTIVIDADUSUARIO.CostoSence;
            prms[20].ParameterName = "@costo_sence";
            	
            prms[21] = db.GetParameter();
            prms[21].Value = objACTIVIDADUSUARIO.CostoEmpresa;
            prms[21].ParameterName = "@costo_empresa";
            	
            prms[22] = db.GetParameter();
            prms[22].Value = objACTIVIDADUSUARIO.FlagComunicaSence;
            prms[22].ParameterName = "@flag_comunica_sence";
            	
            prms[23] = db.GetParameter();
            prms[23].Value = objACTIVIDADUSUARIO.FechaCertificacion;
            prms[23].ParameterName = "@Fecha_certificacion";
            	
            prms[24] = db.GetParameter();
            prms[24].Value = objACTIVIDADUSUARIO.MostrarCertificado;
            prms[24].ParameterName = "@mostrar_certificado";
            	
            prms[25] = db.GetParameter();
            prms[25].Value = objACTIVIDADUSUARIO.FlagEstadoAprobacion;
            prms[25].ParameterName = "@flag_estado_aprobacion";

            prms[26] = db.GetParameter();
            prms[26].Value = objACTIVIDADUSUARIO.IdRegistroSence;
            prms[26].ParameterName = "@ID_REGISTRO_SENCE";

            prms[27] = db.GetParameter();
            prms[27].Value = objACTIVIDADUSUARIO.CodActividadTutor;
            prms[27].ParameterName = "@COD_ACTIVIDAD_TUTOR";

            prms[28] = db.GetParameter();
            prms[28].Value = objACTIVIDADUSUARIO.MinutosEvaluacion;
            prms[28].ParameterName = "@minutos_evaluacion";

            prms[29] = db.GetParameter();
            prms[29].Value = objACTIVIDADUSUARIO.EnviarEncuesta;
            prms[29].ParameterName = "@flag_enviar_encuesta";

            prms[30] = db.GetParameter();
            prms[30].Value = objACTIVIDADUSUARIO.CodEncuestaSatisfaccion;
            prms[30].ParameterName = "@COD_ENCUESTA_SATISFACCION";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EACTIVIDADUSUARIO objRoot = obj as EACTIVIDADUSUARIO;

            objRoot.CodActivUsr = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EACTIVIDADUSUARIO objACTIVIDADUSUARIO = obj as EACTIVIDADUSUARIO;
    
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

            objACTIVIDADUSUARIO.PtjeTotal = Utiles.ConvertToInt16(dr["ptje_max"]);

            objACTIVIDADUSUARIO.PtjeObtenido = Utiles.ConvertToInt16(dr["ptje_obt"]);

            objACTIVIDADUSUARIO.TotalUnidades = Utiles.ConvertToInt16(dr["total_unidades"]);

            objACTIVIDADUSUARIO.UnidadesTerminadas = Utiles.ConvertToInt16(dr["unidades_terminadas"]);

            objACTIVIDADUSUARIO.IdRegistroSence = Utiles.ConvertToInt32(dr["ID_REGISTRO_SENCE"]);

            objACTIVIDADUSUARIO.CodEmpresa = Utiles.ConvertToInt64(dr["COD_EMPRESA"]);

            objACTIVIDADUSUARIO.CodActividadTutor = Utiles.ConvertToInt32(dr["cod_actividad_tutor"]);

            objACTIVIDADUSUARIO.DNI = Utiles.ConvertToString(dr["dni"]);

            objACTIVIDADUSUARIO.MinutosEvaluacion = Utiles.ConvertToInt32(dr["minutos_evaluacion"]);

            objACTIVIDADUSUARIO.EnviarEncuesta = Utiles.ConvertToBoolean(dr["flag_enviar_encuesta"]);

            objACTIVIDADUSUARIO.CodEncuestaSatisfaccion = Utiles.ConvertToInt16(dr["COD_ENCUESTA_SATISFACCION"]);



            DLACTIVIDADCAPACList objDLAC = new DLACTIVIDADCAPACList();
            objACTIVIDADUSUARIO.NombreActividad = objDLAC.GetNombreActividad(objACTIVIDADUSUARIO.CodActividad);

            DLUSUARIOList objDLUS = new DLUSUARIOList();
            objACTIVIDADUSUARIO.NombreUsuario = objDLUS.GetNombreUsuario(objACTIVIDADUSUARIO.RutUsuario);

            
        }

        //ESTA FUNCIÓN VERIFICA SI EL ALUMNO YA EXISTE EN LA ACTIVIDAD PARA NO DUPLICARLO
        public Boolean ExisteAlumnoEnLaActividad(Int32 CodActividad, long RutAlumno, DateTime FechaInicio, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = RutAlumno;
            prms[1].ParameterName = "@RUT_ALUMNO";

            prms[2] = db.GetParameter();
            prms[2].Value = FechaInicio;
            prms[2].ParameterName = "@FECHA_INICIO";

            prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@COD_EMPRESA";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_existe_en_la_misma_actividad", prms);

            if (dt.Rows.Count >0)
            {
                return Utiles.ConvertToBoolean(dt.Rows[0][0]);
            }
            else
            {
                return false;
            }
            
        }

        public Int32 CodActividad(Int32 CodActividadTutor)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividadTutor;
            prms[0].ParameterName = "@COD_ACTIVIDAD_TUTOR";

           

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_COD_ACTIVIDAD", prms);

            if (dt.Rows.Count > 0)
            {
                return Utiles.ConvertToInt32(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }

        }

        public void IngresaNotaEncuestaSatis(int codActivUsr, double nota)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = codActivUsr;
            prms[0].ParameterName = "@COD_ACTIV_USR";

            prms[1] = db.GetParameter();
            prms[1].Value = nota;
            prms[1].ParameterName = "@nota_encuesta";



            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_update_NOTA_ENCUESTA", prms);
        }

        #endregion

	}
}
