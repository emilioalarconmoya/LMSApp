
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ERESULTADOSUAMS.
    /// </summary>
    [Serializable()]
    public class ERESULTADOSUAMS : DomainObject
    {
	    	
	    private System.Decimal  _cod_resultado_uams = 0;
        	
	    private System.Int16  _cod_unidad = 0;
        	
	    private System.Decimal  _cod_activ_usr = 0;
        	
	    private System.Int32  _cantidad_pasos = 0;
        	
	    private System.Int32  _cantidad_errores = 0;
        	
	    private System.DateTime  _fecha_hora = System.DateTime.Now;
        	
        
	    public ERESULTADOSUAMS() : base()
	    {
	    }
	    
		public ERESULTADOSUAMS(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodResultadoUams
	    {
		    get { return _cod_resultado_uams; }
		    set { _cod_resultado_uams = value; }
	    }
	    
	    	
	    public System.Int16 CodUnidad
	    {
		    get { return _cod_unidad; }
		    set { _cod_unidad = value; }
	    }
	    
	    	
	    public System.Decimal CodActivUsr
	    {
		    get { return _cod_activ_usr; }
		    set { _cod_activ_usr = value; }
	    }
	    
	    	
	    public System.Int32 CantidadPasos
	    {
		    get { return _cantidad_pasos; }
		    set { _cantidad_pasos = value; }
	    }
	    
	    	
	    public System.Int32 CantidadErrores
	    {
		    get { return _cantidad_errores; }
		    set { _cantidad_errores = value; }
	    }
	    
	    	
	    public System.DateTime FechaHora
	    {
		    get { return _fecha_hora; }
		    set { _fecha_hora = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLRESULTADOSUAMS();
        }

        #endregion	    
    }
}