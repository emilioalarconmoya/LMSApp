
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPAGINA.
    /// </summary>
    [Serializable()]
    public class EPAGINA : DomainObject
    {
	    	
	    private System.String  _path = String.Empty;
        	
	    private System.String  _nombre_externo = String.Empty;
        	
        
	    public EPAGINA() : base()
	    {
	    }
	    
		public EPAGINA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String Path
	    {
		    get { return _path; }
		    set { _path = value; }
	    }
	    
	    	
	    public System.String NombreExterno
	    {
		    get { return _nombre_externo; }
		    set { _nombre_externo = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLPAGINA();
        }

        #endregion	    
    }
}