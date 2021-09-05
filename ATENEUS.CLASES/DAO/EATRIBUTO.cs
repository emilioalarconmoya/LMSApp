
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EATRIBUTO.
    /// </summary>
    [Serializable()]
    public class EATRIBUTO : DomainObject
    {
	    	
	    private System.Int16  _cod_atributo = 0;
        	
	    private System.Int16  _cod_caracteristica = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
        
	    public EATRIBUTO() : base()
	    {
	    }
	    
		public EATRIBUTO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodAtributo
	    {
		    get { return _cod_atributo; }
		    set { _cod_atributo = value; }
	    }
	    
	    	
	    public System.Int16 CodCaracteristica
	    {
		    get { return _cod_caracteristica; }
		    set { _cod_caracteristica = value; }
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
            return new DLATRIBUTO();
        }

        #endregion	    
    }
}