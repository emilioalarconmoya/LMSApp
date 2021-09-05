
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ESESION.
    /// </summary>
    [Serializable()]
    public class ESESION : DomainObject
    {
	    	
	    private System.Decimal  _codigo_bitacora = 0;
        	
	    private System.DateTime  _fecha_hora = System.DateTime.Now;
        	
	    private System.String  _pagina_navegacion = String.Empty;
        	
        
	    public ESESION() : base()
	    {
	    }
	    
		public ESESION(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodigoBitacora
	    {
		    get { return _codigo_bitacora; }
		    set { _codigo_bitacora = value; }
	    }
	    
	    	
	    public System.DateTime FechaHora
	    {
		    get { return _fecha_hora; }
		    set { _fecha_hora = value; }
	    }
	    
	    	
	    public System.String PaginaNavegacion
	    {
		    get { return _pagina_navegacion; }
		    set { _pagina_navegacion = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLSESION();
        }

        #endregion	    
    }
}