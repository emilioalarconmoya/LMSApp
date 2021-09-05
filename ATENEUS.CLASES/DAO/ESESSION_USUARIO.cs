
using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    public class ESESSIONUSUARIO : DomainObject
    {

        private System.Int64 _rut_usuario = 0;

        private System.String _nombres = String.Empty;

        private System.String _apellidos = String.Empty;

        private System.String _email = String.Empty;

        private System.String _clave_sence = String.Empty;

        private System.String _profesion = String.Empty;

        private System.String _direccion = String.Empty;

        private System.String _comuna = String.Empty;

        private System.Boolean _EsAdministrador = false;

        private System.Boolean _EsGestion = false;

        private System.Boolean _EsTutor = false;

        private System.Boolean _EsSuperusuario = false;

        private System.Boolean _EsAlumno = false;

        private System.Boolean _mostrar_menu_conf = false;

        private System.String _skin_plataforma = String.Empty;

        private System.Int16 _dias_espera_actividad = 0;

        private System.Boolean _chat_habilitad = false;

        private System.Boolean _foro_habilitad = false;

        private System.String _version_plataforma = String.Empty;

        private System.String _email_mesa_ayuda = String.Empty;

        private System.String _modo_ingreso = String.Empty;
		
		private System.Boolean _curso_abierto = false;
		
		 private System.Boolean _mostrar_malla = false;  

        private System.Int64 _cod_empresa = 0;

        private System.Int32 _hora_zona = 0;

        private System.Boolean _mostrar_puntos = false;

        private System.Boolean _flag_mostrar_cambio_pass = false;

        private System.String _pass = String.Empty;

        private System.Int32 _tipo_login = 1;

        private System.Boolean _flag_mostrar_portal = false;

        public ESESSIONUSUARIO()
            : base()
	    {
	    }

        public ESESSIONUSUARIO(long id)
            : base(id)
		{
		}

        #region Properties
        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }

        public System.Int64 RutUsuario
        {
            get { return _rut_usuario; }
            set { _rut_usuario = value; }
        }
        
        public System.String Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }
        
        public System.String Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }
        
        public System.String Email
        {
            get { return _email; }
            set { _email = value; }
        }
        
        public System.String ClaveSence
        {
            get { return _clave_sence; }
            set { _clave_sence = value; }
        }
        
        public System.String Profesion
        {
            get { return _profesion; }
            set { _profesion = value; }
        }
        
        public System.String Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        
        public System.String Comuna
        {
            get { return _comuna; }
            set { _comuna = value; }
        }

        public System.Boolean EsAdministrador
        {
            get { return _EsAdministrador; }
            set { _EsAdministrador = value; }
        }

        public System.Boolean EsGestion
        {
            get { return _EsGestion; }
            set { _EsGestion = value; }
        }

        public System.Boolean EsTutor
        {
            get { return _EsTutor; }
            set { _EsTutor = value; }
        }

        public System.Boolean EsSuperusuario
        {
            get { return _EsSuperusuario; }
            set { _EsSuperusuario = value; }
        }

        public System.Boolean EsAlumno
        {
            get { return _EsAlumno; }
            set { _EsAlumno = value; }
        }


        public System.String EmailMesaAyuda
        {
            get { return _email_mesa_ayuda; }
            set { _email_mesa_ayuda = value; }
        }

        public System.String VersionPlataforma
        {
            get { return _version_plataforma; }
            set { _version_plataforma = value; }
        }

        public System.Boolean ChatHabilitad
        {
            get { return _chat_habilitad; }
            set { _chat_habilitad = value; }
        }

        public System.Boolean ForoHabilitad
        {
            get { return _foro_habilitad; }
            set { _foro_habilitad = value; }
        }

        public System.Int16 DiasEsperaActividad
        {
            get { return _dias_espera_actividad; }
            set { _dias_espera_actividad = value; }
        }

        public System.String SkinPlataforma
        {
            get { return _skin_plataforma; }
            set { _skin_plataforma = value; }
        }

        public System.Boolean MostrarMenuConf
        {
            get { return _mostrar_menu_conf; }
            set { _mostrar_menu_conf = value; }
        }

        public System.String ModoIngreso
        {
            get { return _modo_ingreso; }
            set { _modo_ingreso = value; }
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

        public System.Boolean MostrarCambioPass
        {
            get { return _flag_mostrar_cambio_pass; }
            set { _flag_mostrar_cambio_pass = value; }
        }

        public System.String Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        public System.Int32 TipoLogin
        {
            get { return _tipo_login; }
            set { _tipo_login = value; }
        }

        public System.Boolean MostrarPortal
        {
            get { return _flag_mostrar_portal; }
            set { _flag_mostrar_portal = value; }
        }
        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLSESSIONUSUARIO();
        }

        #endregion	    

    }
}
