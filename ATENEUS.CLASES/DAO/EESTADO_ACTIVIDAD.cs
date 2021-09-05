
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EESTADOACTIVIDAD.
    /// </summary>
    [Serializable()]
    public class EESTADOACTIVIDAD : DomainObject
    {

        private System.Int16 _cod_estado = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
        
	    public EESTADOACTIVIDAD() : base()
	    {
	    }
	    
		public EESTADOACTIVIDAD(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodEstado
	    {
		    get { return _cod_estado; }
		    set { _cod_estado = value; }
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
            return new DLESTADOACTIVIDAD();
        }

        #endregion	    
    }
}