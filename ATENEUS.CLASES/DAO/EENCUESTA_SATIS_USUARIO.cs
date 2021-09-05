
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EENCUESTA.
    /// </summary>
    [Serializable()]
    public class EENCUESTASATISUSUARIO : DomainObject
    {
	    	
	    private System.Int16 _cod_encuesta_satisfaccion = 0;
        	
	    private System.Int16  _cod_pregunta = 0;
        	
	    private System.Decimal  _cod_activ_usr = 0;
        	
	    private System.DateTime  _Fecha_hora = System.DateTime.Now;
        	
	    private System.String  _Texto_respuesta = String.Empty;

        private System.Int64 _cod_empresa = 0;

        public EENCUESTASATISUSUARIO() : base()
	    {
	    }
	    
		public EENCUESTASATISUSUARIO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodEncuestaSatisfaccion
	    {
		    get { return _cod_encuesta_satisfaccion; }
		    set { _cod_encuesta_satisfaccion = value; }
	    }
        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }


        public System.Int16 CodPregunta
	    {
		    get { return _cod_pregunta; }
		    set { _cod_pregunta = value; }
	    }
	    
	    	
	    public System.Decimal CodActivUsr
	    {
		    get { return _cod_activ_usr; }
		    set { _cod_activ_usr = value; }
	    }
	    
	    	
	    public System.DateTime FechaHora
	    {
		    get { return _Fecha_hora; }
		    set { _Fecha_hora = value; }
	    }
	    
	    	
	    public System.String TextoRespuesta
	    {
		    get { return _Texto_respuesta; }
		    set { _Texto_respuesta = value; }
	    }





        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLENCUESTASATISUSUARIO();
        }

        #endregion	    
    }
}