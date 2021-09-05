

using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPRODUCTO.
	/// </summary>
    public class EPRODUCTO : DomainObject
    {
	    	
	    private System.String  _COD_PRODUCTO = String.Empty;
        	
	    private System.Int16  _COD_CATEGORIA = 0;
        	
	    private System.String  _NOMBRE = String.Empty;
        	
	    private System.String  _DESCRIPCION = String.Empty;
        	
	    private System.String  _FOTO = String.Empty;

        private System.Int64 _COD_EMPRESA = 0;


        public EPRODUCTO() : base()
	    {
	    }
	    
		public EPRODUCTO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODPRODUCTO
	    {
		    get { return _COD_PRODUCTO; }
		    set { _COD_PRODUCTO = value; }
	    }

        public System.Int64 CodEmpresa
        {
            get { return _COD_EMPRESA; }
            set { _COD_EMPRESA  = value; }
        }
        public System.Int16 CODCATEGORIA
	    {
		    get { return _COD_CATEGORIA; }
		    set { _COD_CATEGORIA = value; }
	    }
	    
	    	
	    public System.String NOMBRE
	    {
		    get { return _NOMBRE; }
		    set { _NOMBRE = value; }
	    }
	    
	    	
	    public System.String DESCRIPCION
	    {
		    get { return _DESCRIPCION; }
		    set { _DESCRIPCION = value; }
	    }
	    
	    	
	    public System.String FOTO
	    {
		    get { return _FOTO; }
		    set { _FOTO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLPRODUCTO();
        }

        #endregion	    
    }
}