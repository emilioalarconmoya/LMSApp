

using System;
using ATENEUS.CLASES.DAL;
using System.Collections.Generic;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ETIENDA.
	/// </summary>
    public class ETIENDA : DomainObject
    {
	    	
	    private System.String  _COD_TIENDA = String.Empty;
        	
	    private System.Int16  _COD_ATRIBUTO = 0;
        	
	    private System.Int16  _COD_CARACTERISTICA = 0;
        	
	    private System.String  _NOMBRE = String.Empty;
        	
	    private System.DateTime  _INICIO = DateTime.Now;
        	
	    private System.DateTime  _FIN = DateTime.Now;

        private List<EPRODUCTOTIENDA> _PRODUCTOS_TIENDA = new List<EPRODUCTOTIENDA>();

        private System.Int64 _COD_EMPRESA = 0;

        public System.Int64 CodEmpresa
        {
            get { return _COD_EMPRESA; }
            set { _COD_EMPRESA = value; }
        }

        public ETIENDA() : base()
	    {
	    }
	    
		public ETIENDA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODTIENDA
	    {
		    get { return _COD_TIENDA; }
		    set { _COD_TIENDA = value; }
	    }
	    
	    	
	    public System.Int16 CODATRIBUTO
	    {
		    get { return _COD_ATRIBUTO; }
		    set { _COD_ATRIBUTO = value; }
	    }
	    
	    	
	    public System.Int16 CODCARACTERISTICA
	    {
		    get { return _COD_CARACTERISTICA; }
		    set { _COD_CARACTERISTICA = value; }
	    }
	    
	    	
	    public System.String NOMBRE
	    {
		    get { return _NOMBRE; }
		    set { _NOMBRE = value; }
	    }
	    
	    	
	    public System.DateTime INICIO
	    {
		    get { return _INICIO; }
		    set { _INICIO = value; }
	    }
	    
	    	
	    public System.DateTime FIN
	    {
		    get { return _FIN; }
		    set { _FIN = value; }
	    }

        public List<EPRODUCTOTIENDA> PRODUCTOS_TIENDA
        {
            get
            {
                return _PRODUCTOS_TIENDA;
            }

            set
            {
                _PRODUCTOS_TIENDA = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLTIENDA();
        }

        #endregion	    
    }
}