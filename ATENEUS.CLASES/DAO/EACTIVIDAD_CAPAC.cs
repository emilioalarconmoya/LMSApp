
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EACTIVIDADCAPAC.
    /// </summary>
    [Serializable()]
    public class EACTIVIDADCAPAC : DomainObject
    {
	    	
	    private System.Int16  _cod_actividad = 0;

        private System.Int16 _cod_tipo = 0;
        	
	    private System.Int16  _cod_proveedor = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
	    private System.String  _contenido = String.Empty;
        	
	    private System.Double  _horas = 0.0;
        	
	    private System.Double  _costo = 0.0;
        	
	    private System.Int32  _duracion = 0;
        	
	    private System.String  _codigo_sence = String.Empty;
        	
	    private System.String  _objetivos = String.Empty;
        	
	    private System.Int16  _destacado_home = 0;
        	
	    private System.String  _imagen = String.Empty;
        	
	    private System.Int16  _orden_destacados = 0;
        	
	    private System.Boolean  _Vigente = false;
        	
	    private System.String  _Mensaje = String.Empty;
        	
	    private System.Double  _nota_minima = 0.0;
        	
	    private System.Double  _porc_minimo = 0.0;
        	
	    private System.Boolean  _nota_en_porc = false;

        private System.Double _nota_maxima = 0.0;

        private System.Double _nota_aprobacion = 0.0;

        private System.Double _exigencia = 0.0;

        private System.Boolean _publica = false;

        private System.Boolean _abierta = false;

        private System.Boolean _para_inscripcion = false;

        private System.Int16 _puntos_finalizacion = 0;

        private System.Int16 _puntos_aprobacion = 0;

        private System.Int16 _dias_expiracion_puntos = 0;

        private System.Int64 _cod_empresa = 0;

        private System.Int16 _dias_duracion_autoinscripcion = 0;

        private System.Boolean _es_conexion_nueva = false;

        private System.Int16 _cod_tipo_curso = 0;

        private System.Boolean _flag_activo_malla = false;

        private System.Int64 _rut_tutor = 0;

        private System.Boolean _flag_activo = false;

        private System.Int16 _cod_categoria = 0;

        public EACTIVIDADCAPAC() : base()
	    {
	    }
	    
		public EACTIVIDADCAPAC(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodActividad
	    {
		    get { return _cod_actividad; }
		    set { _cod_actividad = value; }
	    }

        public System.Int16 DiasAutoIncrip
        {
            get { return _dias_duracion_autoinscripcion; }
            set { _dias_duracion_autoinscripcion = value; }
        }

        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }
		
		public System.Boolean EsConexionNueva
        {
            get { return _es_conexion_nueva; }
            set { _es_conexion_nueva = value; }
        }

        public System.Int16 CodTipo
	    {
		    get { return _cod_tipo; }
		    set { _cod_tipo = value; }
	    }
	    
	    	
	    public System.Int16 CodProveedor
	    {
		    get { return _cod_proveedor; }
		    set { _cod_proveedor = value; }
	    }
	    
	    	
	    public System.String Nombre
	    {
		    get { return _nombre; }
		    set { _nombre = value; }
	    }
	    
	    	
	    public System.String Contenido
	    {
		    get { return _contenido; }
		    set { _contenido = value; }
	    }
	    
	    	
	    public System.Double Horas
	    {
		    get { return _horas; }
		    set { _horas = value; }
	    }
	    
	    	
	    public System.Double Costo
	    {
		    get { return _costo; }
		    set { _costo = value; }
	    }
	    
	    	
	    public System.Int32 Duracion
	    {
		    get { return _duracion; }
		    set { _duracion = value; }
	    }
	    
	    	
	    public System.String CodigoSence
	    {
		    get { return _codigo_sence; }
		    set { _codigo_sence = value; }
	    }
	    
	    	
	    public System.String Objetivos
	    {
		    get { return _objetivos; }
		    set { _objetivos = value; }
	    }
	    
	    	
	    public System.Int16 DestacadoHome
	    {
		    get { return _destacado_home; }
		    set { _destacado_home = value; }
	    }
	    
	    	
	    public System.String Imagen
	    {
		    get { return _imagen; }
		    set { _imagen = value; }
	    }
	    
	    	
	    public System.Int16 OrdenDestacados
	    {
		    get { return _orden_destacados; }
		    set { _orden_destacados = value; }
	    }
	    
	    	
	    public System.Boolean Vigente
	    {
		    get { return _Vigente; }
		    set { _Vigente = value; }
	    }
	    
	    	
	    public System.String Mensaje
	    {
		    get { return _Mensaje; }
		    set { _Mensaje = value; }
	    }
	    
	    	
	    public System.Double NotaMinima
	    {
		    get { return _nota_minima; }
		    set { _nota_minima = value; }
	    }
	    
	    	
	    public System.Double PorcMinimo
	    {
		    get { return _porc_minimo; }
		    set { _porc_minimo = value; }
	    }
	    
	    	
	    public System.Boolean NotaEnPorc
	    {
		    get { return _nota_en_porc; }
		    set { _nota_en_porc = value; }
        }

        public System.Double NotaMaxima
        {
            get { return _nota_maxima; }
            set { _nota_maxima = value; }
        }

        public System.Double NotaAprobacion
        {
            get { return _nota_aprobacion; }
            set { _nota_aprobacion = value; }
        }

        public System.Double Exigencia
        {
            get { return _exigencia; }
            set { _exigencia = value; }
        }

        public System.Boolean Publica
        {
            get { return _publica; }
            set { _publica = value; }
        }

        public System.Boolean Abierta
        {
            get { return _abierta; }
            set { _abierta = value; }
        }

        public System.Boolean ParaInscripcion
        {
            get { return _para_inscripcion; }
            set { _para_inscripcion = value; }
        }

        public short Puntos_finalizacion
        {
            get
            {
                return _puntos_finalizacion;
            }

            set
            {
                _puntos_finalizacion = value;
            }
        }

        public short Puntos_aprobacion
        {
            get
            {
                return _puntos_aprobacion;
            }

            set
            {
                _puntos_aprobacion = value;
            }
        }

        public short Dias_expiracion_puntos
        {
            get
            {
                return _dias_expiracion_puntos;
            }

            set
            {
                _dias_expiracion_puntos = value;
            }
        }

        public System.Int16 CodTipoCurso
        {
            get { return _cod_tipo_curso; }
            set { _cod_tipo_curso = value; }
        }

        public System.Boolean FlagParaMalla
        {
            get { return _flag_activo_malla; }
            set { _flag_activo_malla = value; }
        }

        public System.Int64 RutTutor
        {
            get { return _rut_tutor; }
            set { _rut_tutor = value; }
        }

        public System.Boolean FlagActivo
        {
            get { return _flag_activo; }
            set { _flag_activo = value; }
        }
        public System.Int16 CodCategoria
        {
            get { return _cod_categoria; }
            set { _cod_categoria = value; }
        }

        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLACTIVIDADCAPAC();
        }

        #endregion	    
    }
}