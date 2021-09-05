
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EDECLARACIONJURADA.
    /// </summary>
    [Serializable()]
    public class EDECLARACIONJURADA : DomainObject
    {
	    	
	    private System.Decimal  _cod_declaracion = 0;
        	
	    private System.Decimal  _cod_activ_usr = 0;
        	
	    private System.String  _profesion = String.Empty;
        	
	    private System.String  _direccion = String.Empty;
        	
	    private System.String  _comuna = String.Empty;
        	
	    private System.Boolean  _flag_firmada = false;
        	
	    private System.String  _ip = String.Empty;
        	
	    private System.DateTime  _fecha_hora_firma = System.DateTime.Now;
        	
        
	    public EDECLARACIONJURADA() : base()
	    {
	    }
	    
		public EDECLARACIONJURADA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodDeclaracion
	    {
		    get { return _cod_declaracion; }
		    set { _cod_declaracion = value; }
	    }
	    
	    	
	    public System.Decimal CodActivUsr
	    {
		    get { return _cod_activ_usr; }
		    set { _cod_activ_usr = value; }
	    }
	    
	    	
	    public System.String Profesion
	    {
		    get { return _profesion; }
		    set { _profesion = value; }
	    }
	    
	    	
	    public System.String Direccion
	    {
		    get { return _direccion; }
		    set { _direccion = value; }
	    }
	    
	    	
	    public System.String Comuna
	    {
		    get { return _comuna; }
		    set { _comuna = value; }
	    }
	    
	    	
	    public System.Boolean FlagFirmada
	    {
		    get { return _flag_firmada; }
		    set { _flag_firmada = value; }
	    }
	    
	    	
	    public System.String Ip
	    {
		    get { return _ip; }
		    set { _ip = value; }
	    }
	    
	    	
	    public System.DateTime FechaHoraFirma
	    {
		    get { return _fecha_hora_firma; }
		    set { _fecha_hora_firma = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLDECLARACIONJURADA();
        }

        #endregion	    
    }
}