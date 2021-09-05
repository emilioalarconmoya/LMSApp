
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EDEPENDENCIA.
    /// </summary>
    [Serializable()]
    public class EDEPENDENCIA : DomainObject
    {
	    	
	    private System.Decimal  _Cod_Malla = 0;
        	
	    private System.Int16  _ACT_cod_actividad = 0;
        	
	    private System.Int16  _cod_actividad = 0;
        	
        
	    public EDEPENDENCIA() : base()
	    {
	    }
	    
		public EDEPENDENCIA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodMalla
	    {
		    get { return _Cod_Malla; }
		    set { _Cod_Malla = value; }
	    }
	    
	    	
	    public System.Int16 ACTCodActividad
	    {
		    get { return _ACT_cod_actividad; }
		    set { _ACT_cod_actividad = value; }
	    }
	    
	    	
	    public System.Int16 CodActividad
	    {
		    get { return _cod_actividad; }
		    set { _cod_actividad = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLDEPENDENCIA();
        }

        #endregion	    
    }
}