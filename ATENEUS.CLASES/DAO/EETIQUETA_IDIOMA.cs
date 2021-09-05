
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EETIQUETAIDIOMA.
    /// </summary>
    [Serializable()]
    public class EETIQUETAIDIOMA : DomainObject
    {
	    	
	    private System.String  _nombre_pagina = String.Empty;
        	
	    private System.String  _cod_texto = String.Empty;
        	
	    private System.Int16  _cod_idioma = 0;
        	
	    private System.String  _texto = String.Empty;
        	
        
	    public EETIQUETAIDIOMA() : base()
	    {
	    }
	    
		public EETIQUETAIDIOMA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String NombrePagina
	    {
		    get { return _nombre_pagina; }
		    set { _nombre_pagina = value; }
	    }
	    
	    	
	    public System.String CodTexto
	    {
		    get { return _cod_texto; }
		    set { _cod_texto = value; }
	    }
	    
	    	
	    public System.Int16 CodIdioma
	    {
		    get { return _cod_idioma; }
		    set { _cod_idioma = value; }
	    }
	    
	    	
	    public System.String Texto
	    {
		    get { return _texto; }
		    set { _texto = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLETIQUETAIDIOMA();
        }

        #endregion	    
    }
}