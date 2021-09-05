
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EParamGen.
    /// </summary>
    [Serializable()]
    public class EParamGen : DomainObject
    {
	    	
	    private System.Int16  _cod_cargo = 0;
        	
	    private System.Int16  _cod_sucursal = 0;
        	
	    private System.Int32  _tiempo_max = 0;
        	
	    private System.Int16  _dias_aviso_home = 0;
        	
	    private System.String  _bienvenida_home = String.Empty;
        	
	    private System.Boolean  _chat_abierto = false;

        private System.Boolean _foro_abierto = false;

        private System.String  _FEL = String.Empty;
        	
	    private System.String  _version = String.Empty;
        	
	    private System.String  _host_consola = String.Empty;
        	
	    private System.String  _bd_consola = String.Empty;
        	
	    private System.String  _usuario_consola = String.Empty;
        	
	    private System.String  _pass_consola = String.Empty;
        	
	    private System.String  _proveedoroledb_consola = String.Empty;
        	
	    private System.Int32  _intentos_logueo = 0;

        private System.Int32 _dias_intervalo_intentos = 0;

        private System.Int32 _dias_espera_actividad = 0;

        private System.String _email_mesa_ayuda = String.Empty;

        private System.Boolean _mostrar_menu_conf = false;

        private System.String _skin_plataforma = String.Empty;
		
		private System.Boolean _curso_abierto = false;
		
		private System.Boolean _mostrar_malla = false;

        private System.Int64 _cod_empresa = 0;

        private System.Int32 _hora_zona = 0;

		private System.Boolean _mostrar_puntos = false;

		private System.String _email_notificacion = String.Empty; //notificacion

        private System.String _pass_email = String.Empty;  //notificacion

        private System.Int32 _puerto_email = 0; //notificacion

        private System.String _host_email = String.Empty; //notificacion

        private System.Boolean _habilita_adjunto = false;  //notificacion

        private System.Int32 _tanano_adjunto = 0; //notificacion

        private System.Boolean _mostrar_notificacion = false;

        private System.Int32 _max_email_dia = 0; //notificacion - cantidad maximia para enviar por día

        private System.Int32 _max_email_envio = 0; //notificacion - cantidad maxima de envio por bloque

        private System.Boolean _correo_tutor = false; //es para enviar correo al tutor desde los comentarios

        private System.Boolean _descargar_diploma = false; //es para mostar en menú de getión el reporte de descarga de certificados

        private System.Boolean _flag_mostrar_cambio_pass = false;

        private System.Int32 _tipo_login = 1;

        private System.Boolean _flag_mostrar_recuperar_pass = false;

        private System.Boolean _flag_mostrar_portal = false;

        private System.Boolean flag_mostrar_enviar_encuesta = false;


        public EParamGen() : base()
	    {
	    }
	    
		public EParamGen(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodCargo
	    {
		    get { return _cod_cargo; }
            set { _cod_cargo = value; }
	    }
        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }


        public System.Int16 CodSucursal
	    {
            get { return _cod_sucursal; }
            set { _cod_sucursal = value; }
	    }
	    
	    	
	    public System.Int32 TiempoMax
	    {
		    get { return _tiempo_max; }
		    set { _tiempo_max = value; }
	    }
	    
	    	
	    public System.Int16 DiasAvisoHome
	    {
		    get { return _dias_aviso_home; }
		    set { _dias_aviso_home = value; }
	    }
	    
	    	
	    public System.String BienvenidaHome
	    {
		    get { return _bienvenida_home; }
		    set { _bienvenida_home = value; }
	    }
	    
	    	
	    public System.Boolean ChatAbierto
	    {
		    get { return _chat_abierto; }
		    set { _chat_abierto = value; }
        }


        public System.Boolean ForoAbierto
        {
            get { return _foro_abierto; }
            set { _foro_abierto = value; }
        }


        public System.String FEL
	    {
		    get { return _FEL; }
		    set { _FEL = value; }
	    }
	    
	    	
	    public System.String Version
	    {
		    get { return _version; }
		    set { _version = value; }
	    }
	    
	    	
	    public System.String HostConsola
	    {
		    get { return _host_consola; }
		    set { _host_consola = value; }
	    }
	    
	    	
	    public System.String BdConsola
	    {
		    get { return _bd_consola; }
		    set { _bd_consola = value; }
	    }
	    
	    	
	    public System.String UsuarioConsola
	    {
		    get { return _usuario_consola; }
		    set { _usuario_consola = value; }
	    }
	    
	    	
	    public System.String PassConsola
	    {
		    get { return _pass_consola; }
		    set { _pass_consola = value; }
	    }
	    
	    	
	    public System.String ProveedoroledbConsola
	    {
		    get { return _proveedoroledb_consola; }
		    set { _proveedoroledb_consola = value; }
	    }
	    
	    	
	    public System.Int32 IntentosLogueo
	    {
		    get { return _intentos_logueo; }
		    set { _intentos_logueo = value; }
	    }
	    
	    	
	    public System.Int32 DiasIntervaloIntentos
	    {
		    get { return _dias_intervalo_intentos; }
		    set { _dias_intervalo_intentos = value; }
	    }

        public System.Int32 DiasEsperaActividad
        {
            get { return _dias_espera_actividad; }
            set { _dias_espera_actividad = value; }
        }

        public System.String EmailMesaAyuda
        {
            get { return _email_mesa_ayuda; }
            set { _email_mesa_ayuda = value; }
        }

        public System.Boolean MostrarMenuConf
        {
            get { return _mostrar_menu_conf; }
            set { _mostrar_menu_conf = value; }
        }

        public System.String SkinPlataforma
        {
            get { return _skin_plataforma; }
            set { _skin_plataforma = value; }
        }

        public System.Boolean CursoAbierto
        {
            get { return _curso_abierto; }
            set { _curso_abierto = value; }
        }

        public System.Boolean MostrarMalla
        {
            get { return _mostrar_malla; }
            set { _mostrar_malla = value; }
        }

        public System.Int32 HoraZona
        {
            get { return _hora_zona; }
            set { _hora_zona = value; }
        }

        public System.Boolean MostrarPuntos
        {
            get { return _mostrar_puntos; }
            set { _mostrar_puntos = value; }
        }

        public System.String EmailNotificacion
        {
            get { return _email_notificacion; }
            set { _email_notificacion = value; }
        }

        public System.String PassEmail
        {
            get { return _pass_email; }
            set { _pass_email = value; }
        }

        public System.Int32 PuertoEmail
        {
            get { return _puerto_email; }
            set { _puerto_email = value; }
        }

        public System.String HostEmail
        {
            get { return _host_email; }
            set { _host_email = value; }
        }

        public System.Boolean HabilitaAdjunto
        {
            get { return _habilita_adjunto; }
            set { _habilita_adjunto = value; }
        }


        public System.Int32 TamanoAdjunto
        {
            get { return _tanano_adjunto; }
            set { _tanano_adjunto = value; }
        }

        public System.Boolean MostrarNotificacion
        {
            get { return _mostrar_notificacion; }
            set { _mostrar_notificacion = value; }
        }

        public System.Int32 MaxEmailDia
        {
            get { return _max_email_dia; }
            set { _max_email_dia = value; }
        }

        public System.Int32 MaxEmailEnvio
        {
            get { return _max_email_envio; }
            set { _max_email_envio = value; }
        }

        public System.Boolean CorreoTutor
        {
            get { return _correo_tutor; }
            set { _correo_tutor = value; }
        }

        public System.Boolean DescargarDiploma
        {
            get { return _descargar_diploma; }
            set { _descargar_diploma = value; }
        }

        public System.Boolean MostrarCambioPass
        {
            get { return _flag_mostrar_cambio_pass; }
            set { _flag_mostrar_cambio_pass = value; }
        }

        public System.Int32 TipoLogin
        {
            get { return _tipo_login; }
            set { _tipo_login = value; }
        }

        public System.Boolean MostrarRecuperarPass
        {
            get { return _flag_mostrar_recuperar_pass; }
            set { _flag_mostrar_recuperar_pass = value; }
        }

        public System.Boolean MostrarPortal
        {
            get { return _flag_mostrar_portal; }
            set { _flag_mostrar_portal = value; }
        }

        public System.Boolean MostrarEnviarEncuesta
        {
            get { return flag_mostrar_enviar_encuesta; }
            set { flag_mostrar_enviar_encuesta = value; }
        }
        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLParamGen();
        }

        #endregion	    
    }
}