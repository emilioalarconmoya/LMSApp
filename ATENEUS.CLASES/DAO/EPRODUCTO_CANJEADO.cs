

using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPRODUCTOCANJEADO.
	/// </summary>
    public class EPRODUCTOCANJEADO : DomainObject
    {
	    	
	    private System.String  _COD_PRODUCTO = String.Empty;
        	
	    private System.Decimal  _COD_MOVIMIENTO = 0;
        	
	    private System.String  _COD_TIENDA = String.Empty;
        	
	    private System.Int32  _COSTO_PUNTOS = 0;

        private System.Boolean _FLAG_ENTREGADO = false;

        private System.DateTime _FECHA_ENTREGA = System.DateTime.Now;

        private System.Int64 _ENTREGADO_POR = 0;



        public EPRODUCTOCANJEADO() : base()
	    {
	    }
	    
		public EPRODUCTOCANJEADO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODPRODUCTO
	    {
		    get { return _COD_PRODUCTO; }
		    set { _COD_PRODUCTO = value; }
	    }
	    
	    	
	    public System.Decimal CODMOVIMIENTO
	    {
		    get { return _COD_MOVIMIENTO; }
		    set { _COD_MOVIMIENTO = value; }
	    }
	    
	    	
	    public System.String CODTIENDA
	    {
		    get { return _COD_TIENDA; }
		    set { _COD_TIENDA = value; }
	    }
	    
	    	
	    public System.Int32 COSTOPUNTOS
	    {
		    get { return _COSTO_PUNTOS; }
		    set { _COSTO_PUNTOS = value; }
	    }

        public bool FLAG_ENTREGADO
        {
            get
            {
                return _FLAG_ENTREGADO;
            }

            set
            {
                _FLAG_ENTREGADO = value;
            }
        }

        public DateTime FECHA_ENTREGA
        {
            get
            {
                return _FECHA_ENTREGA;
            }

            set
            {
                _FECHA_ENTREGA = value;
            }
        }

        public long ENTREGADO_POR
        {
            get
            {
                return _ENTREGADO_POR;
            }

            set
            {
                _ENTREGADO_POR = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLPRODUCTOCANJEADO();
        }

        #endregion	    
    }
}