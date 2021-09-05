
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EVARIABLESGLOBALES.
    /// </summary>
    [Serializable()]
    public class EVARIABLESGLOBALES : DomainObject
    {
	    	
	    private System.String  _nombre = String.Empty;
        	
	    private System.String  _valor = String.Empty;
        	
        
	    public EVARIABLESGLOBALES() : base()
	    {
	    }
	    
		public EVARIABLESGLOBALES(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String Nombre
	    {
		    get { return _nombre; }
		    set { _nombre = value; }
	    }
	    
	    	
	    public System.String Valor
	    {
		    get { return _valor; }
		    set { _valor = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLVARIABLESGLOBALES();
        }

        #endregion	    
    }
}