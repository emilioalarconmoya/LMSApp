
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EBITACORAACTIVIDADUSUARIO.
    /// </summary>
    [Serializable()]
    public class EBITACORAACTIVIDADUSUARIO : DomainObject
    {
	    	
	    private System.Decimal  _cod_activ_usr = 0;
        	
	    private System.DateTime  _fecha_hora_inicio = System.DateTime.Now;
        	
	    private System.DateTime  _fecha_hora_fin = System.DateTime.Now;
        	
	    private System.Boolean  _flag_comunico_inicio = false;
        	
	    private System.Boolean  _flag_comunico_fin = false;
        	
	    private System.String  _resultado_inicio = String.Empty;
        	
	    private System.String  _resultado_fin = String.Empty;
        	
        
	    public EBITACORAACTIVIDADUSUARIO() : base()
	    {
	    }
	    
		public EBITACORAACTIVIDADUSUARIO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodActivUsr
	    {
		    get { return _cod_activ_usr; }
		    set { _cod_activ_usr = value; }
	    }
	    
	    	
	    public System.DateTime FechaHoraInicio
	    {
		    get { return _fecha_hora_inicio; }
		    set { _fecha_hora_inicio = value; }
	    }
	    
	    	
	    public System.DateTime FechaHoraFin
	    {
		    get { return _fecha_hora_fin; }
		    set { _fecha_hora_fin = value; }
	    }
	    
	    	
	    public System.Boolean FlagComunicoInicio
	    {
		    get { return _flag_comunico_inicio; }
		    set { _flag_comunico_inicio = value; }
	    }
	    
	    	
	    public System.Boolean FlagComunicoFin
	    {
		    get { return _flag_comunico_fin; }
		    set { _flag_comunico_fin = value; }
	    }
	    
	    	
	    public System.String ResultadoInicio
	    {
		    get { return _resultado_inicio; }
		    set { _resultado_inicio = value; }
	    }
	    
	    	
	    public System.String ResultadoFin
	    {
		    get { return _resultado_fin; }
		    set { _resultado_fin = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLBITACORAACTIVIDADUSUARIO();
        }

        #endregion	    
    }
}