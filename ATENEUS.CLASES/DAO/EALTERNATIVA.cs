
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EALTERNATIVA.
    /// </summary>
    [Serializable()]
    public class EALTERNATIVA : DomainObject
    {
	    	
	    private System.Int16  _cod_alternativa = 0;
        	
	    private System.Int16  _cod_pregunta = 0;
        	
	    private System.String  _texto = String.Empty;
        	
	    private System.Boolean  _es_correcta = false;
        	
	    private System.String  _texto_comentario = String.Empty;

        private System.Double _puntaje_max = 0.0;

        
	    public EALTERNATIVA() : base()
	    {
	    }
	    
		public EALTERNATIVA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodAlternativa
	    {
		    get { return _cod_alternativa; }
		    set { _cod_alternativa = value; }
	    }
	    
	    	
	    public System.Int16 CodPregunta
	    {
		    get { return _cod_pregunta; }
		    set { _cod_pregunta = value; }
	    }
	    
	    	
	    public System.String Texto
	    {
		    get { return _texto; }
		    set { _texto = value; }
	    }
	    
	    	
	    public System.Boolean EsCorrecta
	    {
		    get { return _es_correcta; }
		    set { _es_correcta = value; }
	    }
	    
	    	
	    public System.String TextoComentario
	    {
		    get { return _texto_comentario; }
		    set { _texto_comentario = value; }
	    }

        public System.Double PuntajeMax
        {
            get { return _puntaje_max; }
            set { _puntaje_max = value; }
        }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLALTERNATIVA();
        }

        #endregion	    
    }
}