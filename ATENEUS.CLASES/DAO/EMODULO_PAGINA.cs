
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EMODULOPAGINA.
    /// </summary>
    [Serializable()]
    public class EMODULOPAGINA : DomainObject
    {
	    	
	    private System.Int16  _cod_modulo = 0;
        	
	    private System.String  _path_origen = String.Empty;
        	
	    private System.String  _path = String.Empty;
        	
        
	    public EMODULOPAGINA() : base()
	    {
	    }
	    
		public EMODULOPAGINA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodModulo
	    {
		    get { return _cod_modulo; }
		    set { _cod_modulo = value; }
	    }
	    
	    	
	    public System.String PathOrigen
	    {
		    get { return _path_origen; }
		    set { _path_origen = value; }
	    }
	    
	    	
	    public System.String Path
	    {
		    get { return _path; }
		    set { _path = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLMODULOPAGINA();
        }

        #endregion	    
    }
}