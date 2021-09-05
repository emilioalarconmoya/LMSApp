
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ELINKEXTERNO.
    /// </summary>
    [Serializable()]
    public class ELINKEXTERNO : DomainObject
    {
	    	
	    private System.Int16  _cod_link = 0;
        	
	    private System.String  _url = String.Empty;
        	
	    private System.String  _nombre = String.Empty;
        	
        
	    public ELINKEXTERNO() : base()
	    {
	    }
	    
		public ELINKEXTERNO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodLink
	    {
		    get { return _cod_link; }
		    set { _cod_link = value; }
	    }
	    
	    	
	    public System.String Url
	    {
		    get { return _url; }
		    set { _url = value; }
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
            return new DLLINKEXTERNO();
        }

        #endregion	    
    }
}