
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ETIPOBITACORAREPOSITORIO.
    /// </summary>
    [Serializable()]
    public class ETIPOBITACORAREPOSITORIO : DomainObject
    {
	    	
	    private System.Decimal  _cod_tipo_bitacora = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
        
	    public ETIPOBITACORAREPOSITORIO() : base()
	    {
	    }
	    
		public ETIPOBITACORAREPOSITORIO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodTipoBitacora
	    {
		    get { return _cod_tipo_bitacora; }
		    set { _cod_tipo_bitacora = value; }
	    }
	    
	    	
	    public System.String Nombre
	    {
		    get { return _nombre; }
		    set { _nombre = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLTIPOBITACORAREPOSITORIO();
        }

        #endregion	    
    }
}