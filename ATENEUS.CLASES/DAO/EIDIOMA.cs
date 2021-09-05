
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EIDIOMA.
    /// </summary>
    [Serializable()]
    public class EIDIOMA : DomainObject
    {
	    	
	    private System.Int16  _cod_idioma = 0;
        	
	    private System.String  _idioma = String.Empty;
        	
        
	    public EIDIOMA() : base()
	    {
	    }
	    
		public EIDIOMA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodIdioma
	    {
		    get { return _cod_idioma; }
		    set { _cod_idioma = value; }
	    }
	    
	    	
	    public System.String Idioma
	    {
		    get { return _idioma; }
		    set { _idioma = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLIDIOMA();
        }

        #endregion	    
    }
}