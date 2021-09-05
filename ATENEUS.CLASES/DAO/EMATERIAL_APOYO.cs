
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EMATERIALAPOYO.
    /// </summary>
    [Serializable()]
    public class EMATERIALAPOYO : DomainObject
    {
	    	
	    private System.Decimal  _cod_material = 0;
        	
	    private System.Int16  _cod_actividad = 0;
        	
	    private System.String  _archivo = String.Empty;
        	
	    private System.String  _nombre = String.Empty;
        	
	    private System.String  _descripcion = String.Empty;
        	
        
	    public EMATERIALAPOYO() : base()
	    {
	    }
	    
		public EMATERIALAPOYO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodMaterial
	    {
		    get { return _cod_material; }
		    set { _cod_material = value; }
	    }
	    
	    	
	    public System.Int16 CodActividad
	    {
		    get { return _cod_actividad; }
		    set { _cod_actividad = value; }
	    }
	    
	    	
	    public System.String Archivo
	    {
		    get { return _archivo; }
		    set { _archivo = value; }
	    }
	    
	    	
	    public System.String Nombre
	    {
		    get { return _nombre; }
		    set { _nombre = value; }
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
            return new DLMATERIALAPOYO();
        }

        #endregion	    
    }
}