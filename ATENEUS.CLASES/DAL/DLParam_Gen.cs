
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLParamGen.
	/// </summary>
	public class DLParamGen : DLBase
	{
		public DLParamGen()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_Param_Gen";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_Param_Gen";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_Param_Gen";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_param_gen";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_caracteristica";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EParamGen objParamGen = obj as EParamGen;

            prms[0] = db.GetParameter();
            prms[0].Value = objParamGen.CodSucursal;
            prms[0].ParameterName = "@cod_caracteristica";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(36);
            EParamGen objParamGen = obj as EParamGen;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objParamGen.CodCargo;
            prms[0].ParameterName = "@cod_cargo";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objParamGen.CodSucursal;
            prms[1].ParameterName = "@cod_caracteristica";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objParamGen.TiempoMax;
            prms[2].ParameterName = "@tiempo_max";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objParamGen.DiasAvisoHome;
            prms[3].ParameterName = "@dias_aviso_home";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objParamGen.BienvenidaHome;
            prms[4].ParameterName = "@bienvenida_home";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objParamGen.ChatAbierto;
            prms[5].ParameterName = "@chat_abierto";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objParamGen.FEL;
            prms[6].ParameterName = "@FEL";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objParamGen.Version;
            prms[7].ParameterName = "@version";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objParamGen.HostConsola;
            prms[8].ParameterName = "@host_consola";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objParamGen.BdConsola;
            prms[9].ParameterName = "@bd_consola";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objParamGen.UsuarioConsola;
            prms[10].ParameterName = "@usuario_consola";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objParamGen.PassConsola;
            prms[11].ParameterName = "@pass_consola";
            	
            prms[12] = db.GetParameter();
            prms[12].Value = objParamGen.ProveedoroledbConsola;
            prms[12].ParameterName = "@proveedoroledb_consola";
            	
            prms[13] = db.GetParameter();
            prms[13].Value = objParamGen.IntentosLogueo;
            prms[13].ParameterName = "@intentos_logueo";
            	
            prms[14] = db.GetParameter();
            prms[14].Value = objParamGen.DiasIntervaloIntentos;
            prms[14].ParameterName = "@dias_intervalo_intentos";

            prms[15] = db.GetParameter();
            prms[15].Value = objParamGen.CursoAbierto;
            prms[15].ParameterName = "@FLAG_CURSOS_ABIERTOS";

            prms[16] = db.GetParameter();
            prms[16].Value = objParamGen.MostrarMalla;
            prms[16].ParameterName = "@FLAG_MOSTRAR_MALLA";

            prms[17] = db.GetParameter();
            prms[17].Value = objParamGen.CodEmpresa;
            prms[17].ParameterName = "@cod_empresa";

            prms[18] = db.GetParameter();
            prms[18].Value = objParamGen.HoraZona;
            prms[18].ParameterName = "@hora_zona";
			
			prms[19] = db.GetParameter();
            prms[19].Value = objParamGen.MostrarPuntos;
            prms[19].ParameterName = "@FLAG_MOSTRAR_PUNTOS";

			prms[20] = db.GetParameter();
            prms[20].Value = objParamGen.EmailNotificacion;
            prms[20].ParameterName = "@EMAIL_NOTIFICACION";

            prms[21] = db.GetParameter();
            prms[21].Value = objParamGen.PassEmail;
            prms[21].ParameterName = "@PASS_EMAIL";

            prms[22] = db.GetParameter();
            prms[22].Value = objParamGen.PuertoEmail;
            prms[22].ParameterName = "@PUERTO_EMAIL";

            prms[23] = db.GetParameter();
            prms[23].Value = objParamGen.HostEmail;
            prms[23].ParameterName = "@HOST_EMAIL";

            prms[24] = db.GetParameter();
            prms[24].Value = objParamGen.HabilitaAdjunto;
            prms[24].ParameterName = "@FLAG_ADJUNTO";

            prms[25] = db.GetParameter();
            prms[25].Value = objParamGen.TamanoAdjunto;
            prms[25].ParameterName = "@TAMANO_ADJUNTO";

            prms[26] = db.GetParameter();
            prms[26].Value = objParamGen.MostrarNotificacion;
            prms[26].ParameterName = "@MOSTRAR_NOTIFICACION";

            prms[26] = db.GetParameter();
            prms[26].Value = objParamGen.MostrarNotificacion;
            prms[26].ParameterName = "@MOSTRAR_NOTIFICACION";

            prms[27] = db.GetParameter();
            prms[27].Value = objParamGen.MaxEmailDia;
            prms[27].ParameterName = "@MAX_EMAIL_DIAS";

            prms[28] = db.GetParameter();
            prms[28].Value = objParamGen.MaxEmailEnvio;
            prms[28].ParameterName = "@MAX_EMAIL_ENVIO";

            prms[29] = db.GetParameter();
            prms[29].Value = objParamGen.CorreoTutor;
            prms[29].ParameterName = "@flag_correo_tutor";

            prms[30] = db.GetParameter();
            prms[30].Value = objParamGen.DescargarDiploma;
            prms[30].ParameterName = "@flag_descargar_diploma";

            prms[31] = db.GetParameter();
            prms[31].Value = objParamGen.MostrarCambioPass;
            prms[31].ParameterName = "@flag_mostrar_cambio_pass";

            prms[32] = db.GetParameter();
            prms[32].Value = objParamGen.TipoLogin;
            prms[32].ParameterName = "@tipo_login";

            prms[33] = db.GetParameter();
            prms[33].Value = objParamGen.MostrarRecuperarPass;
            prms[33].ParameterName = "@flag_recuperar_pass";

            prms[34] = db.GetParameter();
            prms[34].Value = objParamGen.MostrarPortal;
            prms[34].ParameterName = "@flag_mostrar_portal";

            prms[35] = db.GetParameter();
            prms[35].Value = objParamGen.MostrarEnviarEncuesta;
            prms[35].ParameterName = "@flag_mostrar_enviar_encuesta";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(41);
            EParamGen objParamGen = obj as EParamGen;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objParamGen.CodCargo;
            prms[0].ParameterName = "@COD_CARGO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objParamGen.CodSucursal;
            prms[1].ParameterName = "@COD_SUCURSAL";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objParamGen.TiempoMax;
            prms[2].ParameterName = "@TIEMPO_MAX";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objParamGen.DiasAvisoHome;
            prms[3].ParameterName = "@DIAS_AVISO_HOME";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objParamGen.BienvenidaHome;
            prms[4].ParameterName = "@BIENVENIDA_HOME";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objParamGen.ChatAbierto;
            prms[5].ParameterName = "@CHAT_ABIERTO";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objParamGen.FEL;
            prms[6].ParameterName = "@FEL";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objParamGen.Version;
            prms[7].ParameterName = "@VERSION";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objParamGen.HostConsola;
            prms[8].ParameterName = "@HOST_CONSOLA";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objParamGen.BdConsola;
            prms[9].ParameterName = "@BD_CONSOLA";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objParamGen.UsuarioConsola;
            prms[10].ParameterName = "@USUARIO_CONSOLA";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objParamGen.PassConsola;
            prms[11].ParameterName = "@PASS_CONSOLA";
            	
            prms[12] = db.GetParameter();
            prms[12].Value = objParamGen.ProveedoroledbConsola;
            prms[12].ParameterName = "@PROVEEDOROLEDB_CONSOLA";
            	
            prms[13] = db.GetParameter();
            prms[13].Value = objParamGen.IntentosLogueo;
            prms[13].ParameterName = "@INTENTOS_LOGUEO";
            	
            prms[14] = db.GetParameter();
            prms[14].Value = objParamGen.DiasIntervaloIntentos;
            prms[14].ParameterName = "@DIAS_INTERVALO_INTENTOS";

            prms[15] = db.GetParameter();
            prms[15].Value = objParamGen.DiasEsperaActividad;
            prms[15].ParameterName = "@DIAS_ESPERA_ACTIVIDAD";

            prms[16] = db.GetParameter();
            prms[16].Value = objParamGen.EmailMesaAyuda;
            prms[16].ParameterName = "@EMAIL_MESA_AYUDA";

            prms[17] = db.GetParameter();
            prms[17].Value = objParamGen.MostrarMenuConf;
            prms[17].ParameterName = "@MOSTRAR_MENU_CONF";

            prms[18] = db.GetParameter();
            prms[18].Value = objParamGen.SkinPlataforma;
            prms[18].ParameterName = "@SKIN_PLATAFORMA";

            prms[19] = db.GetParameter();
            prms[19].Value = objParamGen.ForoAbierto;
            prms[19].ParameterName = "@FLAG_FORO";
			
			prms[20] = db.GetParameter();
            prms[20].Value = objParamGen.CursoAbierto;
            prms[20].ParameterName = "@FLAG_CURSOS_ABIERTOS";

            prms[21] = db.GetParameter();
            prms[21].Value = objParamGen.MostrarMalla;
            prms[21].ParameterName = "@FLAG_MOSTRAR_MALLA";

            prms[22] = db.GetParameter();
            prms[22].Value = objParamGen.CodEmpresa;
            prms[22].ParameterName = "@cod_empresa";

            prms[23] = db.GetParameter();
            prms[23].Value = objParamGen.HoraZona;
            prms[23].ParameterName = "@hora_zona";
			
			prms[24] = db.GetParameter();
            prms[24].Value = objParamGen.MostrarPuntos;
            prms[24].ParameterName = "@FLAG_MOSTRAR_PUNTOS";
			
			prms[25] = db.GetParameter();
            prms[25].Value = objParamGen.EmailNotificacion;
            prms[25].ParameterName = "@EMAIL_NOTIFICACION";

            prms[26] = db.GetParameter();
            prms[26].Value = objParamGen.PassEmail;
            prms[26].ParameterName = "@PASS_EMAIL";

            prms[27] = db.GetParameter();
            prms[27].Value = objParamGen.PuertoEmail;
            prms[27].ParameterName = "@PUERTO_EMAIL";

            prms[28] = db.GetParameter();
            prms[28].Value = objParamGen.HostEmail;
            prms[28].ParameterName = "@HOST_EMAIL";

            prms[29] = db.GetParameter();
            prms[29].Value = objParamGen.HabilitaAdjunto;
            prms[29].ParameterName = "@FLAG_ADJUNTO";

            prms[30] = db.GetParameter();
            prms[30].Value = objParamGen.TamanoAdjunto;
            prms[30].ParameterName = "@TAMANO_ADJUNTO";

            prms[31] = db.GetParameter();
            prms[31].Value = objParamGen.MostrarNotificacion;
            prms[31].ParameterName = "@MOSTRAR_NOTIFICACION";

            prms[32] = db.GetParameter();
            prms[32].Value = objParamGen.MaxEmailDia;
            prms[32].ParameterName = "@MAX_EMAIL_DIAS";

            prms[33] = db.GetParameter();
            prms[33].Value = objParamGen.MaxEmailEnvio;
            prms[33].ParameterName = "@MAX_EMAIL_ENVIO";

            prms[34] = db.GetParameter();
            prms[34].Value = objParamGen.CorreoTutor;
            prms[34].ParameterName = "@flag_correo_tutor";

            prms[35] = db.GetParameter();
            prms[35].Value = objParamGen.DescargarDiploma;
            prms[35].ParameterName = "@flag_descargar_diploma";

            prms[36] = db.GetParameter();
            prms[36].Value = objParamGen.MostrarCambioPass;
            prms[36].ParameterName = "@flag_mostrar_cambio_pass";

            prms[37] = db.GetParameter();
            prms[37].Value = objParamGen.TipoLogin;
            prms[37].ParameterName = "@tipo_login";

            prms[38] = db.GetParameter();
            prms[38].Value = objParamGen.MostrarRecuperarPass;
            prms[38].ParameterName = "@flag_recuperar_pass";

            prms[39] = db.GetParameter();
            prms[39].Value = objParamGen.MostrarPortal;
            prms[39].ParameterName = "@flag_mostrar_portal";

            prms[40] = db.GetParameter();
            prms[40].Value = objParamGen.MostrarEnviarEncuesta;
            prms[40].ParameterName = "@flag_mostrar_enviar_encuesta";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EParamGen objRoot = obj as EParamGen;

            objRoot.CodSucursal = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EParamGen objParamGen = obj as EParamGen;
    
            //Poner las rutinas del Tools que se necesiten
            
            objParamGen.CodCargo = Utiles.ConvertToInt16(dr["cod_cargo"]);

            objParamGen.CodSucursal = Utiles.ConvertToInt16(dr["cod_sucursal"]);
            
            objParamGen.TiempoMax = Utiles.ConvertToInt32(dr["tiempo_max"]);
            
            objParamGen.DiasAvisoHome = Utiles.ConvertToInt16(dr["dias_aviso_home"]);
            
            objParamGen.BienvenidaHome = Utiles.ConvertToString(dr["bienvenida_home"]);
            
            objParamGen.ChatAbierto = Utiles.ConvertToBoolean(dr["chat_abierto"]);

            objParamGen.ForoAbierto = Utiles.ConvertToBoolean(dr["flag_foro"]);

            objParamGen.FEL = Utiles.ConvertToString(dr["FEL"]);
            
            objParamGen.Version = Utiles.ConvertToString(dr["version"]);
            
            objParamGen.HostConsola = Utiles.ConvertToString(dr["host_consola"]);
            
            objParamGen.BdConsola = Utiles.ConvertToString(dr["bd_consola"]);
            
            objParamGen.UsuarioConsola = Utiles.ConvertToString(dr["usuario_consola"]);
            
            objParamGen.PassConsola = Utiles.ConvertToString(dr["pass_consola"]);
            
            objParamGen.ProveedoroledbConsola = Utiles.ConvertToString(dr["proveedoroledb_consola"]);
            
            objParamGen.IntentosLogueo = Utiles.ConvertToInt32(dr["intentos_logueo"]);

            objParamGen.DiasIntervaloIntentos = Utiles.ConvertToInt32(dr["dias_intervalo_intentos"]);

            objParamGen.DiasEsperaActividad = Utiles.ConvertToInt32(dr["DIAS_ESPERA_ACTIVIDAD"]);

            objParamGen.EmailMesaAyuda = Utiles.ConvertToString(dr["EMAIL_MESA_AYUDA"]);

            objParamGen.MostrarMenuConf = Utiles.ConvertToBoolean(dr["MOSTRAR_MENU_CONF"]);

            objParamGen.SkinPlataforma = Utiles.ConvertToString(dr["SKIN_PLATAFORMA"]);

            objParamGen.CursoAbierto = Utiles.ConvertToBoolean(dr["FLAG_CURSOS_ABIERTOS"]);

            objParamGen.MostrarMalla = Utiles.ConvertToBoolean(dr["FLAG_MOSTRAR_MALLA"]);

            objParamGen.HoraZona = Utiles.ConvertToInt32(dr["HORA_ZONA_HORARIA"]);

            objParamGen.MostrarPuntos = Utiles.ConvertToBoolean(dr["FLAG_MOSTRAR_PUNTOS"]);

            objParamGen.EmailNotificacion = Utiles.ConvertToString(dr["EMAIL_NOTIFICACION"]);

            objParamGen.PassEmail = Utiles.ConvertToString(dr["PASS_EMAIL"]);

            objParamGen.PuertoEmail = Utiles.ConvertToInt32(dr["PUERTO_EMAIL"]);

            objParamGen.HostEmail = Utiles.ConvertToString(dr["HOST_EMAIL"]);

            objParamGen.HabilitaAdjunto = Utiles.ConvertToBoolean(dr["ADJUNTAR_ARCHIVO"]);

            objParamGen.TamanoAdjunto = Utiles.ConvertToInt32(dr["TAMANO_ADJUNTO"]);

            objParamGen.MostrarNotificacion = Utiles.ConvertToBoolean(dr["FLAG_MOSTRAR_NOTIFICACION"]);

            objParamGen.MaxEmailDia = Utiles.ConvertToInt32(dr["MAX_EMAIL_DIAS"]);

            objParamGen.MaxEmailEnvio = Utiles.ConvertToInt32(dr["MAX_EMAIL_ENVIO"]);

            objParamGen.CorreoTutor = Utiles.ConvertToBoolean(dr["flag_correo_tutor"]);

            objParamGen.DescargarDiploma = Utiles.ConvertToBoolean(dr["flag_descargar_diploma"]);

            objParamGen.MostrarCambioPass = Utiles.ConvertToBoolean(dr["flag_mostrar_cambio_pass"]);

            objParamGen.TipoLogin = Utiles.ConvertToInt32(dr["tipo_login"]);

            objParamGen.MostrarRecuperarPass = Utiles.ConvertToBoolean(dr["flag_recuperar_pass"]);

            objParamGen.MostrarPortal = Utiles.ConvertToBoolean(dr["flag_mostrar_portal"]);

            objParamGen.MostrarEnviarEncuesta = Utiles.ConvertToBoolean(dr["flag_mostrar_enviar_encuesta"]);
        }

        #endregion

	}
}
