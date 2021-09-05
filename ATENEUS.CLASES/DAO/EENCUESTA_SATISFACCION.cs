
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EUNIDAD.
    /// </summary>
    [Serializable()]
    public class EENCUESTASATISFACCION : DomainObject
    {
	    	
	    private System.Int16  _cod_encuesta_satisfaccion = 0;
	   
        private string _nombre = string.Empty;
        	
	    private string _descripcion = string.Empty;

        private System.Int64 _cod_empresa = 0;

        private System.Boolean _flag_activo = false;


        public EENCUESTASATISFACCION() : base()
	    {
	    }
	    
		public EENCUESTASATISFACCION(long id) : base(id)
		{
		}
        
        #region Properties    	

        public System.Int16 CodEncuestaSatisfaccion
	    {
		    get { return _cod_encuesta_satisfaccion; }
		    set { _cod_encuesta_satisfaccion = value; }
	    }

	    public string Nombre
	    {
		    get { return _nombre; }
		    set { _nombre = value; }
	    }
	    
	    	
	    public string Descripcion
	    {
		    get { return _descripcion; }
		    set { _descripcion = value; }
	    }

        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }

        public System.Boolean Activo
        {
            get { return _flag_activo; }
            set { _flag_activo = value; }
        }

        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLENCUESTASATISFACCION();
        }

        #endregion	    
    }
}