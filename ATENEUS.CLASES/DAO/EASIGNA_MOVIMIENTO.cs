

using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EASIGNAMOVIMIENTO.
	/// </summary>
    public class EASIGNAMOVIMIENTO : DomainObject
    {
	    	
	    private System.Decimal  _COD_MOVIMIENTO = 0;
        	
	    private System.Int64  _RUT_USUARIO = 0;
        	
        
	    public EASIGNAMOVIMIENTO() : base()
	    {
	    }
	    
		public EASIGNAMOVIMIENTO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODMOVIMIENTO
	    {
		    get { return _COD_MOVIMIENTO; }
		    set { _COD_MOVIMIENTO = value; }
	    }
	    
	    	
	    public System.Int64 RUTUSUARIO
	    {
		    get { return _RUT_USUARIO; }
		    set { _RUT_USUARIO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLASIGNAMOVIMIENTO();
        }

        #endregion	    
    }
}