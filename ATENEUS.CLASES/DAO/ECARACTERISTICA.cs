
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECARACTERISTICA.
    /// </summary>
    [Serializable()]
    public class ECARACTERISTICA : DomainObject
    {
	    	
	    private System.Int16  _cod_caracteristica = 0;
        	
	    private System.String  _nombre = String.Empty;

        private System.Int64 _cod_empresa = 0;

        public ECARACTERISTICA() : base()
	    {
	    }
	    
		public ECARACTERISTICA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodCaracteristica
	    {
		    get { return _cod_caracteristica; }
		    set { _cod_caracteristica = value; }
	    }
	    
	    	
	    public System.String Nombre
	    {
		    get { return _nombre; }
		    set { _nombre = value; }
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
            return new DLCARACTERISTICA();
        }

        #endregion	    
    }
}