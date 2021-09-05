
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EMENSAJE.
    /// </summary>
    [Serializable()]
    public class EMENSAJE : DomainObject
    {
	    	
	    private System.Decimal  _cod_mensaje = 0;
        	
	    private System.Int16  _cod_actividad = 0;
        	
	    private System.Int64  _rut_usuario_dest = 0;
        	
	    private System.Int64  _rut_usuario_origen = 0;
        	
	    private System.DateTime  _fecha_hora = System.DateTime.Now;
        	
	    private System.String  _texto_mensaje = String.Empty;
        	
	    private System.Boolean  _estado = false;
        	
	    private System.Boolean  _Visto = false;
        	
        
	    public EMENSAJE() : base()
	    {
	    }
	    
		public EMENSAJE(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodMensaje
	    {
		    get { return _cod_mensaje; }
		    set { _cod_mensaje = value; }
	    }
	    
	    	
	    public System.Int16 CodActividad
	    {
		    get { return _cod_actividad; }
		    set { _cod_actividad = value; }
	    }
	    
	    	
	    public System.Int64 RutUsuarioDest
	    {
		    get { return _rut_usuario_dest; }
		    set { _rut_usuario_dest = value; }
	    }
	    
	    	
	    public System.Int64 RutUsuarioOrigen
	    {
		    get { return _rut_usuario_origen; }
		    set { _rut_usuario_origen = value; }
	    }
	    
	    	
	    public System.DateTime FechaHora
	    {
		    get { return _fecha_hora; }
		    set { _fecha_hora = value; }
	    }
	    
	    	
	    public System.String TextoMensaje
	    {
		    get { return _texto_mensaje; }
		    set { _texto_mensaje = value; }
	    }
	    
	    	
	    public System.Boolean Estado
	    {
		    get { return _estado; }
		    set { _estado = value; }
	    }
	    
	    	
	    public System.Boolean Visto
	    {
		    get { return _Visto; }
		    set { _Visto = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLMENSAJE();
        }

        #endregion	    
    }
}