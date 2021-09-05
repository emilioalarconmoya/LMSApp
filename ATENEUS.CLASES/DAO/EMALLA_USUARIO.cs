
using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    [Serializable()]
    public  class EMALLAUSUARIO : DomainObject
    {
        private System.Int32 _rut_usuario = 0;

        private System.Int32 _Cod_Malla = 0;

        private System.Int32 _nro_asignacion = 0;

        private System.String _nombre_usuario = "";

        private System.String _nombre_malla = "";

        private System.Boolean _Vigente = false;
		
		private System.Int64 _cod_empresa = 0;

        public EMALLAUSUARIO() : base()
	    {
        }

        public EMALLAUSUARIO(long id) : base(id)
		{
        }

        #region Properties    	

        public System.Int32 RutUsuario
        {
            get { return _rut_usuario; }
            set { _rut_usuario = value; }
        }


        public System.Int32 CodMalla
        {
            get { return _Cod_Malla; }
            set { _Cod_Malla = value; }
        }


        public System.Int32 NroAsignacion
        {
            get { return _nro_asignacion; }
            set { _nro_asignacion = value; }
        }

        public System.String NombreUsuario
        {
            get { return _nombre_usuario; }
            set { _nombre_usuario = value; }
        }

        public System.String NombreMalla
        {
            get { return _nombre_malla; }
            set { _nombre_malla = value; }
        }

        public System.Boolean Vigente
        {
            get { return _Vigente; }
            set { _Vigente = value; }
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
            return new DLMALLAUSUARIO();
        }

        #endregion	 
    }
}
