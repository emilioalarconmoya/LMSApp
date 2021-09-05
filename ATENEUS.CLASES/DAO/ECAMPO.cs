
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECAMPO.
    /// </summary>
    [Serializable()]
    public class ECAMPO : DomainObject
    {
	    	
	    private System.Decimal  _cod_campo = 0;
        	
	    private System.Int32  _orden = 0;
        	
	    private System.String  _campo = String.Empty;
        	
	    private System.String  _cabecera = String.Empty;
        	
	    private System.String  _campoBD = String.Empty;
        	
	    private System.Int32  _tipo = 0;
        	
        
	    public ECAMPO() : base()
	    {
	    }
	    
		public ECAMPO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodCampo
	    {
		    get { return _cod_campo; }
		    set { _cod_campo = value; }
	    }
	    
	    	
	    public System.Int32 Orden
	    {
		    get { return _orden; }
		    set { _orden = value; }
	    }
	    
	    	
	    public System.String Campo
	    {
		    get { return _campo; }
		    set { _campo = value; }
	    }
	    
	    	
	    public System.String Cabecera
	    {
		    get { return _cabecera; }
		    set { _cabecera = value; }
	    }
	    
	    	
	    public System.String CampoBD
	    {
		    get { return _campoBD; }
		    set { _campoBD = value; }
	    }
	    
	    	
	    public System.Int32 Tipo
	    {
		    get { return _tipo; }
		    set { _tipo = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLCAMPO();
        }

        #endregion	    
    }
}