
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ELOGCONEXION.
    /// </summary>
    [Serializable()]
    public class ELOGCONEXION : DomainObject
    {
	    	
	    private System.DateTime  _inicio = System.DateTime.Now;
        	
	    private System.Int16  _cod_unidad = 0;
        	
	    private System.Decimal  _cod_activ_usr = 0;
        	
	    private System.DateTime  _fin = System.DateTime.Now;
        	
	    private System.Boolean  _terminada = false;
        	
	    private System.Int32  _tiempo_restante_seg = 0;

        private System.Int32 _paso_ultima_visita = 0;

        private System.Boolean _cerrada = false;

        private System.Int64 _cod_empresa = 0;
		
		private System.String _dispositivo = "";

        private System.String _browser = "";

        private System.String _ip = "";


        public ELOGCONEXION() : base()
	    {
	    }
	    
		public ELOGCONEXION(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.DateTime Inicio
	    {
		    get { return _inicio; }
		    set { _inicio = value; }
	    }

        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }


        public System.Int16 CodUnidad
	    {
		    get { return _cod_unidad; }
		    set { _cod_unidad = value; }
	    }
	    
	    	
	    public System.Decimal CodActivUsr
	    {
		    get { return _cod_activ_usr; }
		    set { _cod_activ_usr = value; }
	    }
	    
	    	
	    public System.DateTime Fin
	    {
		    get { return _fin; }
		    set { _fin = value; }
	    }
	    
	    	
	    public System.Boolean Terminada
	    {
		    get { return _terminada; }
		    set { _terminada = value; }
	    }
	    
	    	
	    public System.Int32 TiempoRestanteSeg
	    {
		    get { return _tiempo_restante_seg; }
		    set { _tiempo_restante_seg = value; }
	    }
	    
	    	
	    public System.Int32 PasoUltimaVisita
	    {
		    get { return _paso_ultima_visita; }
		    set { _paso_ultima_visita = value; }
	    }

        public System.Boolean Cerrada
        {
            get { return _cerrada; }
            set { _cerrada = value; }
        }

        public System.String Dispositivo
        {
            get { return _dispositivo; }
            set { _dispositivo = value; }
        }

        public System.String Browser
        {
            get { return _browser; }
            set { _browser = value; }
        }

        public System.String IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        #endregion

        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLLOGCONEXION();
        }

        #endregion	    
    }
}