
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EBITACORAADMINISTRACION.
    /// </summary>
    [Serializable()]
    public class EBITACORAADMINISTRACION : DomainObject
    {
	    	
	    private System.Decimal  _id_bitacora = 0;
        	
	    private System.Int64  _rut_usuario = 0;
        	
	    private System.Decimal  _cod_accion = 0;
        	
	    private System.Int64  _USU_rut_usuario = 0;
        	
	    private System.DateTime  _fecha_hora = System.DateTime.Now;
        	
	    private System.String  _descripcion = String.Empty;
        	
        
	    public EBITACORAADMINISTRACION() : base()
	    {
	    }
	    
		public EBITACORAADMINISTRACION(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal IdBitacora
	    {
		    get { return _id_bitacora; }
		    set { _id_bitacora = value; }
	    }
	    
	    	
	    public System.Int64 RutUsuario
	    {
		    get { return _rut_usuario; }
		    set { _rut_usuario = value; }
	    }
	    
	    	
	    public System.Decimal CodAccion
	    {
		    get { return _cod_accion; }
		    set { _cod_accion = value; }
	    }
	    
	    	
	    public System.Int64 USURutUsuario
	    {
		    get { return _USU_rut_usuario; }
		    set { _USU_rut_usuario = value; }
	    }
	    
	    	
	    public System.DateTime FechaHora
	    {
		    get { return _fecha_hora; }
		    set { _fecha_hora = value; }
	    }
	    
	    	
	    public System.String Descripcion
	    {
		    get { return _descripcion; }
		    set { _descripcion = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLBITACORAADMINISTRACION();
        }

        #endregion	    
    }
}