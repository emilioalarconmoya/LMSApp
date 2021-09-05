
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ETIPOPREGUNTA.
    /// </summary>
    [Serializable()]
    public class ETIPOPREGUNTA : DomainObject
    {
	    	
	    private System.Int16  _cod_tipo_preg = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
        
	    public ETIPOPREGUNTA() : base()
	    {
	    }
	    
		public ETIPOPREGUNTA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
        public System.Int16 CodTipoPreg
	    {
		    get { return _cod_tipo_preg; }
		    set { _cod_tipo_preg = value; }
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
            return new DLTIPOPREGUNTA();
        }

        #endregion	    
    }
}