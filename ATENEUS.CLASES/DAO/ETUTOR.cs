
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ETUTOR.
    /// </summary>
    [Serializable()]
    public class ETUTOR : DomainObject
    {
	    	
	    private System.Int64  _rut_usuario = 0;
        	
	    private System.Decimal  _cod_activ_usr = 0;
        	
        
	    public ETUTOR() : base()
	    {
	    }
	    
		public ETUTOR(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int64 RutUsuario
	    {
		    get { return _rut_usuario; }
		    set { _rut_usuario = value; }
	    }
	    
	    	
	    public System.Decimal CodActivUsr
	    {
		    get { return _cod_activ_usr; }
		    set { _cod_activ_usr = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLTUTOR();
        }

        #endregion	    
    }
}