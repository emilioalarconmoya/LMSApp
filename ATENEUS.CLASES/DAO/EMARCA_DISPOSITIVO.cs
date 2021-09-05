
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EMARCADISPOSITIVO.
    /// </summary>
    [Serializable()]
    public class EMARCADISPOSITIVO : DomainObject
    {
	    	
	    private System.String  _marca = String.Empty;
        	
        
	    public EMARCADISPOSITIVO() : base()
	    {
	    }
	    
		public EMARCADISPOSITIVO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String Marca
	    {
		    get { return _marca; }
		    set { _marca = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLMARCADISPOSITIVO();
        }

        #endregion	    
    }
}