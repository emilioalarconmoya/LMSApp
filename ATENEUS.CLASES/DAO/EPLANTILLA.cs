
using System;
using ATENEUS.CLASES.DAL;
using System.Collections.Generic;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPLANTILLA.
    /// </summary>
    [Serializable()]
    public class EPLANTILLA : DomainObject
    {
	    	
	    private System.Decimal  _cod_plantilla = 0;
        	
	    private System.String  _nombre_plantilla = String.Empty;

        private List<ECAMPO> _Campos = new List<ECAMPO>();
        private System.Int64 _cod_empresa = 0;


        public EPLANTILLA() : base()
	    {
	    }
	    
		public EPLANTILLA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodPlantilla
	    {
		    get { return _cod_plantilla; }
		    set { _cod_plantilla = value; }
	    }
        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }


        public System.String NombrePlantilla
	    {
		    get { return _nombre_plantilla; }
		    set { _nombre_plantilla = value; }
	    }

        public List<ECAMPO> Campos
        {
            get { return _Campos; }
            set { _Campos = value; }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLPLANTILLA();
        }

        #endregion	    
    }
}