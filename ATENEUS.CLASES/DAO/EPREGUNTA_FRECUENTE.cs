
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPREGUNTAFRECUENTE.
    /// </summary>
    [Serializable()]
    public class EPREGUNTAFRECUENTE : DomainObject
    {
	    	
	    private System.Decimal  _cod_pregunta = 0;
        	
	    private System.Int16  _cod_actividad = 0;
        	
	    private System.String  _texto_pregunta = String.Empty;
        	
	    private System.String  _texto_respuesta = String.Empty;
        	
	    private System.Boolean  _mostrar = false;
        	
	    private System.Int16  _orden_relativo = 0;
        	
        
	    public EPREGUNTAFRECUENTE() : base()
	    {
	    }
	    
		public EPREGUNTAFRECUENTE(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodPregunta
	    {
		    get { return _cod_pregunta; }
		    set { _cod_pregunta = value; }
	    }
	    
	    	
	    public System.Int16 CodActividad
	    {
		    get { return _cod_actividad; }
		    set { _cod_actividad = value; }
	    }
	    
	    	
	    public System.String TextoPregunta
	    {
		    get { return _texto_pregunta; }
		    set { _texto_pregunta = value; }
	    }
	    
	    	
	    public System.String TextoRespuesta
	    {
		    get { return _texto_respuesta; }
		    set { _texto_respuesta = value; }
	    }
	    
	    	
	    public System.Boolean Mostrar
	    {
		    get { return _mostrar; }
		    set { _mostrar = value; }
	    }
	    
	    	
	    public System.Int16 OrdenRelativo
	    {
		    get { return _orden_relativo; }
		    set { _orden_relativo = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLPREGUNTAFRECUENTE();
        }

        #endregion	    
    }
}