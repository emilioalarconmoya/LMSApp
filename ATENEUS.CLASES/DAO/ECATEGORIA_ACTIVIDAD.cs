

using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    /// <summary>
    /// Summary description for ECATEGORIAPRODUCTO.
    /// </summary>
    [Serializable]
    public class ECATAGORIAACTIVIDAD : DomainObject
    {
	    	
	    private System.Int16  _COD_CATEGORIA = 0;
        	
	    private System.String  _NOMBRE = String.Empty;

        private System.String _NOMBRE_CLASS = String.Empty;

        private System.Int64 _cod_empresa = 0;


        public ECATAGORIAACTIVIDAD() : base()
	    {
	    }
	    
		public ECATAGORIAACTIVIDAD(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodCategoria
	    {
		    get { return _COD_CATEGORIA; }
		    set { _COD_CATEGORIA = value; }
	    }
	    
	    	
	    public System.String NombreCategoria
	    {
		    get { return _NOMBRE; }
		    set { _NOMBRE = value; }
	    }

        public System.String NombreClass
        {
            get { return _NOMBRE_CLASS; }
            set { _NOMBRE_CLASS = value; }
        }

        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }

        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLCATEGORIAACTIVIDAD();
        }

        #endregion	    
    }
}