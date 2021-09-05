
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EUNIDADFORO.
    /// </summary>
    [Serializable()]
    public class EUNIDADFORO : DomainObject
    {
	    	
	    private System.Int16  _cod_unidad = 0;
        	
	    private System.Int32  _IdForo = 0;
        	
        
	    public EUNIDADFORO() : base()
	    {
	    }
	    
		public EUNIDADFORO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodUnidad
	    {
		    get { return _cod_unidad; }
		    set { _cod_unidad = value; }
	    }
	    
	    	
	    public System.Int32 IdForo
	    {
		    get { return _IdForo; }
		    set { _IdForo = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLUNIDADFORO();
        }

        #endregion	    
    }
}