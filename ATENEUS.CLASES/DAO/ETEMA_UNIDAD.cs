
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ETEMAUNIDAD.
    /// </summary>
    [Serializable()]
    public class ETEMAUNIDAD : DomainObject
    {
	    	
	    private System.Int16  _cod_tema_unidad = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
        
	    public ETEMAUNIDAD() : base()
	    {
	    }
	    
		public ETEMAUNIDAD(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodTemaUnidad
	    {
		    get { return _cod_tema_unidad; }
		    set { _cod_tema_unidad = value; }
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
            return new DLTEMAUNIDAD();
        }

        #endregion	    
    }
}