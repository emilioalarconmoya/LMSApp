
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EAVISOSHOME.
    /// </summary>
    [Serializable()]
    public class EAVISOSHOME : DomainObject
    {
	    	
	    private System.Decimal  _cod_aviso = 0;
        	
	    private System.String  _titulo = String.Empty;
        	
	    private System.String  _resumen = String.Empty;
        	
	    private System.String  _texto = String.Empty;
        	
	    private System.Boolean  _mostrar = false;
        	
	    private System.DateTime  _fecha_hora = System.DateTime.Now;
        	
	    private System.String  _imagen = String.Empty;
        	
        
	    public EAVISOSHOME() : base()
	    {
	    }
	    
		public EAVISOSHOME(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodAviso
	    {
		    get { return _cod_aviso; }
		    set { _cod_aviso = value; }
	    }
	    
	    	
	    public System.String Titulo
	    {
		    get { return _titulo; }
		    set { _titulo = value; }
	    }
	    
	    	
	    public System.String Resumen
	    {
		    get { return _resumen; }
		    set { _resumen = value; }
	    }
	    
	    	
	    public System.String Texto
	    {
		    get { return _texto; }
		    set { _texto = value; }
	    }
	    
	    	
	    public System.Boolean Mostrar
	    {
		    get { return _mostrar; }
		    set { _mostrar = value; }
	    }
	    
	    	
	    public System.DateTime FechaHora
	    {
		    get { return _fecha_hora; }
		    set { _fecha_hora = value; }
	    }
	    
	    	
	    public System.String Imagen
	    {
		    get { return _imagen; }
		    set { _imagen = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLAVISOSHOME();
        }

        #endregion	    
    }
}