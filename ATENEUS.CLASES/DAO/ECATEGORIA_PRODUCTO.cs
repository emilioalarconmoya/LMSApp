

using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    /// <summary>
    /// Summary description for ECATEGORIAPRODUCTO.
    /// </summary>
    [Serializable]
    public class ECATEGORIAPRODUCTO : DomainObject
    {
	    	
	    private System.Int16  _COD_CATEGORIA = 0;

        private System.Int64 _COD_EMPRESA = 0;

        private System.String  _NOMBRE = String.Empty;
        	
        
	    public ECATEGORIAPRODUCTO() : base()
	    {
	    }
	    
		public ECATEGORIAPRODUCTO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CODCATEGORIA
	    {
		    get { return _COD_CATEGORIA; }
		    set { _COD_CATEGORIA = value; }
	    }
        public System.Int64 CODEMPRESA
        {
            get { return _COD_EMPRESA; }
            set { _COD_EMPRESA = value; }
        }

        public System.String NOMBRE
	    {
		    get { return _NOMBRE; }
		    set { _NOMBRE = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLCATEGORIAPRODUCTO();
        }

        #endregion	    
    }
}