
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EUNIDAD.
    /// </summary>
    [Serializable()]
    public class EUNIDAD : DomainObject
    {
	    	
	    private System.Int16  _cod_unidad = 0;
        	
	    private System.Int16  _cod_tema_unidad = 0;

        private string _nom_tema_unidad = string.Empty;

        private System.Int16  _cod_tipo_unidad = 0;

        private string _nom_tipo_unidad = string.Empty;

        private string _nombre = string.Empty;
        	
	    private string _descripcion = string.Empty;
        	
	    private string _archivo = string.Empty;
        	
	    private System.Boolean  _avisa_termino = false;
        	
	    private string _contenido = string.Empty;
        	
	    private string _criterios = string.Empty;
        	
	    private System.Int32  _num_preg_aleatorias = 0;

        private System.Int32 _tiempo_segs = 0;

        private System.Int32 _tiempo_restante = 0;
        	
	    private System.Boolean  _Mostrar_Resultados = false;
        	
	    private System.Boolean  _mostrar_resp_correctas = false;

        private System.Int64 _rut_tutor = 0;

        private System.Boolean _flag_activo = false;
		
		private System.Int32 _pregunta_por_pagina = 0;

        private System.String _nombre_usuario = "";

        private System.String _contrasena = "";

        private System.String _url = "";

        private System.Int32 _cod_tipo_sala_virtual = 0;

        private System.Int16 _cod_tipo_encuesta = 1;

        private System.Int64 _cod_empresa = 0;

       
        public EUNIDAD() : base()
	    {
	    }
	    
		public EUNIDAD(long id) : base(id)
		{
		}
        
        #region Properties    	

        public System.Int16 CodUnidad
	    {
		    get { return _cod_unidad; }
		    set { _cod_unidad = value; }
	    }


        public System.Int16 CodTemaUnidad
	    {
		    get { return _cod_tema_unidad; }
		    set { _cod_tema_unidad = value; }
	    }
	    
	    	
	    public System.Int16 CodTipoUnidad
	    {
		    get { return _cod_tipo_unidad; }
		    set { _cod_tipo_unidad = value; }
	    }
	    
	    	
	    public string Nombre
	    {
		    get { return _nombre; }
		    set { _nombre = value; }
	    }
	    
	    	
	    public string Descripcion
	    {
		    get { return _descripcion; }
		    set { _descripcion = value; }
	    }
	    
	    	
	    public string Archivo
	    {
		    get { return _archivo; }
		    set { _archivo = value; }
	    }
	    
	    	
	    public System.Boolean AvisaTermino
	    {
		    get { return _avisa_termino; }
		    set { _avisa_termino = value; }
	    }
	    
	    	
	    public string Contenido
	    {
		    get { return _contenido; }
		    set { _contenido = value; }
	    }
	    
	    	
	    public string Criterios
	    {
		    get { return _criterios; }
		    set { _criterios = value; }
	    }
	    
	    	
	    public System.Int32 NumPregAleatorias
	    {
		    get { return _num_preg_aleatorias; }
		    set { _num_preg_aleatorias = value; }
	    }
	    
	    	
	    public System.Int32 TiempoSegs
	    {
		    get { return _tiempo_segs; }
		    set { _tiempo_segs = value; }
	    }

        public System.Int32 TiempoRestante
        {
            get { return _tiempo_restante; }
            set { _tiempo_restante = value; }
        }
	    
	    	
	    public System.Boolean MostrarResultados
	    {
		    get { return _Mostrar_Resultados; }
		    set { _Mostrar_Resultados = value; }
	    }
	    
	    	
	    public System.Boolean MostrarRespCorrectas
	    {
		    get { return _mostrar_resp_correctas; }
		    set { _mostrar_resp_correctas = value; }
	    }

        public string NomTemaUnidad
        {
            get {  return _nom_tema_unidad; }
            set { _nom_tema_unidad = value; }
        }

        public string NomTipoUnidad
        {
            get { return _nom_tipo_unidad; }
            set { _nom_tipo_unidad = value; }
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
		
		public System.Int32 PreguntaPorPagina
        {
            get { return _pregunta_por_pagina; }
            set { _pregunta_por_pagina = value; }
        }

        public System.String NombreUsuario
        {
            get { return _nombre_usuario; }
            set { _nombre_usuario = value; }
        }

        public System.String Contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        public System.String URL
        {
            get { return _url; }
            set { _url = value; }
        }

        public System.Int32 CodTipoSalaVirtual
        {
            get { return _cod_tipo_sala_virtual; }
            set { _cod_tipo_sala_virtual = value; }
        }

        public System.Int16 CodTipoEncuesta
        {
            get { return _cod_tipo_encuesta; }
            set { _cod_tipo_encuesta = value; }
        }

        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }

        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLUNIDAD();
        }

        #endregion	    
    }
}