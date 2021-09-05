

using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ETIPOMOVIMIENTO.
	/// </summary>
    public class ETIPOMOVIMIENTO : DomainObject
    {
	    	
	    private System.Int16  _COD_TIPO_MOVIMIENTO = 0;
        	
	    private System.String  _NOMBRE = String.Empty;
        	
        
	    public ETIPOMOVIMIENTO() : base()
	    {
	    }
	    
		public ETIPOMOVIMIENTO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CODTIPOMOVIMIENTO
	    {
		    get { return _COD_TIPO_MOVIMIENTO; }
		    set { _COD_TIPO_MOVIMIENTO = value; }
	    }
	    
	    	
	    public System.String NOMBRE
	    {
		    get { return _NOMBRE; }
		    set { _NOMBRE = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLTIPOMOVIMIENTO();
        }

        #endregion	    
    }
}