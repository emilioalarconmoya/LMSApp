
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECAMPOPLANTILLA.
    /// </summary>
    [Serializable()]
    public class ECAMPOPLANTILLA : DomainObject
    {
	    	
	    private System.Decimal  _cod_plantilla = 0;
        	
	    private System.Decimal  _cod_campo = 0;

        private System.Int32 _orden = 0;


        public ECAMPOPLANTILLA() : base()
	    {
	    }
	    
		public ECAMPOPLANTILLA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodPlantilla
	    {
		    get { return _cod_plantilla; }
		    set { _cod_plantilla = value; }
	    }
	    
	    	
	    public System.Decimal CodCampo
	    {
		    get { return _cod_campo; }
		    set { _cod_campo = value; }
	    }

        public int Orden
        {
            get { return _orden; }
            set { _orden = value; }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLCAMPOPLANTILLA();
        }

        #endregion	    
    }
}