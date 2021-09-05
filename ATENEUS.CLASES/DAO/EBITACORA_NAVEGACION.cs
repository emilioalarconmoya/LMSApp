
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EBITACORANAVEGACION.
    /// </summary>
    [Serializable()]
    public class EBITACORANAVEGACION : DomainObject
    {
	    	
	    private System.Decimal  _codigo_bitacora = 0;
        	
	    private System.Int64  _rut_usuario = 0;
        	
	    private System.Decimal  _cod_activ_usr = 0;
        	
	    private System.String  _user_agent = String.Empty;
        	
	    private System.String  _direccion_ip = String.Empty;
        	
	    private System.String  _pais = String.Empty;
        	
	    private System.String  _pagina_navegacion = String.Empty;
        	
	    private System.Int32  _sesion = 0;
        	
	    private System.String  _sesionID = String.Empty;
        	
	    private System.String  _version_browser = String.Empty;
        	
	    private System.String  _browser = String.Empty;
        	
	    private System.String  _plataforma = String.Empty;
        	
        
	    public EBITACORANAVEGACION() : base()
	    {
	    }
	    
		public EBITACORANAVEGACION(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodigoBitacora
	    {
		    get { return _codigo_bitacora; }
		    set { _codigo_bitacora = value; }
	    }
	    
	    	
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
	    
	    	
	    public System.String UserAgent
	    {
		    get { return _user_agent; }
		    set { _user_agent = value; }
	    }
	    
	    	
	    public System.String DireccionIp
	    {
		    get { return _direccion_ip; }
		    set { _direccion_ip = value; }
	    }
	    
	    	
	    public System.String Pais
	    {
		    get { return _pais; }
		    set { _pais = value; }
	    }
	    
	    	
	    public System.String PaginaNavegacion
	    {
		    get { return _pagina_navegacion; }
		    set { _pagina_navegacion = value; }
	    }
	    
	    	
	    public System.Int32 Sesion
	    {
		    get { return _sesion; }
		    set { _sesion = value; }
	    }
	    
	    	
	    public System.String SesionID
	    {
		    get { return _sesionID; }
		    set { _sesionID = value; }
	    }
	    
	    	
	    public System.String VersionBrowser
	    {
		    get { return _version_browser; }
		    set { _version_browser = value; }
	    }
	    
	    	
	    public System.String Browser
	    {
		    get { return _browser; }
		    set { _browser = value; }
	    }
	    
	    	
	    public System.String Plataforma
	    {
		    get { return _plataforma; }
		    set { _plataforma = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLBITACORANAVEGACION();
        }

        #endregion	    
    }
}