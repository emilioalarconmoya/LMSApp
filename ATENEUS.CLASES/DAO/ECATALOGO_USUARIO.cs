
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ETIPOACTIVIDAD.
    /// </summary>
    [Serializable()]
    public class ECATALOGOUSUARIO : DomainObject
    {
        private System.Int32 _cod_catalogo = 0;
        
        	
	    private System.Int32 _rut_usuario = 0;

        private System.Int64 _cod_empresa = 0;


        public ECATALOGOUSUARIO() : base()
	    {
	    }
	    
		public ECATALOGOUSUARIO(long id) : base(id)
		{
		}

        #region Properties

        public System.Int32 Codcatalogo
        {
            get { return _cod_catalogo; }
            set { _cod_catalogo = value; }
        }


     //   public System.Int32 CodcatalogoActividad
	    //{
		   // get { return _cod_catalogo_actividad; }
		   // set { _cod_catalogo_actividad = value; }
	    //}


        public System.Int32 RutUsuario
        {
            get { return _rut_usuario; }
            set { _rut_usuario = value; }
        }
        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLCATALOGOUSUARIO();
        }

        #endregion	    
    }
}