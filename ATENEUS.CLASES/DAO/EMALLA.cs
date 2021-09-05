
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EMALLA.
    /// </summary>
    [Serializable()]
    public class EMALLA : DomainObject
    {
	    	
	    private System.Int32  _Cod_Malla = 0;
        	
	    private System.String  _Nombre = String.Empty;
        	
	    private System.String  _Descripcion = String.Empty;

        private System.Boolean _Vigente = false;
		
		private System.Int64 _cod_empresa = 0;	
        
	    public EMALLA() : base()
	    {
	    }
	    
		public EMALLA(long id) : base(id)
		{
		}

        public EMALLA(long id, Int64 CodEmpres) : base(id, CodEmpres)
        {
        }

        #region Properties    	

        public System.Int32 CodMalla
	    {
		    get { return _Cod_Malla; }
		    set { _Cod_Malla = value; }
	    }
	    
	    	
	    public System.String Nombre
	    {
		    get { return _Nombre; }
		    set { _Nombre = value; }
	    }
	    
	    	
	    public System.String Descripcion
	    {
		    get { return _Descripcion; }
		    set { _Descripcion = value; }
	    }
	    
        public System.Boolean Vigente
        {
            get { return _Vigente; }
            set { _Vigente = value; }
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
            return new DLMALLA();
        }

        #endregion	    
    }
}