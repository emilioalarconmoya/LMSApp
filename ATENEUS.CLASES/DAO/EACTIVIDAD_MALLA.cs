
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EACTIVIDADMALLA.
    /// </summary>
    [Serializable()]
    public class EACTIVIDADMALLA : DomainObject
    {
	    	
	    private System.Decimal  _Cod_Malla = 0;
        	
	    private System.Int16  _cod_actividad = 0;
        	
	    private System.Int32  _duracion = 0;
        	
	    private System.Double  _nota_aprobacion = 0.0;
        	
	    private System.Int32  _dias_intervalo = 0;
        	
	    private System.Int32  _nivel = 0;
        	
	    private System.Int32  _nro_de_reasignaciones = 0;
        	
	    private System.Int32  _nota_maxima = 0;

        private System.Int32 _orden = 0;


        public EACTIVIDADMALLA() : base()
	    {
	    }
	    
		public EACTIVIDADMALLA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodMalla
	    {
		    get { return _Cod_Malla; }
		    set { _Cod_Malla = value; }
	    }
	    
	    	
	    public System.Int16 CodActividad
	    {
		    get { return _cod_actividad; }
		    set { _cod_actividad = value; }
	    }
	    
	    	
	    public System.Int32 Duracion
	    {
		    get { return _duracion; }
		    set { _duracion = value; }
	    }
	    
	    	
	    public System.Double NotaAprobacion
	    {
		    get { return _nota_aprobacion; }
		    set { _nota_aprobacion = value; }
	    }
	    
	    	
	    public System.Int32 DiasIntervalo
	    {
		    get { return _dias_intervalo; }
		    set { _dias_intervalo = value; }
	    }
	    
	    	
	    public System.Int32 Nivel
	    {
		    get { return _nivel; }
		    set { _nivel = value; }
	    }
	    
	    	
	    public System.Int32 NroDeReasignaciones
	    {
		    get { return _nro_de_reasignaciones; }
		    set { _nro_de_reasignaciones = value; }
	    }
	    
	    	
	    public System.Int32 NotaMaxima
	    {
		    get { return _nota_maxima; }
		    set { _nota_maxima = value; }
	    }

        public System.Int32 Orden
        {
            get { return _orden; }
            set { _orden = value; }
        }


        #endregion

        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLACTIVIDADMALLA();
        }

        #endregion	    
    }
}