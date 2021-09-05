
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECOMENTARIO.
    /// </summary>
    [Serializable()]
    public class ECOMENTARIO : DomainObject
    {
	    	
	    private System.Decimal  _IdMensaje = 0;
        	
	    private System.Int32  _IdForo = 0;
        	
	    private System.Int32  _IdHead = 0;
        	
	    private System.String  _autor = String.Empty;
        	
	    private System.String  _email = String.Empty;
        	
	    private System.DateTime  _fechahora = System.DateTime.Now;
        	
	    private System.String  _tema = String.Empty;
        	
	    private System.String  _cuerpo = String.Empty;
        	
	    private System.DateTime  _ultimo = System.DateTime.Now;
        	
	    private System.Int32  _respuestas = 0;
        	
	    private System.String  _quees = String.Empty;
        	
        
	    public ECOMENTARIO() : base()
	    {
	    }
	    
		public ECOMENTARIO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal IdMensaje
	    {
		    get { return _IdMensaje; }
		    set { _IdMensaje = value; }
	    }
	    
	    	
	    public System.Int32 IdForo
	    {
		    get { return _IdForo; }
		    set { _IdForo = value; }
	    }
	    
	    	
	    public System.Int32 IdHead
	    {
		    get { return _IdHead; }
		    set { _IdHead = value; }
	    }
	    
	    	
	    public System.String Autor
	    {
		    get { return _autor; }
		    set { _autor = value; }
	    }
	    
	    	
	    public System.String Email
	    {
		    get { return _email; }
		    set { _email = value; }
	    }
	    
	    	
	    public System.DateTime Fechahora
	    {
		    get { return _fechahora; }
		    set { _fechahora = value; }
	    }
	    
	    	
	    public System.String Tema
	    {
		    get { return _tema; }
		    set { _tema = value; }
	    }
	    
	    	
	    public System.String Cuerpo
	    {
		    get { return _cuerpo; }
		    set { _cuerpo = value; }
	    }
	    
	    	
	    public System.DateTime Ultimo
	    {
		    get { return _ultimo; }
		    set { _ultimo = value; }
	    }
	    
	    	
	    public System.Int32 Respuestas
	    {
		    get { return _respuestas; }
		    set { _respuestas = value; }
	    }
	    
	    	
	    public System.String Quees
	    {
		    get { return _quees; }
		    set { _quees = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLCOMENTARIO();
        }

        #endregion	    
    }
}