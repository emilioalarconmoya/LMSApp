
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPERFIL.
    /// </summary>
    [Serializable()]
    public class EPERFIL : DomainObject
    {
	    	
	    private System.Int16  _cod_perfil = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
        
	    public EPERFIL() : base()
	    {
	    }
	    
		public EPERFIL(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodPerfil
	    {
		    get { return _cod_perfil; }
		    set { _cod_perfil = value; }
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
            return new DLPERFIL();
        }

        #endregion	    
    }
}