

using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPRODUCTOTIENDA.
	/// </summary>
    public class EPRODUCTOTIENDA : DomainObject
    {
	    	
	    private System.String  _COD_PRODUCTO = String.Empty;
        	
	    private System.String  _COD_TIENDA = String.Empty;
        	
	    private System.Int32  _STOCK = 0;
        	
	    private System.Int32  _COSTO_PUNTOS = 0;

        private System.Int32 _SALDO_INICIAL = 0;

        private System.Int32 _MAX_CANJEES = 0;


        public EPRODUCTOTIENDA() : base()
	    {
	    }
	    
		public EPRODUCTOTIENDA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODPRODUCTO
	    {
		    get { return _COD_PRODUCTO; }
		    set { _COD_PRODUCTO = value; }
	    }
	    
	    	
	    public System.String CODTIENDA
	    {
		    get { return _COD_TIENDA; }
		    set { _COD_TIENDA = value; }
	    }
	    
	    	
	    public System.Int32 STOCK
	    {
		    get { return _STOCK; }
		    set { _STOCK = value; }
	    }
	    
	    	
	    public System.Int32 COSTOPUNTOS
	    {
		    get { return _COSTO_PUNTOS; }
		    set { _COSTO_PUNTOS = value; }
	    }

        public int SALDO_INICIAL
        {
            get
            {
                return _SALDO_INICIAL;
            }

            set
            {
                _SALDO_INICIAL = value;
            }
        }

        public int MAX_CANJEES
        {
            get
            {
                return _MAX_CANJEES;
            }

            set
            {
                _MAX_CANJEES = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLPRODUCTOTIENDA();
        }

        #endregion	    
    }
}