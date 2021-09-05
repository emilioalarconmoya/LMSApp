
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPERFILUSUARIO.
    /// </summary>
    [Serializable()]
    public class EPERFILUSUARIO : DomainObject
    {
	    	
	    private System.Int16  _cod_perfil = 0;
        	
	    private System.Int64  _rut_usuario = 0;
        	
        
	    public EPERFILUSUARIO() : base()
	    {
	    }
	    
		public EPERFILUSUARIO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodPerfil
	    {
		    get { return _cod_perfil; }
		    set { _cod_perfil = value; }
	    }
	    
	    	
	    public System.Int64 RutUsuario
	    {
		    get { return _rut_usuario; }
		    set { _rut_usuario = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLPERFILUSUARIO();
        }

        #endregion	    
    }
}