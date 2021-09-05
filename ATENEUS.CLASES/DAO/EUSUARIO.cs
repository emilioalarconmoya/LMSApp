
using System;
using ATENEUS.CLASES.DAL;
using ATENEUS.COMMON;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EUSUARIO.
    /// </summary>
    [Serializable()]
    public class EUSUARIO : DomainObject
    {

        private System.String _rut_completo = String.Empty;

        private System.Int64 _rut_usuario = 0;
        	
	    private System.String  _nombres = String.Empty;

        private System.String _apellidos = String.Empty;

        private System.String _nombre_completo = String.Empty;
        	
	    private System.String  _passwd_enc = String.Empty;
        	
	    private System.String  _email = String.Empty;
        	
	    private System.DateTime  _Fecha_caducidad = System.DateTime.Now;
        	
	    private System.DateTime  _Fecha_Creacion = System.DateTime.Now;
        	
	    private System.Boolean  _Bloqueado = false;
        	
	    private System.String  _clave_sence = String.Empty;
        	
	    private System.String  _profesion = String.Empty;
        	
	    private System.String  _direccion = String.Empty;
        	
	    private System.String  _comuna = String.Empty;

        private System.Int64 _cod_empresa = 0;
		
		private System.String _dni = String.Empty;

        private System.String _fono = String.Empty;

        public EUSUARIO() : base()
	    {
	    }
	    
		//public EUSUARIO(long id) : base(id)
		//{
		//}
        public EUSUARIO(long id,Int64 CodEmpresa) : base(id,CodEmpresa)
        {
        }

        #region Properties    	

        public System.Int64 RutUsuario
	    {
		    get { return _rut_usuario; }
		    set { _rut_usuario = value; }
	    }
        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }


        public System.String RutCompleto
        {
            get { return Utiles.RutLngAUsr(_rut_usuario); }
            set { _rut_completo = value; }
        }
	    
	    	
	    public System.String Nombres
	    {
		    get { return _nombres; }
		    set { _nombres = value; }
	    }
	    
	    	
	    public System.String Apellidos
	    {
		    get { return _apellidos; }
		    set { _apellidos = value; }
	    }


        public System.String NombreCompleto
        {
            get { return _nombres + " " + _apellidos; }
            set { _nombre_completo = value; }
        }
	    
	    	
	    public System.String PasswdEnc
	    {
		    get { return _passwd_enc; }
		    set { _passwd_enc = value; }
	    }
	    
	    	
	    public System.String Email
	    {
		    get { return _email; }
		    set { _email = value; }
	    }
	    
	    	
	    public System.DateTime FechaCaducidad
	    {
		    get { return _Fecha_caducidad; }
		    set { _Fecha_caducidad = value; }
	    }
	    
	    	
	    public System.DateTime FechaCreacion
	    {
		    get { return _Fecha_Creacion; }
		    set { _Fecha_Creacion = value; }
	    }
	    
	    	
	    public System.Boolean Bloqueado
	    {
		    get { return _Bloqueado; }
		    set { _Bloqueado = value; }
	    }
	    
	    	
	    public System.String ClaveSence
	    {
		    get { return _clave_sence; }
		    set { _clave_sence = value; }
	    }
	    
	    	
	    public System.String Profesion
	    {
		    get { return _profesion; }
		    set { _profesion = value; }
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
		
		 public System.String DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }

        public System.String Fono
        {
            get { return _fono; }
            set { _fono = value; }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLUSUARIO();
        }

        #endregion	    
    }
}