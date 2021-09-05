
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EEVALUACION.
    /// </summary>
    [Serializable()]
    public class EEVALUACION : DomainObject
    {
	    	
	    private System.Int16  _cod_unidad = 0;
        	
	    private System.Int16  _cod_pregunta = 0;
        	
	    private System.DateTime  _fecha_hora = System.DateTime.Now;
        	
	    private System.Decimal  _cod_activ_usr = 0;
        	
	    private System.String  _texto_respuesta = String.Empty;
        	
	    private System.Double  _puntaje = 0.0;
        	
	    private System.String  _comentarios = String.Empty;
        	
	    private System.Boolean  _Esta_incluida = false;
        	
	    private System.Int32  _NroIntentos = 0;

        private System.Boolean _avisa_termino = false;

        private System.Int64 _cod_empresa = 0;

        public EEVALUACION() : base()
	    {
	    }
	    
		public EEVALUACION(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodUnidad
	    {
		    get { return _cod_unidad; }
		    set { _cod_unidad = value; }
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
	    
	    	
	    public System.DateTime FechaHora
	    {
		    get { return _fecha_hora; }
		    set { _fecha_hora = value; }
	    }
	    
	    	
	    public System.Decimal CodActivUsr
	    {
		    get { return _cod_activ_usr; }
		    set { _cod_activ_usr = value; }
	    }
	    
	    	
	    public System.String TextoRespuesta
	    {
		    get { return _texto_respuesta; }
		    set { _texto_respuesta = value; }
	    }
	    
	    	
	    public System.Double Puntaje
	    {
		    get { return _puntaje; }
		    set { _puntaje = value; }
	    }
	    
	    	
	    public System.String Comentarios
	    {
		    get { return _comentarios; }
		    set { _comentarios = value; }
	    }
	    
	    	
	    public System.Boolean EstaIncluida
	    {
		    get { return _Esta_incluida; }
		    set { _Esta_incluida = value; }
	    }
	    
	    	
	    public System.Int32 NroIntentos
	    {
		    get { return _NroIntentos; }
		    set { _NroIntentos = value; }
	    }

        public System.Boolean AvisaTremino
        {
            get { return _avisa_termino; }
            set { _avisa_termino = value; }
        }

        

        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLEVALUACION();
        }

        #endregion	    
    }
}