
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPROVEEDOR.
    /// </summary>
    [Serializable()]
    public class EPROVEEDOR : DomainObject
    {
	    	
	    private System.Int16  _cod_proveedor = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
	    private System.String  _direccion = String.Empty;
        	
	    private System.String  _comuna = String.Empty;
        	
	    private System.String  _ciudad = String.Empty;
        	
	    private System.String  _codigo_postal = String.Empty;
        	
	    private System.String  _pais = String.Empty;
        	
	    private System.String  _fono = String.Empty;
        	
	    private System.Int64  _rut = 0;
        	
	    private System.String  _clave_sence = String.Empty;

        private System.Int64 _cod_empresa = 0;
		
		private System.String _token = String.Empty;

        public EPROVEEDOR() : base()
	    {
	    }
	    
		public EPROVEEDOR(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodProveedor
	    {
		    get { return _cod_proveedor; }
		    set { _cod_proveedor = value; }
	    }
        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }


        public System.String Nombre
	    {
		    get { return _nombre; }
		    set { _nombre = value; }
	    }
	    
	    	
	    public System.String Direccion
	    {
		    get { return _direccion; }
		    set { _direccion = value; }
	    }
	    
	    	
	    public System.String Comuna
	    {
		    get { return _comuna; }
		    set { _comuna = value; }
	    }
	    
	    	
	    public System.String Ciudad
	    {
		    get { return _ciudad; }
		    set { _ciudad = value; }
	    }
	    
	    	
	    public System.String CodigoPostal
	    {
		    get { return _codigo_postal; }
		    set { _codigo_postal = value; }
	    }
	    
	    	
	    public System.String Pais
	    {
		    get { return _pais; }
		    set { _pais = value; }
	    }
	    
	    	
	    public System.String Fono
	    {
		    get { return _fono; }
		    set { _fono = value; }
	    }
	    
	    	
	    public System.Int64 Rut
	    {
		    get { return _rut; }
		    set { _rut = value; }
	    }
	    
	    	
	    public System.String ClaveSence
	    {
		    get { return _clave_sence; }
		    set { _clave_sence = value; }
	    }

        public System.String Token
        {
            get { return _token; }
            set { _token = value; }
        }

        #endregion

        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLPROVEEDOR();
        }

        #endregion	    
    }
}