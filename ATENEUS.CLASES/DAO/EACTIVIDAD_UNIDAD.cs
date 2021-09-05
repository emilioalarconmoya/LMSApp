
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EACTIVIDADUNIDAD.
    /// </summary>
    [Serializable()]
    public class EACTIVIDADUNIDAD : DomainObject
    {
	    	
	    private System.Int16  _cod_actividad = 0;
        	
	    private System.Int16  _cod_unidad = 0;
        	
	    private System.Int32  _orden_relativo = 0;
        	
	    private System.Int32  _nivel_prerequisitos = 0;

        private System.DateTime _fecha_hora = System.DateTime.Now;

        private System.Boolean _flag_activo = false;

        private System.Int16 _nivel = 0;


        public EACTIVIDADUNIDAD() : base()
	    {
	    }
	    
		public EACTIVIDADUNIDAD(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodActividad
	    {
		    get { return _cod_actividad; }
		    set { _cod_actividad = value; }
	    }
	    
	    	
	    public System.Int16 CodUnidad
	    {
		    get { return _cod_unidad; }
		    set { _cod_unidad = value; }
	    }
	    
	    	
	    public System.Int32 OrdenRelativo
	    {
		    get { return _orden_relativo; }
		    set { _orden_relativo = value; }
	    }
	    
	    	
	    public System.Int32 NivelPrerequisitos
	    {
		    get { return _nivel_prerequisitos; }
		    set { _nivel_prerequisitos = value; }
	    }

        public System.DateTime FechaHora
        {
            get { return _fecha_hora; }
            set { _fecha_hora = value; }
        }

        public System.Boolean FlagActivo
        {
            get { return _flag_activo; }
            set { _flag_activo = value; }
        }

        public System.Int16 Nivel
        {
            get { return _nivel; }
            set { _nivel = value; }
        }

        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLACTIVIDADUNIDAD();
        }

        #endregion	    
    }
}