
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EACCIONBITACORA.
    /// </summary>
    [Serializable()]
    public class EACCIONBITACORA : DomainObject
    {
	    	
	    private System.Decimal  _cod_accion = 0;
        	
	    private System.String  _descripcion = String.Empty;
        	
        
	    public EACCIONBITACORA() : base()
	    {
	    }
	    
		public EACCIONBITACORA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodAccion
	    {
		    get { return _cod_accion; }
		    set { _cod_accion = value; }
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
            return new DLACCIONBITACORA();
        }

        #endregion	    
    }
}