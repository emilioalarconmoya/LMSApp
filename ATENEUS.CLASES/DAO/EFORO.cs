
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EFORO.
    /// </summary>
    [Serializable()]
    public class EFORO : DomainObject
    {
	    	
	    private System.Int32  _IdForo = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
	    private System.Int32  _total = 0;
        	
	    private System.DateTime  _ultimo = System.DateTime.Now;
        	
	    private System.String  _descripcion = String.Empty;

        private System.Int64 _cod_empresa = 0;

        public EFORO() : base()
	    {
	    }
	    
		public EFORO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int32 IdForo
	    {
		    get { return _IdForo; }
		    set { _IdForo = value; }
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
	    
	    	
	    public System.Int32 Total
	    {
		    get { return _total; }
		    set { _total = value; }
	    }
	    
	    	
	    public System.DateTime Ultimo
	    {
		    get { return _ultimo; }
		    set { _ultimo = value; }
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
            return new DLFORO();
        }

        #endregion	    
    }
}