
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EMODELODISPOSITIVO.
    /// </summary>
    [Serializable()]
    public class EMODELODISPOSITIVO : DomainObject
    {
	    	
	    private System.String  _marca = String.Empty;
        	
	    private System.String  _modelo = String.Empty;
        	
	    private System.String  _busqueda = String.Empty;
        	
	    private System.Int32  _width = 0;
        	
	    private System.Int32  _height = 0;
        	
	    private System.String  _css = String.Empty;
        	
	    private System.String  _media = String.Empty;
        	
	    private System.String  _viewport = String.Empty;
        	
	    private System.Boolean  _movil = false;
        	
	    private System.String  _carpeta = String.Empty;
        	
        
	    public EMODELODISPOSITIVO() : base()
	    {
	    }
	    
		public EMODELODISPOSITIVO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String Marca
	    {
		    get { return _marca; }
		    set { _marca = value; }
	    }
	    
	    	
	    public System.String Modelo
	    {
		    get { return _modelo; }
		    set { _modelo = value; }
	    }
	    
	    	
	    public System.String Busqueda
	    {
		    get { return _busqueda; }
		    set { _busqueda = value; }
	    }
	    
	    	
	    public System.Int32 Width
	    {
		    get { return _width; }
		    set { _width = value; }
	    }
	    
	    	
	    public System.Int32 Height
	    {
		    get { return _height; }
		    set { _height = value; }
	    }
	    
	    	
	    public System.String Css
	    {
		    get { return _css; }
		    set { _css = value; }
	    }
	    
	    	
	    public System.String Media
	    {
		    get { return _media; }
		    set { _media = value; }
	    }
	    
	    	
	    public System.String Viewport
	    {
		    get { return _viewport; }
		    set { _viewport = value; }
	    }
	    
	    	
	    public System.Boolean Movil
	    {
		    get { return _movil; }
		    set { _movil = value; }
	    }
	    
	    	
	    public System.String Carpeta
	    {
		    get { return _carpeta; }
		    set { _carpeta = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLMODELODISPOSITIVO();
        }

        #endregion	    
    }
}