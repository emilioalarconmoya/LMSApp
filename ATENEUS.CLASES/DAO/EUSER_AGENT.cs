
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EUSERAGENT.
    /// </summary>
    [Serializable()]
    public class EUSERAGENT : DomainObject
    {
	    	
	    private System.String  _user_agent = String.Empty;
        	
	    private System.String  _marca = String.Empty;
        	
	    private System.String  _modelo = String.Empty;
        	
        
	    public EUSERAGENT() : base()
	    {
	    }
	    
		public EUSERAGENT(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String UserAgent
	    {
		    get { return _user_agent; }
		    set { _user_agent = value; }
	    }
	    
	    	
	    public System.String Marca
	    {
		    get { return _marca; }
		    set { _marca = value; }
	    }
	    
	    	
	    public System.String Modelo
	    {
		    get { return _modelo; }
		    set { _modelo = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLUSERAGENT();
        }

        #endregion	    
    }
}