
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ETIPOACTIVIDAD.
    /// </summary>
    [Serializable()]
    public class ETIPOACTIVIDAD : DomainObject
    {

        private System.Int16 _cod_tipo = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
        
	    public ETIPOACTIVIDAD() : base()
	    {
	    }
	    
		public ETIPOACTIVIDAD(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
        public System.Int16 CodTipo
	    {
		    get { return _cod_tipo; }
		    set { _cod_tipo = value; }
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
            return new DLTIPOACTIVIDAD();
        }

        #endregion	    
    }
}