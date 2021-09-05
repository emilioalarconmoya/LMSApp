
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ETIPOUNIDAD.
    /// </summary>
    [Serializable()]
    public class ETIPOUNIDAD : DomainObject
    {
	    	
	    private System.Int16  _cod_tipo_unidad = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
        
	    public ETIPOUNIDAD() : base()
	    {
	    }
	    
		public ETIPOUNIDAD(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodTipoUnidad
	    {
		    get { return _cod_tipo_unidad; }
		    set { _cod_tipo_unidad = value; }
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
            return new DLTIPOUNIDAD();
        }

        #endregion	    
    }
}