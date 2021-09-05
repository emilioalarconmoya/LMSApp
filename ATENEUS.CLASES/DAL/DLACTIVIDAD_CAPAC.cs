
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLACTIVIDADCAPAC.
	/// </summary>
	public class DLACTIVIDADCAPAC : DLBase
	{
		public DLACTIVIDADCAPAC()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ACTIVIDAD_CAPAC";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ACTIVIDAD_CAPAC";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ACTIVIDAD_CAPAC";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ACTIVIDAD_CAPAC";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_actividad";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EACTIVIDADCAPAC objACTIVIDADCAPAC = obj as EACTIVIDADCAPAC;

            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADCAPAC.CodActividad;
            prms[0].ParameterName = "@cod_actividad";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(33);
            EACTIVIDADCAPAC objACTIVIDADCAPAC = obj as EACTIVIDADCAPAC;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADCAPAC.CodActividad; //Serial();
            prms[0].ParameterName = "@COD_ACTIVIDAD";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADCAPAC.CodTipo;
            prms[1].ParameterName = "@cod_tipo";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objACTIVIDADCAPAC.CodProveedor;
            prms[2].ParameterName = "@cod_proveedor";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objACTIVIDADCAPAC.Nombre;
            prms[3].ParameterName = "@nombre";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objACTIVIDADCAPAC.Contenido;
            prms[4].ParameterName = "@contenido";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objACTIVIDADCAPAC.Horas;
            prms[5].ParameterName = "@horas";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objACTIVIDADCAPAC.Costo;
            prms[6].ParameterName = "@costo";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objACTIVIDADCAPAC.Duracion;
            prms[7].ParameterName = "@duracion";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objACTIVIDADCAPAC.CodigoSence;
            prms[8].ParameterName = "@codigo_sence";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objACTIVIDADCAPAC.Objetivos;
            prms[9].ParameterName = "@objetivos";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objACTIVIDADCAPAC.DestacadoHome;
            prms[10].ParameterName = "@destacado_home";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objACTIVIDADCAPAC.Imagen;
            prms[11].ParameterName = "@imagen";
            	
            prms[12] = db.GetParameter();
            prms[12].Value = objACTIVIDADCAPAC.OrdenDestacados;
            prms[12].ParameterName = "@orden_destacados";
            	
            prms[13] = db.GetParameter();
            prms[13].Value = objACTIVIDADCAPAC.Vigente;
            prms[13].ParameterName = "@Vigente";
            	
            prms[14] = db.GetParameter();
            prms[14].Value = objACTIVIDADCAPAC.Mensaje;
            prms[14].ParameterName = "@Mensaje";
            	
            prms[15] = db.GetParameter();
            prms[15].Value = objACTIVIDADCAPAC.NotaMinima;
            prms[15].ParameterName = "@nota_minima";
            	
            prms[16] = db.GetParameter();
            prms[16].Value = objACTIVIDADCAPAC.PorcMinimo;
            prms[16].ParameterName = "@porc_minimo";
            	
            prms[17] = db.GetParameter();
            prms[17].Value = objACTIVIDADCAPAC.NotaEnPorc;
            prms[17].ParameterName = "@nota_en_porc";

            prms[18] = db.GetParameter();
            prms[18].Value = objACTIVIDADCAPAC.NotaMaxima;
            prms[18].ParameterName = "@nota_maxima";

            prms[19] = db.GetParameter();
            prms[19].Value = objACTIVIDADCAPAC.NotaAprobacion;
            prms[19].ParameterName = "@nota_aprobacion";

            prms[20] = db.GetParameter();
            prms[20].Value = objACTIVIDADCAPAC.Exigencia;
            prms[20].ParameterName = "@exigencia";

            prms[21] = db.GetParameter();
            prms[21].Value = objACTIVIDADCAPAC.Publica;
            prms[21].ParameterName = "@flag_publica";

            prms[22] = db.GetParameter();
            prms[22].Value = objACTIVIDADCAPAC.Abierta;
            prms[22].ParameterName = "@flag_abierta";

            prms[23] = db.GetParameter();
            prms[23].Value = objACTIVIDADCAPAC.ParaInscripcion;
            prms[23].ParameterName = "@flag_para_inscripcion";

            prms[24] = db.GetParameter();
            prms[24].Value = objACTIVIDADCAPAC.Puntos_finalizacion;
            prms[24].ParameterName = "@puntos_finalizacion";

            prms[25] = db.GetParameter();
            prms[25].Value = objACTIVIDADCAPAC.Puntos_aprobacion;
            prms[25].ParameterName = "@puntos_aprobacion";

            prms[26] = db.GetParameter();
            prms[26].Value = objACTIVIDADCAPAC.Dias_expiracion_puntos;
            prms[26].ParameterName = "@dias_expiracion_puntos";
			
			prms[27] = db.GetParameter();
            prms[27].Value = objACTIVIDADCAPAC.DiasAutoIncrip;
            prms[27].ParameterName = "@dias_autoinscripcion";

            prms[28] = db.GetParameter();
            prms[28].Value = objACTIVIDADCAPAC.CodEmpresa; //Serial();
            prms[28].ParameterName = "@cod_empresa";
			
			prms[29] = db.GetParameter();
            prms[29].Value = objACTIVIDADCAPAC.EsConexionNueva;
            prms[29].ParameterName = "@FLAG_ES_NUEVA_CONEXION";


            prms[30] = db.GetParameter();
            prms[30].Value = objACTIVIDADCAPAC.RutTutor;
            prms[30].ParameterName = "@rut_tutor";

			prms[31] = db.GetParameter();
            prms[31].Value = objACTIVIDADCAPAC.FlagActivo;
            prms[31].ParameterName = "@flag_Activo";

            prms[32] = db.GetParameter();
            prms[32].Value = objACTIVIDADCAPAC.CodCategoria;
            prms[32].ParameterName = "@cod_categoria";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(33);
            EACTIVIDADCAPAC objACTIVIDADCAPAC = obj as EACTIVIDADCAPAC;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADCAPAC.CodActividad;
            prms[0].ParameterName = "@cod_actividad";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADCAPAC.CodTipo;
            prms[1].ParameterName = "@cod_tipo";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objACTIVIDADCAPAC.CodProveedor;
            prms[2].ParameterName = "@cod_proveedor";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objACTIVIDADCAPAC.Nombre;
            prms[3].ParameterName = "@nombre";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objACTIVIDADCAPAC.Contenido;
            prms[4].ParameterName = "@contenido";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objACTIVIDADCAPAC.Horas;
            prms[5].ParameterName = "@horas";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objACTIVIDADCAPAC.Costo;
            prms[6].ParameterName = "@costo";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objACTIVIDADCAPAC.Duracion;
            prms[7].ParameterName = "@duracion";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objACTIVIDADCAPAC.CodigoSence;
            prms[8].ParameterName = "@codigo_sence";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objACTIVIDADCAPAC.Objetivos;
            prms[9].ParameterName = "@objetivos";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objACTIVIDADCAPAC.DestacadoHome;
            prms[10].ParameterName = "@destacado_home";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objACTIVIDADCAPAC.Imagen;
            prms[11].ParameterName = "@imagen";
            	
            prms[12] = db.GetParameter();
            prms[12].Value = objACTIVIDADCAPAC.OrdenDestacados;
            prms[12].ParameterName = "@orden_destacados";
            	
            prms[13] = db.GetParameter();
            prms[13].Value = objACTIVIDADCAPAC.Vigente;
            prms[13].ParameterName = "@Vigente";
            	
            prms[14] = db.GetParameter();
            prms[14].Value = objACTIVIDADCAPAC.Mensaje;
            prms[14].ParameterName = "@Mensaje";
            	
            prms[15] = db.GetParameter();
            prms[15].Value = objACTIVIDADCAPAC.NotaMinima;
            prms[15].ParameterName = "@nota_minima";
            	
            prms[16] = db.GetParameter();
            prms[16].Value = objACTIVIDADCAPAC.PorcMinimo;
            prms[16].ParameterName = "@porc_minimo";
            	
            prms[17] = db.GetParameter();
            prms[17].Value = objACTIVIDADCAPAC.NotaEnPorc;
            prms[17].ParameterName = "@nota_en_porc";

            prms[18] = db.GetParameter();
            prms[18].Value = objACTIVIDADCAPAC.NotaMaxima;
            prms[18].ParameterName = "@nota_maxima";

            prms[19] = db.GetParameter();
            prms[19].Value = objACTIVIDADCAPAC.NotaAprobacion;
            prms[19].ParameterName = "@nota_aprobacion";

            prms[20] = db.GetParameter();
            prms[20].Value = objACTIVIDADCAPAC.Exigencia;
            prms[20].ParameterName = "@exigencia";

            prms[21] = db.GetParameter();
            prms[21].Value = objACTIVIDADCAPAC.Publica;
            prms[21].ParameterName = "@flag_publica";

            prms[22] = db.GetParameter();
            prms[22].Value = objACTIVIDADCAPAC.Abierta;
            prms[22].ParameterName = "@flag_abierta";

            prms[23] = db.GetParameter();
            prms[23].Value = objACTIVIDADCAPAC.ParaInscripcion;
            prms[23].ParameterName = "@flag_para_inscripcion";

            prms[24] = db.GetParameter();
            prms[24].Value = objACTIVIDADCAPAC.Puntos_finalizacion;
            prms[24].ParameterName = "@puntos_finalizacion";

            prms[25] = db.GetParameter();
            prms[25].Value = objACTIVIDADCAPAC.Puntos_aprobacion;
            prms[25].ParameterName = "@puntos_aprobacion";

            prms[26] = db.GetParameter();
            prms[26].Value = objACTIVIDADCAPAC.Dias_expiracion_puntos;
            prms[26].ParameterName = "@dias_expiracion_puntos";
			
			prms[27] = db.GetParameter();
            prms[27].Value = objACTIVIDADCAPAC.DiasAutoIncrip;
            prms[27].ParameterName = "@dias_autoinscripcion";

            prms[28] = db.GetParameter();
            prms[28].Value = objACTIVIDADCAPAC.CodEmpresa;
            prms[28].ParameterName = "@cod_empresa";
			
			prms[29] = db.GetParameter();
            prms[29].Value = objACTIVIDADCAPAC.EsConexionNueva;
            prms[29].ParameterName = "@FLAG_ES_NUEVA_CONEXION";

			prms[30] = db.GetParameter();
            prms[30].Value = objACTIVIDADCAPAC.RutTutor;
            prms[30].ParameterName = "@rut_tutor";
			
			prms[31] = db.GetParameter();
            prms[31].Value = objACTIVIDADCAPAC.FlagActivo;
            prms[31].ParameterName = "@flag_Activo";

            prms[32] = db.GetParameter();
            prms[32].Value = objACTIVIDADCAPAC.CodCategoria;
            prms[32].ParameterName = "@cod_categoria";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EACTIVIDADCAPAC objRoot = obj as EACTIVIDADCAPAC;

            objRoot.CodActividad = Utiles.ConvertToInt16(id);
        }

        public Int16 Serial()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();            
            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_serial_actividad");
            return Utiles.ConvertToInt16(dt.Rows[0][0]);
        }

        public void ActualizaEstadoActividad(long CodActividad, Boolean flagActivo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = flagActivo;
            prms[1].ParameterName = "@flag_activo";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_update_ESTADO_ACTIVIDAD_FLAG_ACTIVO", prms);


        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            EACTIVIDADCAPAC objACTIVIDADCAPAC = obj as EACTIVIDADCAPAC;
    
            //Poner las rutinas del Tools que se necesiten
            
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

            objACTIVIDADCAPAC.Puntos_finalizacion = Utiles.ConvertToInt16(dr["puntaje_curso"]);

            objACTIVIDADCAPAC.Puntos_aprobacion = Utiles.ConvertToInt16(dr["puntaje_aprobacion"]);

            objACTIVIDADCAPAC.Dias_expiracion_puntos = Utiles.ConvertToInt16(dr["dias_expiracion_puntos"]);

            objACTIVIDADCAPAC.DiasAutoIncrip = Utiles.ConvertToInt16(dr["dias_autoinscripcion"]);

            objACTIVIDADCAPAC.EsConexionNueva = Utiles.ConvertToBoolean(dr["FLAG_ES_NUEVA_CONEXION"]);

			objACTIVIDADCAPAC.RutTutor = Utiles.ConvertToInt32(dr["rut_tutor"]);
			
			objACTIVIDADCAPAC.FlagActivo = Utiles.ConvertToBoolean(dr["flag_activo"]);

            objACTIVIDADCAPAC.CodCategoria = Utiles.ConvertToInt16(dr["cod_categoria"]);
        }

         public Boolean ExisteActividad(long CodActividad)
         {
             DB db = DatabaseFactory.Instance.GetDatabase();
             IDbDataParameter[] prms;
             prms = db.GetArrayParameter(1);

             prms[0] = db.GetParameter();
             prms[0].Value = CodActividad;
             prms[0].ParameterName = "@cod_actividad";

             DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_existe_actividad", prms);

             return Utiles.ConvertToBoolean(dt.Rows[0][0]);
         }
        #endregion

	}
}
