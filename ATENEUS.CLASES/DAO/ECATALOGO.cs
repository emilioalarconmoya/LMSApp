
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for Ecatalogo.
    /// </summary>
    [Serializable()]
    public class ECATALOGO : DomainObject
    {
	    	
	    private System.Int16  _cod_catalogo = 0;
        	
	    private System.String  _nombre = String.Empty;

        private System.Boolean _flag_activo = false;

        private System.Int64 _cod_empresa = 0;
        	
        
	    public ECATALOGO() : base()
	    {
	    }
	    
		public ECATALOGO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 Codcatalogo
	    {
		    get { return _cod_catalogo; }
		    set { _cod_catalogo = value; }
	    }
	    
	    	
	    public System.String Nombre
	    {
		    get { return _nombre; }
		    set { _nombre = value; }
	    }

        public System.Boolean FlagActivo
        {
            get { return _flag_activo; }
            set { _flag_activo = value; }
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
            return new DLCATALOGO();
        }

        #endregion	    
    }
}