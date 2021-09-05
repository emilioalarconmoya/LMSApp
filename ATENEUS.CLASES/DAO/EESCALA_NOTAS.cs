
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EESCALANOTAS.
    /// </summary>
    [Serializable()]
    public class EESCALANOTAS : DomainObject
    {
	    	
	    private System.Decimal  _cod_escala = 0;
        	
	    private System.String  _nombre = String.Empty;
        	
	    private System.Double  _nota_minima = 0.0;
        	
	    private System.Double  _nota_maxima = 0.0;
        	
	    private System.Double  _nota_aprobacion = 0.0;
        	
	    private System.Double  _exigencia = 0.0;

        private System.Int64 _cod_empresa = 0;


        public EESCALANOTAS() : base()
	    {
	    }
	    
		public EESCALANOTAS(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodEscala
	    {
		    get { return _cod_escala; }
		    set { _cod_escala = value; }
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
	    
	    	
	    public System.Double NotaMinima
	    {
		    get { return _nota_minima; }
		    set { _nota_minima = value; }
	    }
	    
	    	
	    public System.Double NotaMaxima
	    {
		    get { return _nota_maxima; }
		    set { _nota_maxima = value; }
	    }
	    
	    	
	    public System.Double NotaAprobacion
	    {
		    get { return _nota_aprobacion; }
		    set { _nota_aprobacion = value; }
	    }
	    
	    	
	    public System.Double Exigencia
	    {
		    get { return _exigencia; }
		    set { _exigencia = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLESCALANOTAS();
        }

        #endregion	    
    }
}