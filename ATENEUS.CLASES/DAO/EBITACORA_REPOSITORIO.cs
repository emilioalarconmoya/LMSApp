
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EBITACORAREPOSITORIO.
    /// </summary>
    [Serializable()]
    public class EBITACORAREPOSITORIO : DomainObject
    {
	    	
	    private System.Decimal  _cod_bitacora = 0;
        	
	    private System.Int64  _rut_usuario = 0;
        	
	    private System.Int16  _cod_unidad = 0;
        	
	    private System.Decimal  _cod_tipo_bitacora = 0;
        	
	    private System.DateTime  _fecha_hora = System.DateTime.Now;
        	
        
	    public EBITACORAREPOSITORIO() : base()
	    {
	    }
	    
		public EBITACORAREPOSITORIO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodBitacora
	    {
		    get { return _cod_bitacora; }
		    set { _cod_bitacora = value; }
	    }
	    
	    	
	    public System.Int64 RutUsuario
	    {
		    get { return _rut_usuario; }
		    set { _rut_usuario = value; }
	    }
	    
	    	
	    public System.Int16 CodUnidad
	    {
		    get { return _cod_unidad; }
		    set { _cod_unidad = value; }
	    }
	    
	    	
	    public System.Decimal CodTipoBitacora
	    {
		    get { return _cod_tipo_bitacora; }
		    set { _cod_tipo_bitacora = value; }
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
            return new DLBITACORAREPOSITORIO();
        }

        #endregion	    
    }
}