
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EETIQUETA.
    /// </summary>
    [Serializable()]
    public class EETIQUETA : DomainObject
    {
	    	
	    private System.String  _nombre_pagina = String.Empty;
        	
	    private System.String  _cod_texto = String.Empty;
        	
	    private System.String  _descripcion_espanol = String.Empty;
        	
        
	    public EETIQUETA() : base()
	    {
	    }
	    
		public EETIQUETA(long id) : base(id)
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
	    
	    	
	    public System.String DescripcionEspanol
	    {
		    get { return _descripcion_espanol; }
		    set { _descripcion_espanol = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLETIQUETA();
        }

        #endregion	    
    }
}