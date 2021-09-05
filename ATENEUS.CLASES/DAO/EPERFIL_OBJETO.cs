
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPERFILOBJETO.
    /// </summary>
    [Serializable()]
    public class EPERFILOBJETO : DomainObject
    {
	    	
	    private System.Int16  _cod_objeto = 0;
        	
	    private System.Int16  _cod_perfil = 0;
        	
        
	    public EPERFILOBJETO() : base()
	    {
	    }
	    
		public EPERFILOBJETO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodObjeto
	    {
		    get { return _cod_objeto; }
		    set { _cod_objeto = value; }
	    }
	    
	    	
	    public System.Int16 CodPerfil
	    {
		    get { return _cod_perfil; }
		    set { _cod_perfil = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLPERFILOBJETO();
        }

        #endregion	    
    }
}