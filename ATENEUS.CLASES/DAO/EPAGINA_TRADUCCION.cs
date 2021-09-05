
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPAGINATRADUCCION.
    /// </summary>
    [Serializable()]
    public class EPAGINATRADUCCION : DomainObject
    {
	    	
	    private System.String  _nombre_pagina = String.Empty;
        	
	    private System.String  _descripcion = String.Empty;
        	
        
	    public EPAGINATRADUCCION() : base()
	    {
	    }
	    
		public EPAGINATRADUCCION(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String NombrePagina
	    {
		    get { return _nombre_pagina; }
		    set { _nombre_pagina = value; }
	    }
	    
	    	
	    public System.String Descripcion
	    {
		    get { return _descripcion; }
		    set { _descripcion = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLPAGINATRADUCCION();
        }

        #endregion	    
    }
}