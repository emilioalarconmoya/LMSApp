
using System;
using ATENEUS.CLASES.DAL;
using System.Collections.Generic;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPREGUNTAUNIDAD.
    /// </summary>
    [Serializable()]
    public class EPREGUNTAUNIDAD : DomainObject
    {
	    	
	    private System.Int16  _cod_unidad = 0;
        	
	    private System.Int16  _cod_pregunta = 0;
        	
	    private System.Double  _puntaje_max = 0.0;
        	
	    private System.String  _imagen = String.Empty;
        	
	    private System.String  _ancho = String.Empty;
        	
	    private System.String  _alto = String.Empty;
        	
	    private System.String  _link = String.Empty;

        private System.String _url_video = String.Empty;

        private EPREGUNTA _Pregunta = new EPREGUNTA();
        	
        
	    public EPREGUNTAUNIDAD() : base()
	    {
	    }
	    
		public EPREGUNTAUNIDAD(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodUnidad
	    {
		    get { return _cod_unidad; }
		    set { _cod_unidad = value; }
	    }
	    
	    	
	    public System.Int16 CodPregunta
	    {
		    get { return _cod_pregunta; }
		    set { _cod_pregunta = value; }
	    }
	    
	    	
	    public System.Double PuntajeMax
	    {
		    get { return _puntaje_max; }
		    set { _puntaje_max = value; }
	    }
	    
	    	
	    public System.String Imagen
	    {
		    get { return _imagen; }
		    set { _imagen = value; }
	    }
	    
	    	
	    public System.String Ancho
	    {
		    get { return _ancho; }
		    set { _ancho = value; }
	    }
	    
	    	
	    public System.String Alto
	    {
		    get { return _alto; }
		    set { _alto = value; }
	    }
	    
	    	
	    public System.String Link
	    {
		    get { return _link; }
		    set { _link = value; }
	    }

        public System.String UrlVideo
        {
            get { return _url_video; }
            set { _url_video = value; }
        }

        public EPREGUNTA Pregunta
        {
            get { return _Pregunta; }
            set { _Pregunta = value; }
        }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLPREGUNTAUNIDAD();
        }

        #endregion	    
    }
}