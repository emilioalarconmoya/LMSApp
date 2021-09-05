
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EOBJETO.
    /// </summary>
    [Serializable()]
    public class EOBJETO : DomainObject
    {
	    	
	    private System.Int16  _cod_objeto = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
        
	    public EOBJETO() : base()
	    {
	    }
	    
		public EOBJETO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodObjeto
	    {
		    get { return _cod_objeto; }
		    set { _cod_objeto = value; }
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
            return new DLOBJETO();
        }

        #endregion	    
    }
}