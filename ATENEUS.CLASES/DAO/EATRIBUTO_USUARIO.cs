
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EATRIBUTOUSUARIO.
    /// </summary>
    [Serializable()]
    public class EATRIBUTOUSUARIO : DomainObject
    {
	    	
	    private System.Int16  _cod_atributo = 0;
        	
	    private System.Int64  _rut_usuario = 0;
        	
        
	    public EATRIBUTOUSUARIO() : base()
	    {
	    }
	    
		public EATRIBUTOUSUARIO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodAtributo
	    {
		    get { return _cod_atributo; }
		    set { _cod_atributo = value; }
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
            return new DLATRIBUTOUSUARIO();
        }

        #endregion	    
    }
}