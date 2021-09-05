
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EMODULO.
    /// </summary>
    [Serializable()]
    public class EMODULO : DomainObject
    {
	    	
	    private System.Int16  _cod_modulo = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
        
	    public EMODULO() : base()
	    {
	    }
	    
		public EMODULO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodModulo
	    {
		    get { return _cod_modulo; }
		    set { _cod_modulo = value; }
	    }
	    
	    	
	    public System.String Nombre
	    {
		    get { return _nombre; }
		    set { _nombre = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLMODULO();
        }

        #endregion	    
    }
}