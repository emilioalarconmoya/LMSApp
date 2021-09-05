
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EACTIVIDADFORO.
    /// </summary>
    [Serializable()]
    public class EACTIVIDADFORO : DomainObject
    {
	    	
	    private System.Int16  _cod_actividad = 0;
        	
	    private System.Int32  _IdForo = 0;
        	
        
	    public EACTIVIDADFORO() : base()
	    {
	    }
	    
		public EACTIVIDADFORO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodActividad
	    {
		    get { return _cod_actividad; }
		    set { _cod_actividad = value; }
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
            return new DLACTIVIDADFORO();
        }

        #endregion	    
    }
}